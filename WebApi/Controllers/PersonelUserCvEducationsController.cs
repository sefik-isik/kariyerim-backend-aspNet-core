using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelUserCvEducationsController : ControllerBase
    {
        IPersonelUserCvEducationService _cvEducationService;

        public PersonelUserCvEducationsController(IPersonelUserCvEducationService cvEducationService)
        {
            _cvEducationService = cvEducationService;
        }

        [HttpPost("add")]
        public IActionResult Add(PersonelUserCvEducation cvEducation)
        {
            var result = _cvEducationService.Add(cvEducation);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(PersonelUserCvEducation cvEducation)
        {
            var result = _cvEducationService.Update(cvEducation);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(PersonelUserCvEducation cvEducation)
        {
            var result = _cvEducationService.Delete(cvEducation);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll(int userId)
        {
            var result = _cvEducationService.GetAll(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int cvEducationId)
        {
            var result = _cvEducationService.GetById(cvEducationId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("cveducationdto")]
        public IActionResult GetCvEducationDTO(int userId)
        {
            var result = _cvEducationService.GetCvEducationDTO(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("cveducationdeleteddto")]
        public IActionResult GetCvEducationDeletedDTO(int userId)
        {
            var result = _cvEducationService.GetCvEducationDeletedDTO(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
