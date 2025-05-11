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
    public class PersonelUserCvEducationManager : IPersonelUserCvEducationService
    {
        IPersonelUserCvEducationDal _cvEducationDal;
        IUserService _userService;
        IPersonelUserService _personelUserService;
        IPersonelUserCvService _personelUserCvService;

        public PersonelUserCvEducationManager(IPersonelUserCvEducationDal cvEducationDal, IUserService userService, IPersonelUserService personelUserService, IPersonelUserCvService personelUserCvService)
        {
            _cvEducationDal = cvEducationDal;
            _userService = userService;
            _personelUserService = personelUserService;
            _personelUserCvService = personelUserCvService;

        }
        [SecuredOperation("admin,user")]
        public IResult Add(PersonelUserCvEducation cvEducation)
        {
            _cvEducationDal.Add(cvEducation);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Update(PersonelUserCvEducation cvEducation)
        {
            _cvEducationDal.Update(cvEducation);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(PersonelUserCvEducation cvEducation)
        {
            _cvEducationDal.Delete(cvEducation);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvEducation>> GetAll(UserAdminDTO userAdminDTO)
        {
            var personelUser = _personelUserService.GetByAdminId(userAdminDTO);

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvEducation>>(_cvEducationDal.GetAll(c => c.PersonelUserId == personelUser.Data.Id));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvEducation>>(_cvEducationDal.GetAll());
            }
            
        }
        [SecuredOperation("admin")]
        public IDataResult<List<PersonelUserCvEducation>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var personelUser = _personelUserService.GetByAdminId(userAdminDTO);

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvEducation>>(_cvEducationDal.GetDeletedAll(c => c.PersonelUserId == personelUser.Data.Id));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvEducation>>(_cvEducationDal.GetDeletedAll());
            }

        }
           
        [SecuredOperation("admin")]
        public IDataResult<List<PersonelUserCvEducation>> GetPersonelUser(UserAdminDTO userAdminDTO)
        {

            var personelUser = _personelUserService.GetByAdminId(userAdminDTO);

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);


            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvEducation>>(_cvEducationDal.GetDeletedAll(c => c.PersonelUserId == personelUser.Data.Id));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvEducation>>(_cvEducationDal.GetDeletedAll());
            }

        }


        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserCvEducation> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            var personelUser = _personelUserService.GetByAdminId(userAdminDTO);


            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<PersonelUserCvEducation>(_cvEducationDal.Get(c => c.Id == userAdminDTO.Id && c.PersonelUserId == personelUser.Data.Id));
            }
            else
            {
                return new SuccessDataResult<PersonelUserCvEducation>(_cvEducationDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }


        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvEducationDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvEducationDTO>>(_cvEducationDal.GetAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvEducationDTO>>(_cvEducationDal.GetAllDTO(), Messages.CompaniesListed);
            }

        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvEducationDTO>> GetAllDeletedDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvEducationDTO>>(_cvEducationDal.GetAllDeletedDTO().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvEducationDTO>>(_cvEducationDal.GetAllDeletedDTO(), Messages.CompaniesListed);
            }

        }
    }
}
