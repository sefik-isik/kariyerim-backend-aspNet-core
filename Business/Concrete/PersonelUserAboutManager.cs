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
    public class PersonelUserAboutManager : IPersonelUserAboutService
    {
        IPersonelUserAboutDal _cvAboutDal;
        IUserService _userService;

        public PersonelUserAboutManager(IPersonelUserAboutDal cvAboutDal, IUserService userService)
        {
            this._cvAboutDal = cvAboutDal;
            _userService = userService;

        }
        [SecuredOperation("admin,user")]
        public IResult Add(PersonelUserAbout cvAbout)
        {
            _cvAboutDal.Add(cvAbout);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Update(PersonelUserAbout cvAbout)
        {
            _cvAboutDal.Update(cvAbout);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(PersonelUserAbout cvAbout)
        {
            _cvAboutDal.Delete(cvAbout);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserAbout>> GetAll(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserAbout>>(_cvAboutDal.GetAll(c => c.UserId == userId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserAbout>>(_cvAboutDal.GetAll());
            }

        }
        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserAbout> GetById(int cvAboutId)
        {
            return new SuccessDataResult<PersonelUserAbout>(_cvAboutDal.Get(c=> c.Id == cvAboutId));
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserAboutDTO>> GetAllDTO(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserAboutDTO>>(_cvAboutDal.GetAllDTO().FindAll(c => c.UserId == userId), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserAboutDTO>>(_cvAboutDal.GetAllDTO(), Messages.CompaniesListed);
            }
        }

    }
}
