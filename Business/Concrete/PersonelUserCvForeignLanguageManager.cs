using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
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
    public class PersonelUserCvForeignLanguageManager : IPersonelUserCvForeignLanguageService
    {
        IPersonelUserCvForeignLanguageDal _cvForeignLanguageDal;
        IUserService _userService;

        public PersonelUserCvForeignLanguageManager(IPersonelUserCvForeignLanguageDal cvforeignLanguageDal, IUserService userService)
        {
            _cvForeignLanguageDal = cvforeignLanguageDal;
            _userService = userService;

        }
        [SecuredOperation("admin,user")]
        public IResult Add(PersonelUserCvForeignLanguage cvforeignLanguage)
        {
            _cvForeignLanguageDal.Add(cvforeignLanguage);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Update(PersonelUserCvForeignLanguage cvforeignLanguage)
        {
            _cvForeignLanguageDal.Update(cvforeignLanguage);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(PersonelUserCvForeignLanguage cvforeignLanguage)
        {
            _cvForeignLanguageDal.Delete(cvforeignLanguage);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvForeignLanguage>> GetAll(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvForeignLanguage>>(_cvForeignLanguageDal.GetAll(c => c.UserId == userId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvForeignLanguage>>(_cvForeignLanguageDal.GetAll());
            }
            
        }
        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserCvForeignLanguage> GetById(int foreignLanguageId)
        {
            return new SuccessDataResult<PersonelUserCvForeignLanguage>(_cvForeignLanguageDal.Get(f=> f.Id == foreignLanguageId));
        }

        public IDataResult<List<PersonelUserCvForeignLanguageDTO>> GetCvForeignLanguageDTO(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvForeignLanguageDTO>>(_cvForeignLanguageDal.GetPersonelUserCvForeignLanguageDTO().FindAll(c => c.UserId == userId), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvForeignLanguageDTO>>(_cvForeignLanguageDal.GetPersonelUserCvForeignLanguageDTO(), Messages.CompaniesListed);
            }
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvForeignLanguageDTO>> GetCvForeignLanguageDeletedDTO(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvForeignLanguageDTO>>(_cvForeignLanguageDal.GetPersonelUserCvForeignLanguageDeletedDTO().FindAll(c => c.UserId == userId), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvForeignLanguageDTO>>(_cvForeignLanguageDal.GetPersonelUserCvForeignLanguageDeletedDTO(), Messages.CompaniesListed);
            }
        }
    }
}
