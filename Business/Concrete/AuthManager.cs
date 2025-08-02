using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Core.Utilities.Security.Status;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IUserOperationClaimService _userOperationClaimService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserOperationClaimService userOperationClaimService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userOperationClaimService = userOperationClaimService;
        }

        public async Task<IDataResult<User>> Register(UserForRegisterDTO userForRegisterDto)
        {
            string userCode = SelectUserCode(userForRegisterDto);

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
                Code= userCode,
                Status = UserStatus.User,
            };
            await _userService.Add(user);

            var currentUser = await _userService.GetByMail(userForRegisterDto.Email);

            var userOperationClaim = new UserOperationClaim
            {
                UserId = currentUser.Data.Id,
                OperationClaimId = "bb6f4813-5813-49ab-ab08-17c605121d5e"
            };
            await _userOperationClaimService.Add(userOperationClaim);

            return new SuccessDataResult<User>(user, Messages.SuccessfulLogin);
        }

        private string SelectUserCode(UserForRegisterDTO userForRegisterDto)
        {
           return userForRegisterDto.Code == "personel" ? UserCode.PersonelUser : UserCode.CompanyUser;
        }

        public async Task<IDataResult<User>> Login(UserForLoginDTO userForLoginDto)
        {
            var userToCheck = await _userService.GetByMail(userForLoginDto.Email);

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
        public async Task<IDataResult<User>> UpdatePassword(PasswordDTO passwordDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(passwordDto.Password, out passwordHash, out passwordSalt);

            var userToCheck = await _userService.GetByMail(passwordDto.Email);

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

            if (!HashingHelper.PasswordHashExist(passwordDto.NewPassword, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>((Messages.PasswordExist));
            }

            User currentUser = await _userService.GetById(passwordDto.Id);

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
                Code = currentUser.Code,
                CreatedDate = currentUser.CreatedDate,
                UpdatedDate = DateTime.Now,
                DeletedDate = currentUser.DeletedDate,

            };
            await _userService.Update(user);
            return new SuccessDataResult<User>(user, Messages.SuccessPasswordChange);
        }

        public async Task<IResult> UserExists(string email)
        {
            var userResult = await _userService.GetByMail(email);

            if (userResult.Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public async Task<IDataResult<AccessToken>> CreateAccessToken(User user)
        {
            var claims = await _userService.GetClaims(user);
            var accessToken = await _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }
}
