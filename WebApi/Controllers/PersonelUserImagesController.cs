using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelUserImagesController : ControllerBase
    {
        IPersonelUserImageService _personelUserImageService;

        public PersonelUserImagesController(IPersonelUserImageService personelUserImageService)
        {
            _personelUserImageService = personelUserImageService;
        }

        [HttpPost("add")]
        public IActionResult Add(PersonelUserImage personelUserImage)
        {
            var result = _personelUserImageService.Add(personelUserImage);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(PersonelUserImage personelUserImage)
        {
            var result = _personelUserImageService.Update(personelUserImage);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(PersonelUserImage personelUserImage)
        {
            var result = _personelUserImageService.Delete(personelUserImage);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll(int userId)
        {
            var result = _personelUserImageService.GetAll(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int personelUserImageId)
        {
            var result = _personelUserImageService.GetById(personelUserImageId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
