using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Status;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        IUserOperationClaimDal _userOperationClaimDal;
        IUserService _userService;
        IPersonelUserService _personelUserService;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal, IUserService userService, IPersonelUserService personelUserService)
        {
            _userOperationClaimDal = userOperationClaimDal;
            _userService = userService;
            _personelUserService = personelUserService;
        }

        [SecuredOperation("admin")]
        public IResult Add(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Add(userOperationClaim);

            MakeUserAdmin(userOperationClaim);

            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        public IResult Update(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Update(userOperationClaim);

            MakeUserAdmin(userOperationClaim);

            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Delete(userOperationClaim);

            MakeUserAdmin(userOperationClaim);

            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<UserOperationClaim>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.UserId).ToList());
            }
            else
            {
                return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll().OrderBy(s => s.UserId).ToList());
            }

        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<UserOperationClaim>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.UserId).ToList());
            }
            else
            {
                return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetDeletedAll().OrderBy(s => s.UserId).ToList());
            }
        }
        [SecuredOperation("admin,user")]
        public IDataResult<UserOperationClaim> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }

        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<UserOperationClaimDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<UserOperationClaimDTO>>(_userOperationClaimDal.GetAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<UserOperationClaimDTO>>(_userOperationClaimDal.GetAllDTO().OrderBy(s => s.Email).ToList());
            }

        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<UserOperationClaimDTO>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<UserOperationClaimDTO>>(_userOperationClaimDal.GetDeletedAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<UserOperationClaimDTO>>(_userOperationClaimDal.GetDeletedAllDTO().OrderBy(s => s.Email).ToList());
            }
        }

        private void MakeUserAdmin(UserOperationClaim userOperationClaim)
        {
            User currentUser = _userService.GetById(userOperationClaim.UserId);

            var user = new User
            {
                Id = userOperationClaim.UserId,
                PasswordHash = currentUser.PasswordHash,
                PasswordSalt = currentUser.PasswordSalt,
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                PhoneNumber = currentUser.PhoneNumber,
                Email = currentUser.Email,
                Status = currentUser.Status,
                Code = currentUser.Code,
                CreatedDate = currentUser.CreatedDate,
                UpdatedDate = DateTime.Now,
                DeletedDate = currentUser.DeletedDate,
            };

            if (userOperationClaim.OperationClaimId == 1 && userOperationClaim.DeletedDate == null)
            {
                user.Status = UserStatus.Admin;
            }
            else
            {
                user.Status = UserStatus.User;
            }
            _userService.Update(user);
        }
    }
}
