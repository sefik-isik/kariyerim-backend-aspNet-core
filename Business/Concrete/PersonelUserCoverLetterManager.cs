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
        public async Task<IResult> Add(PersonelUserCoverLetter personelUserCoverLetter)
        {
            if (_userService.GetById(personelUserCoverLetter.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            IResult result = await BusinessRules.Run(IsNameExist(personelUserCoverLetter.Title));

            if (result != null)
            {
                return result;
            }
            await _personelUserCoverLetterDal.AddAsync(personelUserCoverLetter);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Update(PersonelUserCoverLetter personelUserCoverLetter)
        {
            if (_userService.GetById(personelUserCoverLetter.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _personelUserCoverLetterDal.UpdateAsync(personelUserCoverLetter);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Delete(PersonelUserCoverLetter personelUserCoverLetter)
        {
            if (_userService.GetById(personelUserCoverLetter.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _personelUserCoverLetterDal.Delete(personelUserCoverLetter);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(PersonelUserCoverLetter personelUserCoverLetter)
        {
            await _personelUserCoverLetterDal.Terminate(personelUserCoverLetter);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserCoverLetter>>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCoverLetter>>(await _personelUserCoverLetterDal.GetAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCoverLetter>>(await _personelUserCoverLetterDal.GetAll());
            }
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserCoverLetter>>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCoverLetter>>(await _personelUserCoverLetterDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCoverLetter>>(await _personelUserCoverLetterDal.GetDeletedAll());
            }


        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<PersonelUserCoverLetter?>> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<PersonelUserCoverLetter?>(await _personelUserCoverLetterDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<PersonelUserCoverLetter?>(await _personelUserCoverLetterDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }

        //DTO
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserCoverLetterDTO>>> GetAllDTO(UserAdminDTO userAdminDTO)
        {

            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var alldto = await _personelUserCoverLetterDal.GetAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCoverLetterDTO>>(alldto.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCoverLetterDTO>>(alldto.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList(), Messages.SuccessListed);
            }

        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserCoverLetterDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var alldto = await _personelUserCoverLetterDal.GetDeletedAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<PersonelUserCoverLetterDTO>>(alldto.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserCoverLetterDTO>>(alldto.OrderBy(x => x.FirstName).OrderBy(x => x.LastName).ToList(), Messages.SuccessListed);
            }

        }
        //Business Rules
        private async Task<IResult> IsNameExist(string entityName)
        {
            var result = await _personelUserCoverLetterDal.GetAll(c => c.Title.ToLower() == entityName.ToLower());

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }

    }
}
