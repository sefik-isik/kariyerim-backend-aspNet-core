using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Business;
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
    public class OperationClaimManager : IOperationClaimService
    {
        IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        [SecuredOperation("admin")]
        public async Task<IResult> Add(OperationClaim operationClaim)
        {
            IResult result = await BusinessRules.Run(IsNameExist(operationClaim.Name));

            if (result != null)
            {
                return result;
            }
            await _operationClaimDal.AddAsync(operationClaim);
            return new SuccessResult(Messages.SuccessAdded);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Update(OperationClaim operationClaim)
        {
            await _operationClaimDal.UpdateAsync(operationClaim);
            return new SuccessResult(Messages.SuccessUpdated);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Delete(OperationClaim operationClaim)
        {
            await _operationClaimDal.Delete(operationClaim);
            return new SuccessResult(Messages.SuccessDeleted);
        }
        [SecuredOperation("admin")]
        public async Task<IResult> Terminate(OperationClaim operationClaim)
        {
            await _operationClaimDal.Terminate(operationClaim);
            return new SuccessResult(Messages.SuccessTerminate);
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<OperationClaim>>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(await _operationClaimDal.GetAll());
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<List<OperationClaim>>> GetDeletedAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(await _operationClaimDal.GetDeletedAll());
        }
        [SecuredOperation("admin,user")]
        public async Task<IDataResult<OperationClaim?>> GetById(string id)
        {
            return new SuccessDataResult<OperationClaim?>(await _operationClaimDal.Get(c => c.Id == id));
        }
        //Business Rules
        private async Task<IResult> IsNameExist(string entityName)
        {
            var result = await _operationClaimDal.GetAll(c => c.Name.ToLower() == entityName.ToLower());

            if (result != null && result.Count > 0)
            {
                return new ErrorResult(Messages.FieldAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
