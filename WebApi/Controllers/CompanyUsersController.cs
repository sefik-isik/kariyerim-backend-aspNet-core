using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        [HttpPost("getall")]
        public IActionResult GetAll(UserAdminDTO userAdminDTO)
        {
            var result = _companyUserService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getdeletedall")]
        public IActionResult GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var result = _companyUserService.GetDeletedAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getbyid")]
        public IActionResult GetById(UserAdminDTO userAdminDTO)
        {
            var result = _companyUserService.GetByAdminId(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getalldto")]
        public IActionResult GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = _companyUserService.GetAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetDeletedAllDTO")]
        public IActionResult GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = _companyUserService.GetDeletedAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

    }
}
