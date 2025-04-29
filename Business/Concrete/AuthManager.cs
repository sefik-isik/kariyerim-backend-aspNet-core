using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDTO userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PhoneNumber = userForRegisterDto.PhoneNumber,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Code= "VmaWsgScWeSUsiLCJhdWQiOiJzZWZpa2lzaWtAZ21haWwuY29tIn0.E53sJM4VSvSVE93feNe-XjwI5tmy2YntPeXTD_wavFn5mD6Vsk8",
                Status = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9",
                CreatedDate = DateTime.Now,

            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Login(UserForLoginDTO userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>((Messages.PasswordError));
            }

            return new SuccessDataResult<User>(userToCheck.Data, Messages.SuccessfulLogin);
        }


        [SecuredOperation("admin,user")]
        public IDataResult<User> UpdatePassword(PasswordDTO passwordDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(passwordDto.Password, out passwordHash, out passwordSalt);

            var userToCheck = _userService.GetByMail(passwordDto.Email);

            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(passwordDto.OldPassword, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>((Messages.PasswordError));
            }

            if (passwordDto.Password != passwordDto.NewPassword)
            {
                return new ErrorDataResult<User>((Messages.PasswordNotSame));
            }

            User currentUser = _userService.GetById(passwordDto.Id);

            var user = new User
            {
                Id = passwordDto.Id,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,

                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                PhoneNumber = currentUser.PhoneNumber,
                Email = currentUser.Email,
                Status = currentUser.Status,
                CreatedDate = currentUser.CreatedDate,
                UpdatedDate = DateTime.Now,
                DeletedDate = currentUser.DeletedDate,

            };
            _userService.Update(user);
            return new SuccessDataResult<User>(user, Messages.SuccessPasswordChange);
        }



        [SecuredOperation("admin,user")]
        public IDataResult<User> UpdateUserCode(UserCodeDTO userCode)
        {
            var userToCheck = _userService.GetByMail(userCode.Email);

            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            User currentUser = _userService.GetById(userCode.Id);

            var user = new User
            {
                Id = userCode.Id,
                Code = userCode.Code,

                FirstName=currentUser.FirstName,
                LastName=currentUser.LastName,
                PhoneNumber = currentUser.PhoneNumber,
                Email =currentUser.Email,
                PasswordHash=currentUser.PasswordHash,
                PasswordSalt=currentUser.PasswordSalt,
                Status=currentUser.Status,
                CreatedDate=currentUser.CreatedDate,
                UpdatedDate = DateTime.Now,
                DeletedDate=currentUser.DeletedDate,
            };

            _userService.Update(user);
            return new SuccessDataResult<User>(user);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email).Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }
}
