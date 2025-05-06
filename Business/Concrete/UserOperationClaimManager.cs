using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
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
        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll());
        }
        [SecuredOperation("admin")]
        public IDataResult<List<UserOperationClaim>> GetDeletedAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetDeletedAll());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<UserOperationClaim> GetById(int userOperationClaimId)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(c => c.Id == userOperationClaimId));
        }

        //DTO
        [SecuredOperation("admin,user")]
        public IDataResult<List<UserOperationClaimDTO>> GetAllDTO()
        {
            return new SuccessDataResult<List<UserOperationClaimDTO>>(_userOperationClaimDal.GetAllDTO());
        }

        [SecuredOperation("admin,user")]
        public IDataResult<List<UserOperationClaimDTO>> GetAllDeletedDTO()
        {
            return new SuccessDataResult<List<UserOperationClaimDTO>>(_userOperationClaimDal.GetAllDeletedDTO());
        }
    }
}
