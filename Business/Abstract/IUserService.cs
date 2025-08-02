using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using Entities.PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        
        Task<IResult> Add(User user);
        Task<IResult> Update(User user);
        Task<IResult> Delete(User user);
        Task<IResult> Terminate(User user);
        Task<IDataResult<User>> GetByMail(string email);
        Task<IDataResult<List<OperationClaim>>> GetClaims(User user);
        Task<User> GetById(string id);
        Task<IDataResult<UserPageModel>> GetAllByPage(UserPageModel pageModel);

        //DTO
        Task<IDataResult<User>> IsAdmin(UserAdminDTO userAdminDTO);
        Task<IDataResult<UserDTO>> GetByIdDTO(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<UserDTO>>> GetAllCompanyUserDTO(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<UserDTO>>> GetAllPersonelUserDTO(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<UserDTO>>> GetAllDTO(UserAdminDTO userAdminDTO);
        Task<IDataResult<List<UserDTO>>> GetDeletedAllDTO(UserAdminDTO userAdminDTO);
        
    }
}
