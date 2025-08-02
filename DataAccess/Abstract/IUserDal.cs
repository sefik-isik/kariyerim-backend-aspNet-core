using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        Task TerminateSubDatas(string id);
        Task<List<OperationClaim>> GetClaims(User user);
        Task<List<UserDTO>> GetAllDTO();
        Task<List<UserDTO>> GetAllCompanyUserDTO();
        Task<List<UserDTO>> GetAllPersonelUserDTO();
        Task<List<UserDTO>> GetDeletedAllDTO();

        Task<UserDTO> GetByIdForAdminDTO(string id);
        Task<UserDTO> GetByIdDTO(string userId, string id);

        Task<List<UserCodeDTO>> GetCode(string userId);
    }
}
