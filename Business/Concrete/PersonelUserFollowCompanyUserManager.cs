using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
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
    public class PersonelUserFollowCompanyUserManager : IPersonelUserFollowCompanyUserService
    {
        IPersonelUserFollowCompanyUserDal _personelUserFollowCompanyUserDal;
        IUserService _userService;

        public PersonelUserFollowCompanyUserManager(IPersonelUserFollowCompanyUserDal personelUserFollowCompanyUserDal, IUserService userService)
        {
            _personelUserFollowCompanyUserDal = personelUserFollowCompanyUserDal;
            _userService = userService;
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Add(PersonelUserFollowCompanyUser personelUserFollowCompanyUser)
        {
            IResult result = await BusinessRules.Run(IsNameExist(personelUserFollowCompanyUser.CompanyUserId, personelUserFollowCompanyUser.PersonelUserId));

            if (result != null)
            {
                return result;
            }
            await _personelUserFollowCompanyUserDal.AddAsync(personelUserFollowCompanyUser);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [SecuredOperation("admin,user")]
        public async Task<IResult> Terminate(PersonelUserFollowCompanyUser personelUserFollowCompanyUser)
        {
            await _personelUserFollowCompanyUserDal.Terminate(personelUserFollowCompanyUser);
            return new SuccessResult(Messages.SuccessTerminate);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserFollowCompanyUser>>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new ErrorDataResult<List<PersonelUserFollowCompanyUser>>(Messages.PermissionError);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserFollowCompanyUser>>(await _personelUserFollowCompanyUserDal.GetAll(), Messages.SuccessListed);
            }
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<PersonelUserFollowCompanyUser?>> GetById(string id)
        {

            return new SuccessDataResult<PersonelUserFollowCompanyUser?>(await _personelUserFollowCompanyUserDal.Get(c => c.Id == id));
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserFollowCompanyUser>>> GetAllByCompanyId(string id)
        {

            return new SuccessDataResult<List<PersonelUserFollowCompanyUser>>(await _personelUserFollowCompanyUserDal.GetAll(c => c.CompanyUserId == id), Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserFollowCompanyUser>>> GetAllByPersonelId(string id)
        {
            return new SuccessDataResult<List<PersonelUserFollowCompanyUser>>(await _personelUserFollowCompanyUserDal.GetAll(p => p.PersonelUserId == id), Messages.SuccessListed);
        }



        //DTO Methods

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserFollowCompanyUserDTO>>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new ErrorDataResult<List<PersonelUserFollowCompanyUserDTO>>(Messages.PermissionError);
            }
            else
            {
                return new SuccessDataResult<List<PersonelUserFollowCompanyUserDTO>>(await _personelUserFollowCompanyUserDal.GetAllDTO(), Messages.SuccessListed);
            }
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserFollowCompanyUserDTO>>> GetAllByCompanyUserIdDTO(UserAdminDTO userAdminDTO)
        {
            return new SuccessDataResult<List<PersonelUserFollowCompanyUserDTO>>(await _personelUserFollowCompanyUserDal.GetAllByCompanyUserIdDTO(userAdminDTO.Id), Messages.SuccessListed);
        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<PersonelUserFollowCompanyUserDTO>>> GetAllByPersonelUserIdDTO(UserAdminDTO userAdminDTO)
        {
            return new SuccessDataResult<List<PersonelUserFollowCompanyUserDTO>>(await _personelUserFollowCompanyUserDal.GetAllByPersonelUserIdDTO(userAdminDTO.Id), Messages.SuccessListed);
        }


        //Business Rules
        private async Task<IResult> IsNameExist(string companyUserId, string personelUserId)
        {
            var result = await _personelUserFollowCompanyUserDal.GetAll(c => c.CompanyUserId == companyUserId && c.PersonelUserId == personelUserId);

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
