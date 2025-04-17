using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelUserCvAboutsController : ControllerBase
    {
        IPersonelUserCvAboutService _cvAboutService;

        public PersonelUserCvAboutsController(IPersonelUserCvAboutService cvAboutService)
        {
            _cvAboutService = cvAboutService;
        }

        [HttpPost("add")]
        public IActionResult Add(PersonelUserCvAbout cvAbout)
        {
            var result = _cvAboutService.Add(cvAbout);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(PersonelUserCvAbout cvAbout)
        {
            var result = _cvAboutService.Update(cvAbout);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(PersonelUserCvAbout cvAbout)
        {
            var result = _cvAboutService.Delete(cvAbout);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll(int id)
        {
            var result = _cvAboutService.GetAll(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _cvAboutService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getalldto")]
        public IActionResult GetAllDTO(int id)
        {
            var result = _cvAboutService.GetAllDTO(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

    }
}
