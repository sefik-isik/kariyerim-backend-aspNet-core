using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyUsersController : ControllerBase
    {
        ICompanyUserService _companyUserService;

        public CompanyUsersController(ICompanyUserService companyUserService)
        {
            _companyUserService = companyUserService;
        }

        [HttpPost("add")]
        public IActionResult Add(CompanyUser companyUser)
        {
            var result = _companyUserService.Add(companyUser);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CompanyUser companyUser)
        {
            var result = _companyUserService.Update(companyUser);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CompanyUser companyUser)
        {
            var result = _companyUserService.Delete(companyUser);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll(int userId)
        {
            var result = _companyUserService.GetAll(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int companyUserId)
        {
            var result = _companyUserService.GetById(companyUserId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdto")]
        public IActionResult GetCompanyUserDTO(int userId)
        {
            var result = _companyUserService.GetCompanyUserDTO(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeleteddto")]
        public IActionResult GetCompanyUserDeletedDTO(int userId)
        {
            var result = _companyUserService.GetCompanyUserDeletedDTO(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
