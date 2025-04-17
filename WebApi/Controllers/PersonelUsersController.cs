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
        public IActionResult GetAll(int id)
        {
            var result = _personelUserService.GetAll(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _personelUserService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getalldto")]
        public IActionResult GetAllDTO(int id)
        {
            var result = _personelUserService.GetAllDTO(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

    }
}
