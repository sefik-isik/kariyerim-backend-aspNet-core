using Core.Utilities.Results;
using Core.Entities.Abstract;
using Entities.DTOs;
using Core.Utilities.Security.JWT;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<IResult> UserExists(string email);
        Task<IDataResult<User>> Register(UserForRegisterDTO userForRegisterDto);
        Task<IDataResult<User>> Login(UserForLoginDTO userForLoginDto);
        Task<IDataResult<User>> UpdatePassword(PasswordDTO passwordDto);
        Task<IDataResult<AccessToken>> CreateAccessToken(User user);

    }
}
