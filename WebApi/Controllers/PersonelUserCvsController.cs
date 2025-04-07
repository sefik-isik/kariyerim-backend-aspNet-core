using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelUserCvsController : ControllerBase
    {
        IPersonelUserCvService _cvService;

        public PersonelUserCvsController(IPersonelUserCvService cvService)
        {
            _cvService = cvService;
        }

        [HttpPost("add")]
        public IActionResult Add(PersonelUserCv cv)
        {
            var result = _cvService.Add(cv);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(PersonelUserCv cv)
        {
            var result = _cvService.Update(cv);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(PersonelUserCv cv)
        {
            var result = _cvService.Delete(cv);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll(int userId)
        {
            var result = _cvService.GetAll(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int cvId)
        {
            var result = _cvService.GetById(cvId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
