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
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CompanyUserAddressManager : ICompanyUserAddressService
    {
        ICompanyUserAddressDal _companyUserAddressDal;
        IUserService _userService;
        ICompanyUserService _companyUserService;

        public CompanyUserAddressManager(ICompanyUserAddressDal companyUserAddressDal, IUserService userService, ICompanyUserService companyUserService)
        {
            _companyUserAddressDal = companyUserAddressDal;
            _userService = userService;
            _companyUserService = companyUserService;
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
        public IDataResult<List<CompanyUserAddress>> GetAll(UserAdminDTO userAdminDTO)
        {
            CompanyUser companyUser = (CompanyUser)_companyUserService.GetByAdminId(userAdminDTO);
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAddress>>(_companyUserAddressDal.GetAll(c => c.CompanyUserId == companyUser.Id));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAddress>>(_companyUserAddressDal.GetAll());
            }
        }

        [SecuredOperation("admin,user")]
        //[CacheAspect]
        public IDataResult<List<CompanyUserAddress>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            var companyUser = _companyUserService.GetByAdminId(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAddress>>(_companyUserAddressDal.GetDeletedAll(c => c.CompanyUserId == companyUser.Data.Id));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAddress>>(_companyUserAddressDal.GetDeletedAll());
            }
        }


        [SecuredOperation("admin,user")]
        //[CacheAspect]
        public IDataResult<CompanyUserAddress> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            var companyUser = _companyUserService.GetByAdminId(userAdminDTO);


            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<CompanyUserAddress>(_companyUserAddressDal.Get(c => c.Id == userAdminDTO.Id && c.CompanyUserId == companyUser.Data.Id));
            }
            else
            {
                return new SuccessDataResult<CompanyUserAddress>(_companyUserAddressDal.Get(c => c.Id == userAdminDTO.Id));
            }

            
        }

        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserAddressDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAddressDTO>>(_companyUserAddressDal.GetAllDTO().FindAll(c=>c.UserId== userAdminDTO.UserId).OrderBy(s => s.Email).ToList());
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAddressDTO>>(_companyUserAddressDal.GetAllDTO().OrderBy(s => s.Email).ToList());
            }
            
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserAddressDTO>> GetAllDeletedDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAddressDTO>>(_companyUserAddressDal.GetAllDeletedDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList());
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAddressDTO>>(_companyUserAddressDal.GetAllDeletedDTO().OrderBy(s => s.Email).ToList());
            }

        }
    }
}
