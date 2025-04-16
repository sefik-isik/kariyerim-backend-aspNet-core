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

        public PersonelUserCvWorkExperienceManager(IPersonelUserCvWorkExperienceDal cvWorkExperienceDal, IUserService userService)
        {
            _cvWorkExperienceDal = cvWorkExperienceDal;
            _userService = userService;

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
        public IDataResult<List<PersonelUserCvWorkExperience>> GetAll(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperience>>(_cvWorkExperienceDal.GetAll(c => c.UserId == userId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperience>>(_cvWorkExperienceDal.GetAll());
            }
            
        }
        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserCvWorkExperience> GetById(int cvWorkExperienceId)
        {
            return new SuccessDataResult<PersonelUserCvWorkExperience>(_cvWorkExperienceDal.Get(c=> c.Id == cvWorkExperienceId));
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvWorkExperienceDTO>> GetAllDTO(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperienceDTO>>(_cvWorkExperienceDal.GetAllDTO().FindAll(c => c.UserId == userId), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvWorkExperienceDTO>>(_cvWorkExperienceDal.GetAllDTO(), Messages.CompaniesListed);
            }

        }

    }
}
