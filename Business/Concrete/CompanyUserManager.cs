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
    public class CompanyUserManager : ICompanyUserService
    {
        ICompanyUserDal _companyUserDal;
        IUserService _userService;

        public CompanyUserManager(ICompanyUserDal companyUserDal, IUserService userService) {
            _companyUserDal = companyUserDal; 
            _userService = userService;
        }

        [SecuredOperation("admin,user")]
        [ValidationAspect(typeof(CompanyUserValidator))]
        [CacheRemoveAspect()]
        public IResult Add(CompanyUser companyUser)
        {
            IResult result = BusinessRules.Run(IsCompanyNameExist(companyUser.CompanyName),IsTaxNumberExist(companyUser.TaxNumber));
            if (result != null)
            {
                return result;
            }
            _companyUserDal.Add(companyUser);
            return new SuccessResult(Messages.SuccessCompanyAdded);
        }

        [SecuredOperation("admin,user")]
        [ValidationAspect(typeof(CompanyUserValidator))]
        [CacheRemoveAspect()]
        public IResult Update(CompanyUser companyUser)
        {
            _companyUserDal.Update(companyUser);
            return new SuccessResult(Messages.SuccessCompanyUpdated);
        }

        [SecuredOperation("admin,user")]
        [CacheRemoveAspect()]
        public IResult Delete(CompanyUser companyUser)
        {
            _companyUserDal.Delete(companyUser);
            return new SuccessResult(Messages.SuccessCompanyDeleted);
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUser>> GetAll(int userId) 
        
        {
            if (_userService.IsAdmin(UserStatus.Admin, userId).Data == null)
            {
                return new SuccessDataResult<List<CompanyUser>>(_companyUserDal.GetAll(c => c.UserId == userId), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUser>>(_companyUserDal.GetAll(), Messages.CompaniesListed);
            }

        }

        [SecuredOperation("admin,user")]
        public IDataResult<CompanyUser> GetById(int companyId)
        {
            return new SuccessDataResult<CompanyUser>(_companyUserDal.Get(c => c.Id == companyId), Messages.CompanyListed);
        }

        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserDTO>> GetCompanyUserDTO(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserDTO>>((_companyUserDal.GetCompanyDTO().FindAll(c => c.UserId == userId)), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserDTO>>(_companyUserDal.GetCompanyDTO(), Messages.CompaniesListed);
            }

        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserDTO>> GetCompanyUserDeletedDTO(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserDTO>>((_companyUserDal.GetCompanyDeletedDTO().FindAll(c => c.UserId == userId)), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserDTO>>(_companyUserDal.GetCompanyDeletedDTO(), Messages.CompaniesListed);
            }

        }

        //Business Rules
        private IResult IsCompanyNameExist(string companyName)
        {
            var result = _companyUserDal.GetAll(c => c.CompanyName.ToLower() == companyName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.CompanyNameAlreadyExist);
            }
            return new SuccessResult();
        }

        private IResult IsTaxNumberExist(string taxNumber)
        {
            var result = _companyUserDal.GetAll(c => c.TaxNumber.ToLower() == taxNumber.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.TaxNumberAlreadyExist);
            }
            return new SuccessResult();
        }


    }
}