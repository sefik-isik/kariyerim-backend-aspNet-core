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
        public async Task<ActionResult> Add(CompanyUserDepartment companyUserDepartment)
        {
            var result = await _companyUserDepartmentService.Add(companyUserDepartment);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(CompanyUserDepartment companyUserDepartment)
        {
            var result = await _companyUserDepartmentService.Update(companyUserDepartment);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(CompanyUserDepartment companyUserDepartment)
        {
            var result = await _companyUserDepartmentService.Delete(companyUserDepartment);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(CompanyUserDepartment companyUserDepartment)
        {
            var result = await _companyUserDepartmentService.Terminate(companyUserDepartment);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _companyUserDepartmentService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll()
        {
            var result = await _companyUserDepartmentService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _companyUserDepartmentService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
