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
        IPersonelUserService _personelUserService;

        public PersonelUserCoverLetterManager(IPersonelUserCoverLetterDal personelUserCoverLetterDal, IUserService userService, IPersonelUserService personelUserService)
        {
            _personelUserCoverLetterDal = personelUserCoverLetterDal;
            _userService = userService;
            _personelUserService = personelUserService;

        }
        [SecuredOperation("admin,user")]
        public IResult Add(PersonelUserCoverLetter personelUserCoverLetter)
        {
            _personelUserCoverLetterDal.Add(personelUserCoverLetter);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Update(PersonelUserCoverLetter personelUserCoverLetter)
        {
            _personelUserCoverLetterDal.Update(personelUserCoverLetter);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(PersonelUserCoverLetter personelUserCoverLetter)
        {
            _personelUserCoverLetterDal.Delete(personelUserCoverLetter);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCoverLetter>> GetAll(UserAdminDTO userAdminDTO)
        {
            var personelUser = _personelUserService.GetByAdminId(userAdminDTO);

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCoverLetter>>(_personelUserCoverLetterDal.GetAll(c => c.PersonelUserId == personelUser.Data.Id));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCoverLetter>>(_personelUserCoverLetterDal.GetAll());
            }

            
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<PersonelUserCoverLetter>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var personelUser = _personelUserService.GetByAdminId(userAdminDTO);

            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCoverLetter>>(_personelUserCoverLetterDal.GetDeletedAll(c => c.PersonelUserId == personelUser.Data.Id));
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

            var personelUser = _personelUserService.GetByAdminId(userAdminDTO);


            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<PersonelUserCoverLetter>(_personelUserCoverLetterDal.Get(c => c.Id == userAdminDTO.Id && c.PersonelUserId == personelUser.Data.Id));
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

    }
}
