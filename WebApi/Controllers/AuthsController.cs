using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private IAuthService _authService;

        public AuthsController(IAuthService userAuthService)
        {
            _authService = userAuthService;
        }
        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDTO userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.IsSuccess)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDTO userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.IsSuccess)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("updatepassword")]
        public ActionResult UpdatePassword(PasswordDTO passwordDto)
        {
            var userToLogin = _authService.UpdatePassword(passwordDto);
            if (!userToLogin.IsSuccess)
            {
                return BadRequest(userToLogin.Message);
            }

            return Ok();
        }

        [HttpPost("updatecode")]
        public ActionResult UpdateCode(UserCodeDTO userCodeDTO)
        {
            var result = _authService.UpdateUserCode(userCodeDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        
        [HttpPost("updateuser")]
        public ActionResult UpdateUser(User user)
        {
            var result = _authService.UpdateUser(user);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("deleteuser")]
        public ActionResult DeleteUser(User user)
        {
            var result = _authService.DeleteUser(user);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("undeleteuser")]
        public ActionResult UnDeleteUser(User user)
        {
            var result = _authService.UnDeleteUser(user);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
