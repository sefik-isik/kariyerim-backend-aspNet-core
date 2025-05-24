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
using Core.Utilities.Business;

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
            IResult result = BusinessRules.Run(IsPersonelUserExist(personelUser.UserId));

            if (result != null)
            {
                return result;
            }

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
        public IDataResult<List<PersonelUser>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUser>>(_personelUserDal.GetAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.UserId).ToList());
            }
            else
            {
                return new SuccessDataResult<List<PersonelUser>>(_personelUserDal.GetAll().OrderBy(s => s.UserId).ToList());
            }

        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUser>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUser>>(_personelUserDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.UserId).ToList());
            }
            else
            {
                return new SuccessDataResult<List<PersonelUser>>(_personelUserDal.GetDeletedAll().OrderBy(s => s.UserId).ToList());
            }

        }

        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUser> GetByAdminId(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<PersonelUser>(_personelUserDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId), Messages.CompanyListed);
            }
            else
            {
                return new SuccessDataResult<PersonelUser>(_personelUserDal.Get(c => c.Id == userAdminDTO.Id), Messages.CompanyListed);
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUser> GetById(int id)
        {
            return new SuccessDataResult<PersonelUser>(_personelUserDal.Get(c => c.Id == id));

        }

        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserDTO>>(_personelUserDal.GetAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserDTO>>(_personelUserDal.GetAllDTO().OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }

        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserDTO>>(_personelUserDal.GetDeletedAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserDTO>>(_personelUserDal.GetDeletedAllDTO().OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }

        }

        //Business Rules
        private IResult IsPersonelUserExist(int id)
        {
            var result = _personelUserDal.GetAll(c => c.UserId == id).Any();

            if (result)
            {
                return new ErrorResult(Messages.PersonelUserAlreadyExist);
            }
            return new SuccessResult();
        }

    }
}
