using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Status;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        ICompanyUserService _companyUserService;

        public CompanyUserImageManager(ICompanyUserImageDal companyUserImageDal, IUserService userService, ICompanyUserService companyUserService)
        {
            _companyUserImageDal = companyUserImageDal;
            _userService = userService;
            _companyUserService = companyUserService;
        }
        
        [SecuredOperation("admin,user")]
        public IResult Add(CompanyUserImage companyUserImage)
        {
            _companyUserImageDal.Add(companyUserImage);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Update(CompanyUserImage companyUserImage)
        {
            _companyUserImageDal.Update(companyUserImage);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(CompanyUserImage companyUserImage)
        {
            _companyUserImageDal.Delete(companyUserImage);
            return new SuccessResult();
        }
        
        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserImage>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            var companyUser = _companyUserService.GetByAdminId(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserImage>>(_companyUserImageDal.GetAll(c => c.CompanyUserId == companyUser.Data.Id));
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

            var companyUser = _companyUserService.GetByAdminId(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserImage>>(_companyUserImageDal.GetDeletedAll(c => c.CompanyUserId == companyUser.Data.Id));
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

            var companyUser = _companyUserService.GetByAdminId(userAdminDTO);


            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<CompanyUserImage>(_companyUserImageDal.Get(c => c.Id == userAdminDTO.Id && c.CompanyUserId == companyUser.Data.Id));
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
                return new SuccessDataResult<List<CompanyUserImageDTO>>(_companyUserImageDal.GetAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserImageDTO>>(_companyUserImageDal.GetAllDTO());
            }
            
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserImageDTO>> GetAllDeletedDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserImageDTO>>(_companyUserImageDal.GetAllDeletedDTO().FindAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserImageDTO>>(_companyUserImageDal.GetAllDeletedDTO());
            }

        }
    }
}
