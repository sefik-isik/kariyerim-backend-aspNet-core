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
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        User GetById(int id);

        IDataResult<User> IsAdmin(UserAdminDTO userAdminDTO);

        IDataResult<User> GetByMail(string email);
        //IDataResult<User> IsAdmin(string status);

        //DTO
        IDataResult<UserDTO> GetByIdDTO(UserAdminDTO userAdminDTO);
        IDataResult<List<UserCodeDTO>> GetCode(UserAdminDTO userAdminDTO);
        IDataResult<List<UserDTO>> GetAllCompanyUserDTO(UserAdminDTO userAdminDTO);
        IDataResult<List<UserDTO>> GetAllPersonelUserDTO(UserAdminDTO userAdminDTO);
        IDataResult<List<UserDTO>> GetAllDTO(UserAdminDTO userAdminDTO);
        IDataResult<List<UserDTO>> GetAllDeletedDTO(UserAdminDTO userAdminDTO);
        
    }
}
