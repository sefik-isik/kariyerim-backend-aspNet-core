using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelUsersController : ControllerBase
    {
        IPersonelUserService _personelUserService;

        public PersonelUsersController(IPersonelUserService personelUserService)
        {
            _personelUserService = personelUserService;
        }

        [HttpPost("add")]
        public IActionResult Add(PersonelUser personelUser)
        {
            var result = _personelUserService.Add(personelUser);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(PersonelUser personelUser)
        {
            var result = _personelUserService.Update(personelUser);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(PersonelUser personelUser)
        {
            var result = _personelUserService.Delete(personelUser);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll(int userId)
        {
            var result = _personelUserService.GetAll(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int personelUserId)
        {
            var result = _personelUserService.GetById(personelUserId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getuserdto")]
        public IActionResult GetUserDTO(int userId)
        {
            var result = _personelUserService.GetUserDTO(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getuserdeleteddto")]
        public IActionResult GetUserDeletedDTO(int userId)
        {
            var result = _personelUserService.GetUserDeletedDTO(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
