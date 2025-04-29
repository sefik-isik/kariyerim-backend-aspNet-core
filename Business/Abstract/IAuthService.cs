using Core.Utilities.Results;
using Core.Entities.Abstract;
using Entities.DTOs;
using Core.Utilities.Security.JWT;
using Core.Entities.Concrete;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDTO userForRegisterDto);
        IDataResult<User> Login(UserForLoginDTO userForLoginDto);
        IDataResult<User> UpdatePassword(PasswordDTO passwordDto);
        IDataResult<User> UpdateUserCode(UserCodeDTO userCode);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);

    }
}
