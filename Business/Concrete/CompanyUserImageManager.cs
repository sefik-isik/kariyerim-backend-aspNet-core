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
        public async Task<IResult> Add(CompanyUserImage companyUserImage)
        {
            if (_userService.GetById(companyUserImage.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _companyUserImageDal.AddAsync(companyUserImage);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Update(CompanyUserImage companyUserImage)
        {
            if (_userService.GetById(companyUserImage.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }

            if (companyUserImage.IsMainImage == true)
            {
                await _companyUserImageDal.UpdateMainImage(companyUserImage.CompanyUserId);
            }

            if (companyUserImage.IsLogo == true)
            {
                await _companyUserImageDal.UpdateLogoImage(companyUserImage.CompanyUserId);
            }

            await _companyUserImageDal.UpdateAsync(companyUserImage);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Delete(CompanyUserImage companyUserImage)
        {
            if (_userService.GetById(companyUserImage.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _companyUserImageDal.Delete(companyUserImage);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(CompanyUserImage companyUserImage)
        {
            await DeleteImage(companyUserImage);
            await _companyUserImageDal.Terminate(companyUserImage);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        public async Task<IResult> DeleteImage(CompanyUserImage companyUserImage)
        {
            if (companyUserImage == null)
            {
                return new ErrorDataResult<CompanyUserImage>(Messages.ImageNotFound);
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

            await Update(companyUserImage);

            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUserImage>>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserImage>>(await _companyUserImageDal.GetAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserImage>>(await _companyUserImageDal.GetAll());
            }

        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUserImage>>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserImage>>(await _companyUserImageDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserImage>>(await _companyUserImageDal.GetDeletedAll());
            }

        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<CompanyUserImage?>> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<CompanyUserImage?>(await _companyUserImageDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<CompanyUserImage?>(await _companyUserImageDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }

        //DTO
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUserImageDTO>>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var alldto = await _companyUserImageDal.GetAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserImageDTO>>(alldto.OrderBy(x => x.CompanyUserName).ToList().FindAll(c => c.UserId == userAdminDTO.UserId).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserImageDTO>>(alldto.OrderBy(x => x.CompanyUserName).ToList().OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }

        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUserImageDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var alldto = await _companyUserImageDal.GetDeletedAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserImageDTO>>(alldto.OrderBy(x => x.CompanyUserName).ToList().FindAll(c => c.UserId == userAdminDTO.UserId).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserImageDTO>>(alldto.OrderBy(x => x.CompanyUserName).ToList().ToList(), Messages.SuccessListed);
            }

        }

    }   
}
