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
        IDataResult<List<UserOperationClaim>> GetAll(UserAdminDTO userAdminDTO);
        IDataResult<List<UserOperationClaim>> GetDeletedAll(UserAdminDTO userAdminDTO);
        IDataResult<UserOperationClaim> GetById(UserAdminDTO userAdminDTO);

        //DTO
        IDataResult<List<UserOperationClaimDTO>> GetAllDTO(UserAdminDTO userAdminDTO);
        IDataResult<List<UserOperationClaimDTO>> GetAllDeletedDTO(UserAdminDTO userAdminDTO);

    }
}
