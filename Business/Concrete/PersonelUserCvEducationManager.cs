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

        public PersonelUserCvEducationManager(IPersonelUserCvEducationDal cvEducationDal, IUserService userService)
        {
            _cvEducationDal = cvEducationDal;
            _userService = userService;

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
        public IDataResult<List<PersonelUserCvEducation>> GetAll(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvEducation>>(_cvEducationDal.GetAll(c => c.UserId == userId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvEducation>>(_cvEducationDal.GetAll());
            }
            
        }
        [SecuredOperation("admin")]
        public IDataResult<List<PersonelUserCvEducation>> GetDeletedAll(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvEducation>>(_cvEducationDal.GetDeletedAll(c => c.UserId == userId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvEducation>>(_cvEducationDal.GetDeletedAll());
            }

        }
        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserCvEducation> GetById(int cvEducationId)
        {
            return new SuccessDataResult<PersonelUserCvEducation>(_cvEducationDal.Get(c=> c.Id == cvEducationId));
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvEducationDTO>> GetAllDTO(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvEducationDTO>>(_cvEducationDal.GetAllDTO().FindAll(c => c.UserId == userId), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvEducationDTO>>(_cvEducationDal.GetAllDTO(), Messages.CompaniesListed);
            }

        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvEducationDTO>> GetAllDeletedDTO(int userId)
        {
            var userIsAdmin = _userService.IsAdmin(UserStatus.Admin, userId);
            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvEducationDTO>>(_cvEducationDal.GetAllDeletedDTO().FindAll(c => c.UserId == userId), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvEducationDTO>>(_cvEducationDal.GetAllDeletedDTO(), Messages.CompaniesListed);
            }

        }
    }
}
