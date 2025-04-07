using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyUserFilesController : ControllerBase
    {
        ICompanyUserFileService _companyUserFileService;

        public CompanyUserFilesController(ICompanyUserFileService companyUserFileService)
        {
            _companyUserFileService = companyUserFileService;
        }

        [HttpPost("add")]
        public IActionResult Add(CompanyUserFile companyUserFile)
        {
            var result = _companyUserFileService.Add(companyUserFile);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CompanyUserFile companyUserFile)
        {
            var result = _companyUserFileService.Update(companyUserFile);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CompanyUserFile companyUserFile)
        {
            var result = _companyUserFileService.Delete(companyUserFile);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll(int userId)
        {
            var result = _companyUserFileService.GetAll(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int companyUserFileId)
        {
            var result = _companyUserFileService.GetById(companyUserFileId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getcompanyuserfiledto")]
        public IActionResult GetCompanyUserFiletDTO(int userId)
        {
            var result = _companyUserFileService.GetCompanyUserFileDTO(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getcompanyuserfiledeleteddto")]
        public IActionResult GetCompanyUserFileDeletedDTO(int userId)
        {
            var result = _companyUserFileService.GetCompanyUserFileDeletedDTO(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
