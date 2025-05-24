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
            var personelUser = _personelUserService.GetByAdminId(userAdminDTO);

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCv>>(_cvDal.GetAll(c => c.PersonelUserId == personelUser.Data.Id));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCv>>(_cvDal.GetAll());
            }
            
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCv>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var personelUser = _personelUserService.GetByAdminId(userAdminDTO);

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCv>>(_cvDal.GetDeletedAll(c => c.PersonelUserId == personelUser.Data.Id));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCv>>(_cvDal.GetDeletedAll());
            }

        }
        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserCv> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            var personelUser = _personelUserService.GetByAdminId(userAdminDTO);


            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<PersonelUserCv>(_cvDal.Get(c => c.Id == userAdminDTO.Id && c.PersonelUserId == personelUser.Data.Id));
            }
            else
            {
                return new SuccessDataResult<PersonelUserCv>(_cvDal.Get(c => c.Id == userAdminDTO.Id));
            }
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
                return new SuccessDataResult<List<PersonelUserCvDTO>>(_cvDal.GetAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvDTO>>(_cvDal.GetAllDTO().OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }

        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvDTO>>(_cvDal.GetDeletedAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvDTO>>(_cvDal.GetDeletedAllDTO().OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }

        }

    }
}
