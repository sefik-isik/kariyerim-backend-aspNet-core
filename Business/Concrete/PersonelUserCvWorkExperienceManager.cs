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
        IPersonelUserCvWorkExperienceDal _personelUserCvWorkExperienceDal;
        IUserService _userService;

        public PersonelUserCvWorkExperienceManager(IPersonelUserCvWorkExperienceDal cvWorkExperienceDal, 
            IUserService userService)
        {
            _personelUserCvWorkExperienceDal = cvWorkExperienceDal;
            _userService = userService;
        }

        [SecuredOperation("admin,user")]
        public IResult Add(PersonelUserCvWorkExperience personelUserCvWorkExperience)
        {
            if (_userService.GetById(personelUserCvWorkExperience.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _personelUserCvWorkExperienceDal.AddAsync(personelUserCvWorkExperience); 
            return new SuccessResult(Messages.SuccessAdded);
        }

        [SecuredOperation("admin,user")]
        public IResult Update(PersonelUserCvWorkExperience personelUserCvWorkExperience)
        {
            if (_userService.GetById(personelUserCvWorkExperience.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _personelUserCvWorkExperienceDal.UpdateAsync(personelUserCvWorkExperience);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        [SecuredOperation("admin,user")]
        public IResult Delete(PersonelUserCvWorkExperience personelUserCvWorkExperience)
        {
            if (_userService.GetById(personelUserCvWorkExperience.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _personelUserCvWorkExperienceDal.Delete(personelUserCvWorkExperience);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        public IResult Terminate(PersonelUserCvWorkExperience personelUserCvWorkExperience)
        {
            _personelUserCvWorkExperienceDal.Terminate(personelUserCvWorkExperience);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvWorkExperience>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperience>>(_personelUserCvWorkExperienceDal.GetAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperience>>(_personelUserCvWorkExperienceDal.GetAll());
            }
            
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvWorkExperience>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperience>>(_personelUserCvWorkExperienceDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperience>>(_personelUserCvWorkExperienceDal.GetDeletedAll());
            }

        }
        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserCvWorkExperience> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<PersonelUserCvWorkExperience>(_personelUserCvWorkExperienceDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<PersonelUserCvWorkExperience>(_personelUserCvWorkExperienceDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvWorkExperienceDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperienceDTO>>(_personelUserCvWorkExperienceDal.GetAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperienceDTO>>(_personelUserCvWorkExperienceDal.GetAllDTO().OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }

        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvWorkExperienceDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperienceDTO>>(_personelUserCvWorkExperienceDal.GetDeletedAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperienceDTO>>(_personelUserCvWorkExperienceDal.GetDeletedAllDTO().OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }

        }

    }
}
