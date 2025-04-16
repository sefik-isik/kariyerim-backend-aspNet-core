using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;
using Core.Utilities.Security.Status;
using Core.Entities.Concrete;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
    public class PersonelUserManager : IPersonelUserService
    {
        IPersonelUserDal _personelUserDal;
        IUserService _userService;

        public PersonelUserManager(IPersonelUserDal personelUserDal, IUserService userService)
        {
            _personelUserDal = personelUserDal;
            _userService = userService;

        }
        [SecuredOperation("admin,user")]
        public IResult Add(PersonelUser personelUser)
        {
            _personelUserDal.Add(personelUser);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Update(PersonelUser personelUser)
        {
            _personelUserDal.Update(personelUser);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(PersonelUser personelUser)
        {
            _personelUserDal.Delete(personelUser);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUser>> GetAll(int userId) => _userService.IsAdmin(UserStatus.Admin, userId).Data == null 
            ? new SuccessDataResult<List<PersonelUser>>(_personelUserDal.GetAll(p=>p.UserId==userId)) 
            : new SuccessDataResult<List<PersonelUser>>(_personelUserDal.GetAll())


;        public IDataResult<PersonelUser> GetById(int userId) => new SuccessDataResult<PersonelUser>(_personelUserDal.Get(u => u.Id == userId));

        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserDTO>> GetAllDTO(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserDTO>>(_personelUserDal.GetAllDTO().FindAll(c => c.UserId == userId), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserDTO>>(_personelUserDal.GetAllDTO(), Messages.CompaniesListed);
            }

        }
    }
}
