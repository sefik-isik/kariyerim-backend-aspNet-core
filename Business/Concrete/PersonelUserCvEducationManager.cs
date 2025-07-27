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
        IPersonelUserCvEducationDal _personelUserCvEducationDal;
        IUserService _userService;

        public PersonelUserCvEducationManager(IPersonelUserCvEducationDal cvEducationDal, IUserService userService)
        {
            _personelUserCvEducationDal = cvEducationDal;
            _userService = userService;
        }

        [SecuredOperation("admin,user")]
        public IResult Add(PersonelUserCvEducation personelUserCvEducation)
        {
            if (_userService.GetById(personelUserCvEducation.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _personelUserCvEducationDal.AddAsync(personelUserCvEducation);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [SecuredOperation("admin,user")]
        public IResult Update(PersonelUserCvEducation personelUserCvEducation)
        {
            if (_userService.GetById(personelUserCvEducation.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _personelUserCvEducationDal.UpdateAsync(personelUserCvEducation);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        [SecuredOperation("admin,user")]
        public IResult Delete(PersonelUserCvEducation personelUserCvEducation)
        {
            if (_userService.GetById(personelUserCvEducation.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _personelUserCvEducationDal.Delete(personelUserCvEducation);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        public IResult Terminate(PersonelUserCvEducation personelUserCvEducation)
        {
            _personelUserCvEducationDal.Terminate(personelUserCvEducation);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvEducation>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvEducation>>(_personelUserCvEducationDal.GetAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvEducation>>(_personelUserCvEducationDal.GetAll());
            }
            
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvEducation>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvEducation>>(_personelUserCvEducationDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvEducation>>(_personelUserCvEducationDal.GetDeletedAll());
            }

        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvEducation>> GetPersonelUser(UserAdminDTO userAdminDTO)
        {

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvEducation>>(_personelUserCvEducationDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvEducation>>(_personelUserCvEducationDal.GetDeletedAll());
            }

        }


        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserCvEducation> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<PersonelUserCvEducation>(_personelUserCvEducationDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<PersonelUserCvEducation>(_personelUserCvEducationDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }


        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvEducationDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvEducationDTO>>(_personelUserCvEducationDal.GetAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvEducationDTO>>(_personelUserCvEducationDal.GetAllDTO().OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }

        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCvEducationDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCvEducationDTO>>(_personelUserCvEducationDal.GetDeletedAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCvEducationDTO>>(_personelUserCvEducationDal.GetDeletedAllDTO().OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }

        }
    }
}
