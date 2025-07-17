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
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CompanyUserManager : ICompanyUserService
    {
        ICompanyUserDal _companyUserDal;
        IUserService _userService;

        public CompanyUserManager(
            ICompanyUserDal companyUserDal, 
            IUserService userService
            ) {
            _companyUserDal = companyUserDal; 
            _userService = userService;
        }

        [SecuredOperation("admin,user")]
        [ValidationAspect(typeof(CompanyUserValidator))]
        [CacheRemoveAspect()]
        public IResult Add(CompanyUser companyUser)
        {
            IResult result = BusinessRules.Run(
                IsCompanyNameExist(companyUser.CompanyUserName),
                IsTaxNumberExist(companyUser.TaxNumber), 
                IsWebAddressExist(companyUser.WebAddress));
            if (result != null)
            {
                return result;
            }
            if (_userService.GetById(companyUser.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _companyUserDal.AddAsync(companyUser);
            return new SuccessResult(Messages.SuccessCompanyAdded);
        }

        [SecuredOperation("admin,user")]
        [ValidationAspect(typeof(CompanyUserValidator))]
        [CacheRemoveAspect()]
        public IResult Update(CompanyUser companyUser)
        {
            if (_userService.GetById(companyUser.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _companyUserDal.UpdateAsync(companyUser);
            return new SuccessResult(Messages.SuccessCompanyUpdated);
        }

        [SecuredOperation("admin,user")]
        [CacheRemoveAspect()]
        public IResult Delete(CompanyUser companyUser)
        {
            if (_userService.GetById(companyUser.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _companyUserDal.Delete(companyUser);
            return new SuccessResult(Messages.SuccessCompanyDeleted);
        }

        [SecuredOperation("admin")]
        public IResult Terminate(CompanyUser companyUser)
        {
            _companyUserDal.TerminateSubDatas(companyUser.Id);
            _companyUserDal.Terminate(companyUser);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUser>> GetAll(UserAdminDTO userAdminDTO) 
        
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUser>>(_companyUserDal.GetAll(c => c.UserId == userAdminDTO.Id).OrderBy(s => s.CompanyUserName).ToList(), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUser>>(_companyUserDal.GetAll().OrderBy(s => s.CompanyUserName).ToList(), Messages.CompaniesListed);
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUser>> GetDeletedAll(UserAdminDTO userAdminDTO)

        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUser>>(_companyUserDal.GetDeletedAll(c => c.UserId == userAdminDTO.Id).OrderBy(s => s.CompanyUserName).ToList(), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUser>>(_companyUserDal.GetDeletedAll().OrderBy(s => s.CompanyUserName).ToList(), Messages.CompaniesListed);
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<CompanyUser> GetByAdminId(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<CompanyUser>(_companyUserDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId), Messages.CompanyListed);
            }
            else
            {
                return new SuccessDataResult<CompanyUser>(_companyUserDal.Get(c => c.Id == userAdminDTO.Id), Messages.CompanyListed);
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<CompanyUser> GetById(string id)
        {
            return new SuccessDataResult<CompanyUser>(_companyUserDal.Get(c => c.Id == id));

        }

        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            var user = _userService.GetById(userAdminDTO.UserId);

            if (userIsAdmin.Data == null && user.Code == UserCode.CompanyUser)
            {
                return new SuccessDataResult<List<CompanyUserDTO>>((_companyUserDal.GetAllDTO().FindAll(c => c.UserId == userAdminDTO.Id).OrderBy(s => s.Email).ToList()), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserDTO>>((_companyUserDal.GetAllDTO().OrderBy(s => s.Email).ToList()), Messages.CompaniesListed);
            }
            
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            var user = _userService.GetById(userAdminDTO.UserId);

            if (userIsAdmin.Data == null && user.Code == UserCode.CompanyUser)
            {
                return new SuccessDataResult<List<CompanyUserDTO>>((_companyUserDal.GetDeletedAllDTO().FindAll(c => c.UserId == userAdminDTO.Id).OrderBy(s => s.Email).ToList()), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserDTO>>((_companyUserDal.GetDeletedAllDTO().OrderBy(s => s.Email).ToList()), Messages.CompaniesListed);
            }


        } 


        //Business Rules
        private IResult IsCompanyNameExist(string companyName)
        {
            var result = _companyUserDal.GetAll(c => c.CompanyUserName.ToLower() == companyName.ToLower() && c.CompanyUserName  != "-").Any();

            if (result)
            {
                return new ErrorResult(Messages.CompanyNameAlreadyExist);
            }
            return new SuccessResult();
        }

        private IResult IsTaxNumberExist(string taxNumber)
        {
            var result = _companyUserDal.GetAll(c => c.TaxNumber.ToLower() == taxNumber.ToLower() && c.TaxNumber != "-").Any();

            if (result)
            {
                return new ErrorResult(Messages.TaxNumberAlreadyExist);
            }
            return new SuccessResult();
        }

        private IResult IsWebAddressExist(string webAddress)
        {
            var result = _companyUserDal.GetAll(c => c.WebAddress.ToLower() == webAddress.ToLower() && c.WebAddress != "-").Any();

            if (result)
            {
                return new ErrorResult(Messages.TaxNumberAlreadyExist);
            }
            return new SuccessResult();
        }


    }
}