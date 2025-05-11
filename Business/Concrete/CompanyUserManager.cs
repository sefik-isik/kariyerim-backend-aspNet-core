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
            IResult result = BusinessRules.Run(IsCompanyNameExist(companyUser.CompanyUserName),IsTaxNumberExist(companyUser.TaxNumber));
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
        public IDataResult<List<CompanyUser>> GetAll(UserAdminDTO userAdminDTO) 
        
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUser>>(_companyUserDal.GetAll(c => c.Id == userAdminDTO.Id), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUser>>(_companyUserDal.GetAll(), Messages.CompaniesListed);
            }
        }

        [SecuredOperation("admin")]
        public IDataResult<List<CompanyUser>> GetDeletedAll(UserAdminDTO userAdminDTO)

        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUser>>(_companyUserDal.GetDeletedAll(c => c.Id == userAdminDTO.Id), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUser>>(_companyUserDal.GetDeletedAll(), Messages.CompaniesListed);
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
        public IDataResult<CompanyUser> GetById(int id)
        {
            return new SuccessDataResult<CompanyUser>(_companyUserDal.Get(c => c.Id == id));

        }

        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserDTO>>((_companyUserDal.GetAllDTO().FindAll(c => c.Id == userAdminDTO.Id)), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserDTO>>((_companyUserDal.GetAllDTO()), Messages.CompaniesListed);
            }
            

        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<CompanyUserDTO>> GetAllDeletedDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<CompanyUserDTO>>((_companyUserDal.GetAllDeletedDTO().FindAll(c => c.Id == userAdminDTO.Id)), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<CompanyUserDTO>>((_companyUserDal.GetAllDeletedDTO()), Messages.CompaniesListed);
            }


        } 


        //Business Rules
        private IResult IsCompanyNameExist(string companyName)
        {
            var result = _companyUserDal.GetAll(c => c.CompanyUserName.ToLower() == companyName.ToLower()).Any();

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