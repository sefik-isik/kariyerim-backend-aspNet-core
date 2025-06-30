using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyUserAdvertJobDescriptionsController : ControllerBase
    {
        ICompanyUserAdvertJobDescriptionService _companyUserAdvertJobDescriptionService;
        public CompanyUserAdvertJobDescriptionsController(ICompanyUserAdvertJobDescriptionService companyUserAdvertJobDescriptionService)
        {
            _companyUserAdvertJobDescriptionService = companyUserAdvertJobDescriptionService;
        }

        [HttpPost("add")]
        public IActionResult Add(CompanyUserAdvertJobDescription companyUserAdvertJobDescription)
        {
            var result = _companyUserAdvertJobDescriptionService.Add(companyUserAdvertJobDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CompanyUserAdvertJobDescription companyUserAdvertJobDescription)
        {
            var result = _companyUserAdvertJobDescriptionService.Update(companyUserAdvertJobDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CompanyUserAdvertJobDescription companyUserAdvertJobDescription)
        {
            var result = _companyUserAdvertJobDescriptionService.Delete(companyUserAdvertJobDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public IActionResult Terminate(CompanyUserAdvertJobDescription companyUserAdvertJobDescription)
        {
            var result = _companyUserAdvertJobDescriptionService.Terminate(companyUserAdvertJobDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getall")]
        public IActionResult GetAll(UserAdminDTO userAdminDTO)
        {
            var result = _companyUserAdvertJobDescriptionService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getdeletedall")]
        public IActionResult GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var result = _companyUserAdvertJobDescriptionService.GetDeletedAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getbyid")]
        public IActionResult GetById(UserAdminDTO userAdminDTO)
        {
            var result = _companyUserAdvertJobDescriptionService.GetById(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPost("getalldto")]
        public IActionResult GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = _companyUserAdvertJobDescriptionService.GetAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetDeletedAllDTO")]
        public IActionResult GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = _companyUserAdvertJobDescriptionService.GetDeletedAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
