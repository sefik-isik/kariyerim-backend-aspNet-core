using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Concrete;
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
    public class PersonelUserCvAboutManager : IPersonelUserCvAboutService
    {
        IPersonelUserCvAboutDal _cvAboutDal;
        IUserService _userService;

        public PersonelUserCvAboutManager(IPersonelUserCvAboutDal cvAboutDal, IUserService userService)
        {
            this._cvAboutDal = cvAboutDal;
            _userService = userService;

        }
        [SecuredOperation("admin,user")]
        public IResult Add(PersonelUserCvAbout cvAbout)
        {
            _cvAboutDal.Add(cvAbout);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Update(PersonelUserCvAbout cvAbout)
        {
            _cvAboutDal.Update(cvAbout);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(PersonelUserCvAbout cvAbout)
        {
            _cvAboutDal.Delete(cvAbout);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvAbout>> GetAll(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvAbout>>(_cvAboutDal.GetAll(c => c.UserId == userId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvAbout>>(_cvAboutDal.GetAll());
            }

        }
        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserCvAbout> GetById(int cvAboutId)
        {
            return new SuccessDataResult<PersonelUserCvAbout>(_cvAboutDal.Get(c=> c.Id == cvAboutId));
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvAboutDTO>> GetCvAboutDTO(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvAboutDTO>>(_cvAboutDal.GetPersonelUserCvAboutDTO().FindAll(c => c.UserId == userId), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvAboutDTO>>(_cvAboutDal.GetPersonelUserCvAboutDTO(), Messages.CompaniesListed);
            }
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvAboutDTO>> GetCvAboutDeletedDTO(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvAboutDTO>>(_cvAboutDal.GetPersonelUserCvAboutDeletedDTO().FindAll(c => c.UserId == userId), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvAboutDTO>>(_cvAboutDal.GetPersonelUserCvAboutDeletedDTO(), Messages.CompaniesListed);
            }

        }
    }
}
