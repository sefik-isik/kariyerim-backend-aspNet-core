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
    public interface IUserOperationClaimService
    {
        Task<IResult> Add(UserOperationClaim userOperationClaim);
        Task<IResult> Update(UserOperationClaim userOperationClaim);
        Task<IResult> Delete(UserOperationClaim userOperationClaim);
        Task<IDataResult<List<UserOperationClaim>>> GetAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<UserOperationClaim>>> GetDeletedAll(UserAdminDTO userAdminDTO);
        Task<IDataResult<UserOperationClaim>> GetById(UserAdminDTO userAdminDTO);

        //DTO
        Task<IDataResult<List<UserOperationClaimDTO>>> GetAllDTO(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<UserOperationClaimDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);
        Task<IResult> MakeUserAdmin(UserOperationClaim userOperationClaim);

    }
}
