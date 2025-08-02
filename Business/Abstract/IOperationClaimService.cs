using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOperationClaimService
    {
        Task<IResult> Add(OperationClaim operationClaim);
        Task<IResult> Update(OperationClaim operationClaim);
        Task<IResult> Delete(OperationClaim operationClaim);
        Task<IResult> Terminate(OperationClaim operationClaim);
        Task<IDataResult<List<OperationClaim>>> GetAll();
        Task<IDataResult<List<OperationClaim>>> GetDeletedAll();
        Task<IDataResult<OperationClaim>> GetById(string id);
        
    }
}
