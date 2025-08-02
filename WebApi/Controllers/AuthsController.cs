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
        public async Task<ActionResult> Register(UserForRegisterDTO userForRegisterDto)
        {
            var userExists = await _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.IsSuccess)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = await _authService.Register(userForRegisterDto);
            var result = await _authService.CreateAccessToken(registerResult.Data);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserForLoginDTO userForLoginDto)
        {
            var userToLogin = await _authService.Login(userForLoginDto);
            if (!userToLogin.IsSuccess)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = await _authService.CreateAccessToken(userToLogin.Data);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("updatepassword")]
        public async Task<ActionResult> UpdatePassword(PasswordDTO passwordDto)
        {
            var userToLogin = await _authService.UpdatePassword(passwordDto);
            if (!userToLogin.IsSuccess)
            {
                return BadRequest(userToLogin.Message);
            }
            return Ok();
        }
    }
}
