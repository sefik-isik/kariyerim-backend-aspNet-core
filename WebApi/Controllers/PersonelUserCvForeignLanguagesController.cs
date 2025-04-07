using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelUserCvForeignLanguagesController : ControllerBase
    {
        IPersonelUserCvForeignLanguageService _cvForeignLanguageService;

        public PersonelUserCvForeignLanguagesController(IPersonelUserCvForeignLanguageService cvForeignLanguageService)
        {
            _cvForeignLanguageService = cvForeignLanguageService;
        }

        [HttpPost("add")]
        public IActionResult Add(PersonelUserCvForeignLanguage cvForeignLanguage)
        {
            var result = _cvForeignLanguageService.Add(cvForeignLanguage);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(PersonelUserCvForeignLanguage cvForeignLanguage)
        {
            var result = _cvForeignLanguageService.Update(cvForeignLanguage);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(PersonelUserCvForeignLanguage cvForeignLanguage)
        {
            var result = _cvForeignLanguageService.Delete(cvForeignLanguage);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll(int userId)
        {
            var result = _cvForeignLanguageService.GetAll(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int cvForeignLanguageId)
        {
            var result = _cvForeignLanguageService.GetById(cvForeignLanguageId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getcvforeignlanguagedto")]
        public IActionResult GetCvForeignLanguageDTO(int userId)
        {
            var result = _cvForeignLanguageService.GetCvForeignLanguageDTO(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getcvforeignlanguagedeleteddto")]
        public IActionResult GetCvForeignLanguageDeletedDTO(int userId)
        {
            var result = _cvForeignLanguageService.GetCvForeignLanguageDeletedDTO(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
