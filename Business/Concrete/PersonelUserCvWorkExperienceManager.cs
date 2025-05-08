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
    public class PersonelUserCvWorkExperienceManager : IPersonelUserCvWorkExperienceService
    {
        IPersonelUserCvWorkExperienceDal _cvWorkExperienceDal;
        IUserService _userService;
        IPersonelUserService _personelUserService;
        IPersonelUserCvService _personelUserCvService;

        public PersonelUserCvWorkExperienceManager(IPersonelUserCvWorkExperienceDal cvWorkExperienceDal, 
            IUserService userService,IPersonelUserService personelUserService, IPersonelUserCvService personelUserCvService)
        {
            _cvWorkExperienceDal = cvWorkExperienceDal;
            _userService = userService;
            _personelUserService = personelUserService;
            _personelUserCvService = personelUserCvService;

        }
        [SecuredOperation("admin,user")]
        public IResult Add(PersonelUserCvWorkExperience cvWorkExperience)
        {
            _cvWorkExperienceDal.Add(cvWorkExperience); 
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Update(PersonelUserCvWorkExperience cvWorkExperience)
        {
            _cvWorkExperienceDal.Update(cvWorkExperience);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(PersonelUserCvWorkExperience cvWorkExperience)
        {
            _cvWorkExperienceDal.Delete(cvWorkExperience);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvWorkExperience>> GetAll(UserAdminDTO userAdminDTO)
        {
            PersonelUser personelUser = (PersonelUser)_personelUserService.GetByUserId(userAdminDTO.UserId);

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperience>>(_cvWorkExperienceDal.GetAll(c => c.PersonelUserId == personelUser.Id));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperience>>(_cvWorkExperienceDal.GetAll());
            }
            
        }
        [SecuredOperation("admin")]
        public IDataResult<List<PersonelUserCvWorkExperience>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            PersonelUser personelUser = (PersonelUser)_personelUserService.GetByUserId(userAdminDTO.UserId);

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperience>>(_cvWorkExperienceDal.GetDeletedAll(c => c.PersonelUserId == personelUser.Id));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperience>>(_cvWorkExperienceDal.GetDeletedAll());
            }

        }
        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserCvWorkExperience> GetById(int id)
        {
            return new SuccessDataResult<PersonelUserCvWorkExperience>(_cvWorkExperienceDal.Get(c=> c.Id == id));
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvWorkExperienceDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperienceDTO>>(_cvWorkExperienceDal.GetAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperienceDTO>>(_cvWorkExperienceDal.GetAllDTO(), Messages.CompaniesListed);
            }

        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvWorkExperienceDTO>> GetAllDeletedDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperienceDTO>>(_cvWorkExperienceDal.GetAllDeletedDTO().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperienceDTO>>(_cvWorkExperienceDal.GetAllDeletedDTO(), Messages.CompaniesListed);
            }

        }

    }
}
