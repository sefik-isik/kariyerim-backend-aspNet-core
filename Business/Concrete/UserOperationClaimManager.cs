using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Results;
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
        //[SecuredOperation("admin")]
        public IResult Add(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Update(userOperationClaim);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Delete(userOperationClaim);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<UserOperationClaim>> GetAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll());
            }
           
        }
        [SecuredOperation("admin")]
        public IDataResult<List<UserOperationClaim>> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetDeletedAll(c => c.UserId == userAdminDTO.UserId));
            }
            else
            {
                return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetDeletedAll());
            }
        }
        [SecuredOperation("admin,user")]
        public IDataResult<UserOperationClaim> GetById(int id)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(c => c.Id == id));
        }

        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<UserOperationClaimDTO>> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<UserOperationClaimDTO>>(_userOperationClaimDal.GetAllDTO().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<UserOperationClaimDTO>>(_userOperationClaimDal.GetAllDTO());
            }

        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<UserOperationClaimDTO>> GetAllDeletedDTO(UserAdminDTO userAdminDTO)
        {
            var userIsAdmin = _userService.IsAdmin(userAdminDTO);

            if (userIsAdmin.Data == null)
            {
                return new SuccessDataResult<List<UserOperationClaimDTO>>(_userOperationClaimDal.GetAllDeletedDTO().FindAll(c => c.UserId == userAdminDTO.UserId), Messages.CompaniesListed);
            }
            else
            {
                return new SuccessDataResult<List<UserOperationClaimDTO>>(_userOperationClaimDal.GetAllDeletedDTO());
            }
        }
    }
}
