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
            var personelUser = _personelUserService.GetByAdminId(userAdminDTO);

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperience>>(_cvWorkExperienceDal.GetAll(c => c.PersonelUserId == personelUser.Data.Id));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperience>>(_cvWorkExperienceDal.GetAll());
            }
            
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvWorkExperience>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var personelUser = _personelUserService.GetByAdminId(userAdminDTO);

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperience>>(_cvWorkExperienceDal.GetDeletedAll(c => c.PersonelUserId == personelUser.Data.Id));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperience>>(_cvWorkExperienceDal.GetDeletedAll());
            }

        }
        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserCvWorkExperience> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            var personelUser = _personelUserService.GetByAdminId(userAdminDTO);


            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<PersonelUserCvWorkExperience>(_cvWorkExperienceDal.Get(c => c.Id == userAdminDTO.Id && c.PersonelUserId == personelUser.Data.Id));
            }
            else
            {
                return new SuccessDataResult<PersonelUserCvWorkExperience>(_cvWorkExperienceDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvWorkExperienceDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperienceDTO>>(_cvWorkExperienceDal.GetAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperienceDTO>>(_cvWorkExperienceDal.GetAllDTO().OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }

        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvWorkExperienceDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperienceDTO>>(_cvWorkExperienceDal.GetDeletedAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperienceDTO>>(_cvWorkExperienceDal.GetDeletedAllDTO().OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }

        }

    }
}
