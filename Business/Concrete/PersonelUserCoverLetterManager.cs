using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Status;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonelUserCoverLetterManager : IPersonelUserCoverLetterService
    {
        IPersonelUserCoverLetterDal _personelUserCoverLetterDal;
        IUserService _userService;

        public PersonelUserCoverLetterManager(IPersonelUserCoverLetterDal personelUserCoverLetterDal, IUserService userService)
        {
            _personelUserCoverLetterDal = personelUserCoverLetterDal;
            _userService = userService;

        }

        [SecuredOperation("admin,user")]
        public IResult Add(PersonelUserCoverLetter personelUserCoverLetter)
        {
            if (_userService.GetById(personelUserCoverLetter.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            IResult result = BusinessRules.Run(IsNameExist(personelUserCoverLetter.Title));

            if (result != null)
            {
                return result;
            }
            _personelUserCoverLetterDal.AddAsync(personelUserCoverLetter);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IResult Update(PersonelUserCoverLetter personelUserCoverLetter)
        {
            if (_userService.GetById(personelUserCoverLetter.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _personelUserCoverLetterDal.UpdateAsync(personelUserCoverLetter);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IResult Delete(PersonelUserCoverLetter personelUserCoverLetter)
        {
            if (_userService.GetById(personelUserCoverLetter.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            _personelUserCoverLetterDal.Delete(personelUserCoverLetter);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        public IResult Terminate(PersonelUserCoverLetter personelUserCoverLetter)
        {
            _personelUserCoverLetterDal.Terminate(personelUserCoverLetter);
            return new SuccessResult();
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCoverLetter>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCoverLetter>>(_personelUserCoverLetterDal.GetAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCoverLetter>>(_personelUserCoverLetterDal.GetAll());
            }
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCoverLetter>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCoverLetter>>(_personelUserCoverLetterDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCoverLetter>>(_personelUserCoverLetterDal.GetDeletedAll());
            }


        }
        [SecuredOperation("admin,user")]
        public IDataResult<PersonelUserCoverLetter> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<PersonelUserCoverLetter>(_personelUserCoverLetterDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<PersonelUserCoverLetter>(_personelUserCoverLetterDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }

        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCoverLetterDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCoverLetterDTO>>(_personelUserCoverLetterDal.GetAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCoverLetterDTO>>(_personelUserCoverLetterDal.GetAllDTO().OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }

        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCoverLetterDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCoverLetterDTO>>(_personelUserCoverLetterDal.GetDeletedAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCoverLetterDTO>>(_personelUserCoverLetterDal.GetDeletedAllDTO().OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }

        }
        //Business Rules
        private IResult IsNameExist(string entityName)
        {
            var result = _personelUserCoverLetterDal.GetAll(c => c.Title.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.CityNameAlreadyExist);
            }
            return new SuccessResult();
        }

    }
}
