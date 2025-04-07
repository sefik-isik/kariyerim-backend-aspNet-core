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
        IDataResult<User> GetByMail(string email);

        IDataResult<User> IsAdmin(string status, int userId);

        //DTO
        IDataResult<List<UserDTO>> GetUserDTO(int userId);
        IDataResult<List<UserDTO>> GetUserDeletedDTO(int userId);
    }
}
