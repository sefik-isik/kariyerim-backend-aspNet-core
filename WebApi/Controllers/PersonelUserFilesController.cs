using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelUserFilesController : ControllerBase
    {
        IPersonelUserFileService _personelUserFileService;

        public PersonelUserFilesController(IPersonelUserFileService personelUserFileService)
        {
            _personelUserFileService = personelUserFileService;
        }

        [HttpPost("add")]
        public IActionResult Add(PersonelUserFile personelUserFile)
        {
            var result = _personelUserFileService.Add(personelUserFile);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(PersonelUserFile personelUserFile)
        {
            var result = _personelUserFileService.Update(personelUserFile);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(PersonelUserFile personelUserFile)
        {
            var result = _personelUserFileService.Delete(personelUserFile);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll(int userId)
        {
            var result = _personelUserFileService.GetAll(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int personelUserFile)
        {
            var result = _personelUserFileService.GetById(personelUserFile);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getpersoneluserfileDTO")]
        public IActionResult GetPersonelUserFiletDTO(int userId)
        {
            var result = _personelUserFileService.GetPersonelUserFileDTO(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getpersoneluserfiledeletedDTO")]
        public IActionResult GetPersonelUserFileDeletedDTO(int userId)
        {
            var result = _personelUserFileService.GetPersonelUserFileDeletedDTO(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
