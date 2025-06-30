using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Status;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CompanyUserImageManager : ICompanyUserImageService
    {
        ICompanyUserImageDal _companyUserImageDal;
        IUserService _userService;
        private readonly IWebHostEnvironment _environment;

        public CompanyUserImageManager(ICompanyUserImageDal companyUserImageDal, IUserService userService, IWebHostEnvironment environment)
        {
            _companyUserImageDal = companyUserImageDal;
            _userService = userService;
            _environment = environment;
        }
        
        [SecuredOperation("admin,user")]
        public IResult Add(CompanyUserImage companyUserImage)
        {
            if (_userService.GetById(companyUserImage.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _companyUserImageDal.AddAsync(companyUserImage);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Update(CompanyUserImage companyUserImage)
        {
            if (_userService.GetById(companyUserImage.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _companyUserImageDal.UpdateAsync(companyUserImage);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(CompanyUserImage companyUserImage)
        {
            if (_userService.GetById(companyUserImage.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _companyUserImageDal.Delete(companyUserImage);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        public IResult Terminate(CompanyUserImage companyUserImage)
        {
            DeleteImage(companyUserImage);
            _companyUserImageDal.Terminate(companyUserImage);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserImage>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserImage>>(_companyUserImageDal.GetAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserImage>>(_companyUserImageDal.GetAll());
            }
            
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserImage>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserImage>>(_companyUserImageDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserImage>>(_companyUserImageDal.GetDeletedAll());
            }

        }

        [SecuredOperation("admin,user")]
        public IDataResult<CompanyUserImage> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<CompanyUserImage>(_companyUserImageDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<CompanyUserImage>(_companyUserImageDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }

        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserImageDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserImageDTO>>(_companyUserImageDal.GetAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList());
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserImageDTO>>(_companyUserImageDal.GetAllDTO().OrderBy(s => s.Email).ToList());
            }
            
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserImageDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserImageDTO>>(_companyUserImageDal.GetDeletedAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList());
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserImageDTO>>(_companyUserImageDal.GetDeletedAllDTO().OrderBy(s => s.Email).ToList());
            }

        }

        public IResult DeleteImage(CompanyUserImage companyUserImage)
        {
            if (companyUserImage == null)
            {
                return new ErrorDataResult<PersonelUserImage>(Messages.ImageNotFound);
            }

            string fullImagePath = _environment.WebRootPath + "\\uploads\\images\\" + companyUserImage.UserId + "\\" + companyUserImage.ImageName;

            if (System.IO.File.Exists(fullImagePath))
            {
                System.IO.File.Delete(fullImagePath);
            }

            string fullThumbImagePath = _environment.WebRootPath + "\\uploads\\images\\" + companyUserImage.UserId + "\\thumbs\\" + companyUserImage.ImageName;

            if (System.IO.File.Exists(fullThumbImagePath))
            {
                System.IO.File.Delete(fullThumbImagePath);

            }

            companyUserImage.ImagePath = "https://localhost:7088/" + "/uploads/images/common/";
            companyUserImage.ImageName = "noImage.jpg";

            return new SuccessResult();
        }
    }
}
