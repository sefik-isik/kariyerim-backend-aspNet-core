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
        public IResult Add(OperationClaim operationClaim)
        {
            IResult result = BusinessRules.Run(IsNameExist(operationClaim.Name));

            if (result != null)
            {
                return result;
            }
            _operationClaimDal.AddAsync(operationClaim);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Update(OperationClaim operationClaim)
        {
            _operationClaimDal.UpdateAsync(operationClaim);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Delete(OperationClaim operationClaim)
        {
            _operationClaimDal.Delete(operationClaim);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IResult Terminate(OperationClaim operationClaim)
        {
            _operationClaimDal.Terminate(operationClaim);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<OperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<List<OperationClaim>> GetDeletedAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetDeletedAll());
        }
        [SecuredOperation("admin,user")]
        public IDataResult<OperationClaim> GetById(string id)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(c => c.Id == id));
        }
        //Business Rules
        private IResult IsNameExist(string entityName)
        {
            var result = _operationClaimDal.GetAll(c => c.Name.ToLower() == entityName.ToLower()).Any();

            if (result)
            {
                return new ErrorResult(Messages.CityNameAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
