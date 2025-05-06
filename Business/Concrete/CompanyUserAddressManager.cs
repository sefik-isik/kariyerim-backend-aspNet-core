using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Status;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CompanyUserAddressManager : ICompanyUserAddressService
    {
        ICompanyUserAddressDal _companyUserAddressDal;
        IUserService _userService;

        public CompanyUserAddressManager(ICompanyUserAddressDal companyUserAddressDal, IUserService userService)
        {
            _companyUserAddressDal = companyUserAddressDal;
            _userService = userService;

        }
        [SecuredOperation("admin,user")]
        [ValidationAspect(typeof(CompanyUserAddressValidator))]
        [CacheRemoveAspect()]
        public IResult Add(CompanyUserAddress companyUserAddress)
        {
            _companyUserAddressDal.Add(companyUserAddress);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        [ValidationAspect(typeof(CompanyUserAddressValidator))]
        [CacheRemoveAspect()]
        public IResult Update(CompanyUserAddress companyUserAddress)
        {
            _companyUserAddressDal.Update(companyUserAddress);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        [CacheRemoveAspect()]
        public IResult Delete(CompanyUserAddress companyUserAddress)
        {
            _companyUserAddressDal.Delete(companyUserAddress);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        //[CacheAspect]
        public IDataResult<List<CompanyUserAddress>> GetAll(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAddress>>(_companyUserAddressDal.GetAll(c => c.UserId == userId));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAddress>>(_companyUserAddressDal.GetAll());
            }
        }
        
        [SecuredOperation("admin")]
        //[CacheAspect]
        public IDataResult<List<CompanyUserAddress>> GetDeletedAll(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAddress>>(_companyUserAddressDal.GetDeletedAll(c => c.UserId == userId));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAddress>>(_companyUserAddressDal.GetDeletedAll());
            }
        }


        [SecuredOperation("admin,user")]
        //[CacheAspect]
        public IDataResult<CompanyUserAddress> GetById(int companyUserAddressId)
        {
            return new SuccessDataResult<CompanyUserAddress>(_companyUserAddressDal.Get(c => c.Id == companyUserAddressId));
        }

        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserAddressDTO>> GetAllDTO(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAddressDTO>>(_companyUserAddressDal.GetAllDTO().FindAll(c=>c.UserId==userId));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAddressDTO>>(_companyUserAddressDal.GetAllDTO());
            }
            
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserAddressDTO>> GetAllDeletedDTO(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAddressDTO>>(_companyUserAddressDal.GetAllDeletedDTO().FindAll(c => c.UserId == userId));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAddressDTO>>(_companyUserAddressDal.GetAllDeletedDTO());
            }

        }
    }
}
