using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelUserAboutsController : ControllerBase
    {
        IPersonelUserAboutService _personelUserAboutService;

        public PersonelUserAboutsController(IPersonelUserAboutService personelUserAboutService)
        {
            _personelUserAboutService = personelUserAboutService;
        }

        [HttpPost("add")]
        public IActionResult Add(PersonelUserAbout personelUserAbout)
        {
            var result = _personelUserAboutService.Add(personelUserAbout);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(PersonelUserAbout personelUserAbout)
        {
            var result = _personelUserAboutService.Update(personelUserAbout);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(PersonelUserAbout personelUserAbout)
        {
            var result = _personelUserAboutService.Delete(personelUserAbout);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll(int id)
        {
            var result = _personelUserAboutService.GetAll(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _personelUserAboutService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getalldto")]
        public IActionResult GetAllDTO(int id)
        {
            var result = _personelUserAboutService.GetAllDTO(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

    }
}
