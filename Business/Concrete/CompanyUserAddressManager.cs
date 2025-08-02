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
        public async Task<IResult> Add(CompanyUserAddress companyUserAddress)
        {
            if (_userService.GetById(companyUserAddress.UserId) == null)
            {

                return  new ErrorResult(Messages.PermissionError);
            }

            IResult result = await BusinessRules.Run(IsNameExist(companyUserAddress.AddressDetail));

            if (result != null)
            {
                return result;
            }
            await _companyUserAddressDal.AddAsync(companyUserAddress);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin,user")]
        [ValidationAspect(typeof(CompanyUserAddressValidator))]
        [CacheRemoveAspect()]
        public async Task<IResult> Update(CompanyUserAddress companyUserAddress)
        {
            if (_userService.GetById(companyUserAddress.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }

            await _companyUserAddressDal.UpdateAsync(companyUserAddress);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin,user")]
        [CacheRemoveAspect()]
        public async Task<IResult> Delete(CompanyUserAddress companyUserAddress)
        {
            if (_userService.GetById(companyUserAddress.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _companyUserAddressDal.Delete(companyUserAddress);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(CompanyUserAddress companyUserAddress)
        {
            await _companyUserAddressDal.Terminate(companyUserAddress);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        [SecuredOperation("admin,user")]
        //[CacheAspect]
        public async Task<IDataResult<List<CompanyUserAddress>>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAddress>>(await _companyUserAddressDal.GetAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAddress>>(await _companyUserAddressDal.GetAll());
            }
        }

        [SecuredOperation("admin,user")]
        //[CacheAspect]
        public async Task<IDataResult<List<CompanyUserAddress>>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAddress>>(await _companyUserAddressDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAddress>>(await _companyUserAddressDal.GetDeletedAll());
            }
        }


        [SecuredOperation("admin,user")]
        //[CacheAspect]
        public async Task<IDataResult<CompanyUserAddress?>> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<CompanyUserAddress?>(await _companyUserAddressDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<CompanyUserAddress?>(await _companyUserAddressDal.Get(c => c.Id == userAdminDTO.Id));
            }

            
        }

        //DTO
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUserAddressDTO>>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            var allDtos = await _companyUserAddressDal.GetAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAddressDTO>>(allDtos.OrderBy(o => o.CompanyUserName).ToList().Where(c => c.UserId == userAdminDTO.UserId).OrderBy(o=>o.CompanyUserName).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAddressDTO>>(allDtos.OrderBy(o => o.CompanyUserName).ToList().ToList(), Messages.SuccessListed);
            }
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<CompanyUserAddressDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            var allDtos = await _companyUserAddressDal.GetDeletedAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserAddressDTO>>(allDtos.OrderBy(o => o.CompanyUserName).ToList().Where(c => c.UserId == userAdminDTO.UserId).OrderBy(o => o.CompanyUserName).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserAddressDTO>>(allDtos.OrderBy(o => o.CompanyUserName).ToList().OrderBy(o => o.CompanyUserName).ToList(), Messages.SuccessListed);
            }
        }

        //Business Rules
        private async Task<IResult> IsNameExist(string entityName)
        {
            var result = await _companyUserAddressDal.GetAll(c => c.AddressDetail == entityName);

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
