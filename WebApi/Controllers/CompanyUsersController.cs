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
        public IActionResult GetAll(int id)
        {
            var result = _companyUserService.GetAll(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public IActionResult GetDeletedAll(int id)
        {
            var result = _companyUserService.GetDeletedAll(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _companyUserService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getalldto")]
        public IActionResult GetAllDTO(int id)
        {
            var result = _companyUserService.GetAllDTO(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getalldeleteddto")]
        public IActionResult GetAllDeletedDTO(int id)
        {
            var result = _companyUserService.GetAllDeletedDTO(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

    }
}
