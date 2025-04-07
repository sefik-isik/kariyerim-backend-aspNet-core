using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelUserCoverLettersController : ControllerBase
    {
        IPersonelUserCoverLetterService _personelUserCoverLetterService;

        public PersonelUserCoverLettersController(IPersonelUserCoverLetterService personelUserCoverLetter)
        {
            _personelUserCoverLetterService = personelUserCoverLetter;
        }

        [HttpPost("add")]
        public IActionResult Add(PersonelUserCoverLetter personelUserCoverLetter)
        {
            var result = _personelUserCoverLetterService.Add(personelUserCoverLetter);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(PersonelUserCoverLetter personelUserCoverLetter)
        {
            var result = _personelUserCoverLetterService.Update(personelUserCoverLetter);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(PersonelUserCoverLetter personelUserCoverLetter)
        {
            var result = _personelUserCoverLetterService.Delete(personelUserCoverLetter);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll(int userId)
        {
            var result = _personelUserCoverLetterService.GetAll(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int personelUserCoverLetterId)
        {
            var result = _personelUserCoverLetterService.GetById(personelUserCoverLetterId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
