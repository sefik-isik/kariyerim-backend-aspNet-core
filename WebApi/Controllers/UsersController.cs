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

        [HttpGet("getbyiddto")]
        public IActionResult GetByIdDTO(int id)
        {
            var result = _userService.GetByIdDTO(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getcode")]
        public IActionResult GetCode(int userId)
        {
            var result = _userService.GetCode(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

    }
}
