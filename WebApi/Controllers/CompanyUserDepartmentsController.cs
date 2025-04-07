using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyUserDepartmentsController : ControllerBase
    {
        ICompanyUserDepartmentService _companyUserDepartmentService;

        public CompanyUserDepartmentsController(ICompanyUserDepartmentService companyUserDepartmentService)
        {
            _companyUserDepartmentService = companyUserDepartmentService;
        }

        [HttpPost("add")]
        public IActionResult Add(CompanyUserDepartment companyUserDepartment)
        {
            var result = _companyUserDepartmentService.Add(companyUserDepartment);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CompanyUserDepartment companyUserDepartment)
        {
            var result = _companyUserDepartmentService.Update(companyUserDepartment);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CompanyUserDepartment companyUserDepartment)
        {
            var result = _companyUserDepartmentService.Delete(companyUserDepartment);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll(int userId)
        {
            var result = _companyUserDepartmentService.GetAll(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int companyUserDepartmentId)
        {
            var result = _companyUserDepartmentService.GetById(companyUserDepartmentId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getcompanyuserdepartmentsdto")]
        public IActionResult GetCompanyUserDepartmentDTO(int userId)
        {
            var result = _companyUserDepartmentService.GetCompanyUserDepartmentDTO(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getcompanyuserdepartmentsdeleteddto")]
        public IActionResult GetCompanyUserDepartmentDeletedDTO(int userId)
        {
            var result = _companyUserDepartmentService.GetCompanyUserDepartmentDeletedDTO(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
