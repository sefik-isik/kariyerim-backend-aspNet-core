using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IResult Add(UserOperationClaim userOperationClaim);
        IResult Update(UserOperationClaim userOperationClaim);
        IResult Delete(UserOperationClaim userOperationClaim);
        IDataResult<List<UserOperationClaim>> GetAll();IDataResult<List<UserOperationClaim>> GetDeletedAll();
        IDataResult<UserOperationClaim> GetById(int userOperationClaimId);

        //DTO
        IDataResult<List<UserOperationClaimDTO>> GetAllDTO();IDataResult<List<UserOperationClaimDTO>> GetAllDeletedDTO();

    }
}
