using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private IAuthService _userAuthService;

        public UserAuthController(IAuthService userAuthService)
        {
            _userAuthService = userAuthService;
        }
        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDTO userForRegisterDto)
        {
            var userExists = _userAuthService.UserExists(userForRegisterDto.Email);
            if (!userExists.IsSuccess)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _userAuthService.Register(userForRegisterDto);
            var result = _userAuthService.CreateAccessToken(registerResult.Data);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDTO userForLoginDto)
        {
            var userToLogin = _userAuthService.Login(userForLoginDto);
            if (!userToLogin.IsSuccess)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _userAuthService.CreateAccessToken(userToLogin.Data);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("updatepassword")]
        public ActionResult UpdatePassword(PasswordDTO passwordDto)
        {
            var userToLogin = _userAuthService.UpdatePassword(passwordDto);
            if (!userToLogin.IsSuccess)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _userAuthService.CreateAccessToken(userToLogin.Data);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
