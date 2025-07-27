using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        [HttpPost("terminate")]
        public IActionResult Terminate(CompanyUserDepartment companyUserDepartment)
        {
            var result = _companyUserDepartmentService.Terminate(companyUserDepartment);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _companyUserDepartmentService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public IActionResult GetDeletedAll()
        {
            var result = _companyUserDepartmentService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(string id)
        {
            var result = _companyUserDepartmentService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
