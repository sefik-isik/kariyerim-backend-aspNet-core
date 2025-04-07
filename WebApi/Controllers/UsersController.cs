using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getuserdto")]
        public IActionResult GetUserDTO(int UserId)
        {
            var result = _userService.GetUserDTO(UserId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getuserdeleteddto")]
        public IActionResult GetUserDeletedDTO(int UserId)
        {
            var result = _userService.GetUserDeletedDTO(UserId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
