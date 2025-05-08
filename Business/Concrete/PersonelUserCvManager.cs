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
    public class PersonelUserCvManager : IPersonelUserCvService
    {
        IPersonelUserCvDal _cvDal;
        IUserService _userService;
        IPersonelUserService _personelUserService;

        public PersonelUserCvManager(IPersonelUserCvDal cvDal, IUserService userService, IPersonelUserService personelUserService)
        {
            _cvDal = cvDal;
            _userService = userService;
            _personelUserService = personelUserService;

        }
        [SecuredOperation("admin,user")]
        public IResult Add(PersonelUserCv cv)
        {
            _cvDal.Add(cv);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Update(PersonelUserCv cv)
        {
            _cvDal.Update(cv);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(PersonelUserCv cv)
        {
            _cvDal.Delete(cv);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCv>> GetAll(UserAdminDTO userAdminDTO)
        {
            PersonelUser personelUser = (PersonelUser)_personelUserService.GetByUserId(userAdminDTO.UserId);

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCv>>(_cvDal.GetAll(c => c.PersonelUserId == personelUser.Id));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCv>>(_cvDal.GetAll());
            }
            
        }
        [SecuredOperation("admin")]
        public IDataResult<List<PersonelUserCv>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            PersonelUser personelUser = (PersonelUser)_personelUserService.GetByUserId(userAdminDTO.UserId);

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCv>>(_cvDal.GetDeletedAll(c => c.PersonelUserId == personelUser.Id));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCv>>(_cvDal.GetDeletedAll());
            }

        }
        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserCv> GetById(int id)
        {
            return new SuccessDataResult<PersonelUserCv>(_cvDal.Get(u=>u.Id== id));
        }

        [SecuredOperation("admin")]
        public PersonelUserCv GetPersonelUserCv(int cvId)
        {
            return _cvDal.Get(c => c.Id == cvId);
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvDTO>>(_cvDal.GetAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvDTO>>(_cvDal.GetAllDTO(), Messages.CompaniesListed);
            }

        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvDTO>> GetAllDeletedDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvDTO>>(_cvDal.GetAllDeletedDTO().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvDTO>>(_cvDal.GetAllDeletedDTO(), Messages.CompaniesListed);
            }

        }

    }
}
