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
        }
        [SecuredOperation("admin,user")]
        [ValidationAspect(typeof(CompanyUserAddressValidator))]
        [CacheRemoveAspect()]
        public IResult Add(CompanyUserAddress companyUserAddress)
        {
            if (_userService.GetById(companyUserAddress.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }

            IResult result = BusinessRules.Run(IsNameExist(companyUserAddress.AddressDetail));

            if (result != null)
            {
                return result;
            }
            _companyUserAddressDal.AddAsync(companyUserAddress);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        [ValidationAspect(typeof(CompanyUserAddressValidator))]
        [CacheRemoveAspect()]
        public IResult Update(CompanyUserAddress companyUserAddress)
        {
            if (_userService.GetById(companyUserAddress.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }

            _companyUserAddressDal.UpdateAsync(companyUserAddress);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        [CacheRemoveAspect()]
        public IResult Delete(CompanyUserAddress companyUserAddress)
        {
            if (_userService.GetById(companyUserAddress.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _companyUserAddressDal.Delete(companyUserAddress);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        public IResult Terminate(CompanyUserAddress companyUserAddress)
        {
            _companyUserAddressDal.Terminate(companyUserAddress);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        //[CacheAspect]
        public IDataResult<List<CompanyUserAddress>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAddress>>(_companyUserAddressDal.GetAll(c => c.UserId == userAdminDTO.UserId));
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

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAddress>>(_companyUserAddressDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId));
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

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<CompanyUserAddress>(_companyUserAddressDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
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
        public IDataResult<List<CompanyUserAddressDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAddressDTO>>(_companyUserAddressDal.GetDeletedAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList());
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAddressDTO>>(_companyUserAddressDal.GetDeletedAllDTO().OrderBy(s => s.Email).ToList());
            }

        }

        //Business Rules
        private IResult IsNameExist(string entityName)
        {
            var result = _companyUserAddressDal.GetAll(c => c.AddressDetail == entityName).Any();

            if (result)
            {
                return new ErrorResult(Messages.CityNameAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
