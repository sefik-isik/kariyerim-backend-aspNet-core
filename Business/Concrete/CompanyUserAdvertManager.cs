using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CompanyUserAdvertManager : ICompanyUserAdvertService
    {
        ICompanyUserAdvertDal _companyUserAdvertDal;
        IUserService _userService;
        private readonly IWebHostEnvironment _environment;

        public CompanyUserAdvertManager(ICompanyUserAdvertDal companyUserAdvertDal, IUserService userService, IWebHostEnvironment environment)
        {
            _companyUserAdvertDal = companyUserAdvertDal;
            _userService = userService;
            _environment = environment;
        }

        [SecuredOperation("admin,user")]
        public IResult Add(CompanyUserAdvert companyUserAdvert)
        {
            if (_userService.GetById(companyUserAdvert.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            IResult result = BusinessRules.Run(IsNameExist(companyUserAdvert.AdvertName));

            if (result != null)
            {
                return result;
            }
            _companyUserAdvertDal.AddAsync(companyUserAdvert);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Update(CompanyUserAdvert companyUserAdvert)
        {
            if (_userService.GetById(companyUserAdvert.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _companyUserAdvertDal.UpdateAsync(companyUserAdvert);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(CompanyUserAdvert companyUserAdvert)
        {
            if (_userService.GetById(companyUserAdvert.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _companyUserAdvertDal.Delete(companyUserAdvert);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IResult Terminate(CompanyUserAdvert companyUserAdvert)
        {
            DeleteImage(companyUserAdvert);
            _companyUserAdvertDal.TerminateSubDatas(companyUserAdvert.Id);
            _companyUserAdvertDal.Terminate(companyUserAdvert);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserAdvert>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAdvert>>(_companyUserAdvertDal.GetAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.AdvertName).ToList());
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAdvert>>(_companyUserAdvertDal.GetAll().OrderBy(s => s.AdvertName).ToList());
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserAdvert>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAdvert>>(_companyUserAdvertDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.AdvertName).ToList());
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAdvert>>(_companyUserAdvertDal.GetDeletedAll().OrderBy(s => s.AdvertName).ToList());
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<CompanyUserAdvert> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);


            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<CompanyUserAdvert>(_companyUserAdvertDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<CompanyUserAdvert>(_companyUserAdvertDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }

        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserAdvertDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            var user = _userService.GetById(userAdminDTO.UserId);

            if (userIsAdmin.Data == null && user.Code == UserCode.CompanyUser)
            {
                return new SuccessDataResult<List<CompanyUserAdvertDTO>>(_companyUserAdvertDal.GetAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.AdvertName).ToList());
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAdvertDTO>>(_companyUserAdvertDal.GetAllDTO().OrderBy(s => s.AdvertName).ToList());
            }

        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserAdvertDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            var user = _userService.GetById(userAdminDTO.UserId);

            if (userIsAdmin.Data == null && user.Code == UserCode.CompanyUser)
            {
                return new SuccessDataResult<List<CompanyUserAdvertDTO>>(_companyUserAdvertDal.GetDeletedAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.AdvertName).ToList());
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAdvertDTO>>(_companyUserAdvertDal.GetDeletedAllDTO().OrderBy(s => s.AdvertName).ToList());
            }

        }

        public IResult DeleteImage(CompanyUserAdvert companyUserAdvert)
        {
            if (companyUserAdvert == null)
            {
                return new ErrorDataResult<CompanyUserAdvert>(Messages.ImageNotFound);
            }

            string fullImagePath = _environment.WebRootPath + "\\uploads\\images\\" + companyUserAdvert.UserId + "\\" + companyUserAdvert.AdvertImageName;

            if (System.IO.File.Exists(fullImagePath))
            {
                System.IO.File.Delete(fullImagePath);
            }

            string fullThumbImagePath = _environment.WebRootPath + "\\uploads\\images\\" + companyUserAdvert.UserId + "\\thumbs\\" + companyUserAdvert.AdvertImageName;

            if (System.IO.File.Exists(fullThumbImagePath))
            {
                System.IO.File.Delete(fullThumbImagePath);

            }

            companyUserAdvert.AdvertImagePath = "https://localhost:7088/" + "/uploads/images/common/";
            companyUserAdvert.AdvertImageName = "noImage.jpg";

            Update(companyUserAdvert);

            return new SuccessResult();
        }

        //Business Rules
        private IResult IsNameExist(string entityName)
        {
            var result = _companyUserAdvertDal.GetAll(c => c.AdvertName.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.CityNameAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
