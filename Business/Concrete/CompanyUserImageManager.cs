using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using Core.Utilities.Security.Status;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CompanyUserImageManager : ICompanyUserImageService
    {
        ICompanyUserImageDal _companyUserImageDal;
        IUserService _userService;

        public CompanyUserImageManager(ICompanyUserImageDal companyUserImageDal, IUserService userService)
        {
            _companyUserImageDal = companyUserImageDal;
            _userService = userService;

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
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(CompanyUserImage companyUserImage)
        {
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserImage>> GetAll(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserImage>>(_companyUserImageDal.GetAll(c => c.UserId == userId));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserImage>>(_companyUserImageDal.GetAll());
            }
            
        }
        [SecuredOperation("admin,user")]
        public IDataResult<CompanyUserImage> GetById(int companyUserImageId)
        {
            return new SuccessDataResult<CompanyUserImage>(_companyUserImageDal.Get(c=>c.Id==companyUserImageId));
        }

        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserImageDTO>> GetCompanyUserImageDTO(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserImageDTO>>(_companyUserImageDal.GetCompanyUserImageDTO().FindAll(c => c.UserId == userId));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserImageDTO>>(_companyUserImageDal.GetCompanyUserImageDTO());
            }
            
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserImageDTO>> GetCompanyUserImageDeletedDTO(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserImageDTO>>(_companyUserImageDal.GetCompanyUserImageDeletedDTO().FindAll(c => c.UserId == userId));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserImageDTO>>(_companyUserImageDal.GetCompanyUserImageDeletedDTO());
            }
            
        }

       


    }
}
