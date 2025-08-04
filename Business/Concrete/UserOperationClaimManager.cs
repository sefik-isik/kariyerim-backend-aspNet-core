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

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal, IUserService userService)
        {
            _userOperationClaimDal = userOperationClaimDal;
            _userService = userService;
        }

        public async Task<IResult> Add(UserOperationClaim userOperationClaim)
        {
            if (_userService.GetById(userOperationClaim.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _userOperationClaimDal.AddAsync(userOperationClaim);

            return new SuccessResult(Messages.SuccessAdded);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Update(UserOperationClaim userOperationClaim)
        {
            if (_userService.GetById(userOperationClaim.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _userOperationClaimDal.UpdateAsync(userOperationClaim);

            if (userOperationClaim.OperationClaimId == "352f7ef8-3a76-4dd9-8458-267fa984c715")
            {
                await _userService.MakeUserAdmin(userOperationClaim);
            }
            else
            {
                await _userService.MakeNormalUser(userOperationClaim);
            }

            

            return new SuccessResult(Messages.SuccessUpdated);
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Delete(UserOperationClaim userOperationClaim)
        {
            if (_userService.GetById(userOperationClaim.UserId) == null)
            {
                return new ErrorResult(Messages.PermissionError);
            }
            await _userOperationClaimDal.Delete(userOperationClaim);

            return new SuccessResult(Messages.SuccessDeleted);
        }


        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<UserOperationClaim>>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<UserOperationClaim>>(await _userOperationClaimDal.GetAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<UserOperationClaim>>(await _userOperationClaimDal.GetAll(), Messages.SuccessListed);
            }

        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<UserOperationClaim>>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<UserOperationClaim>>(await _userOperationClaimDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<UserOperationClaim>>(await _userOperationClaimDal.GetDeletedAll(), Messages.SuccessListed);
            }
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<UserOperationClaim?>> GetById(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<UserOperationClaim?>(await _userOperationClaimDal.Get(c => c.Id == userAdminDTO.Id && c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<UserOperationClaim?>(await _userOperationClaimDal.Get(c => c.Id == userAdminDTO.Id));
            }
        }

        //DTO
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<UserOperationClaimDTO>>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var allDtos = await _userOperationClaimDal.GetAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<UserOperationClaimDTO>>(allDtos.FindAll(c => c.UserId == userAdminDTO.UserId).OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<UserOperationClaimDTO>>(allDtos.OrderBy(s => s.Email).ToList(), Messages.SuccessListed);
            }

        }

        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<UserOperationClaimDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = await _userService.IsAdmin(userAdminDTO);
            var allDtos = await _userOperationClaimDal.GetDeletedAllDTO();

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<UserOperationClaimDTO>>(allDtos.FindAll(c => c.UserId == userAdminDTO.UserId), Messages.SuccessListed);
            }
            else
            {
                return new SuccessDataResult<List<UserOperationClaimDTO>>(allDtos, Messages.SuccessListed);
            }
        }
    }
}
