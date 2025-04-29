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

        [HttpGet("getalldto")]
        public IActionResult GetAllDTO(int id)
        {
            var result = _userService.GetAllDTO(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getcode")]
        public IActionResult GetCode(int userId)
        {
            var result = _userService.GetCode(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

    }
}
