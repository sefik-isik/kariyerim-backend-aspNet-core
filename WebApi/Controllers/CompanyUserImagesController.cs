using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyUserImagesController : ControllerBase
    {
        ICompanyUserImageService _companyUserImageService;

        public CompanyUserImagesController(ICompanyUserImageService companyUserImageService)
        {
            _companyUserImageService = companyUserImageService;
        }

        [HttpPost("add")]
        public IActionResult Add(CompanyUserImage companyUserImage)
        {
            var result = _companyUserImageService.Add(companyUserImage);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CompanyUserImage companyUserImage)
        {
            var result = _companyUserImageService.Update(companyUserImage);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CompanyUserImage companyUserImage)
        {
            var result = _companyUserImageService.Delete(companyUserImage);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll(int userId)
        {
            var result = _companyUserImageService.GetAll(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int companyUserImageId)
        {
            var result = _companyUserImageService.GetById(companyUserImageId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getcompanyuserimagedto")]
        public IActionResult GetCompanyUserImagetDTO(int userId)
        {
            var result = _companyUserImageService.GetCompanyUserImageDTO(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getcompanyuserimagedeleteddto")]
        public IActionResult GetCompanyUserImageDeletedDTO(int userId)
        {
            var result = _companyUserImageService.GetCompanyUserImageDeletedDTO(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
