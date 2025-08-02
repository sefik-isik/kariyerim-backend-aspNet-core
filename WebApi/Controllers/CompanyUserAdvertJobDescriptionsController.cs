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
        public async Task<ActionResult> Add(CompanyUserAdvertJobDescription companyUserAdvertJobDescription)
        {
            var result = await _companyUserAdvertJobDescriptionService.Add(companyUserAdvertJobDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(CompanyUserAdvertJobDescription companyUserAdvertJobDescription)
        {
            var result = await _companyUserAdvertJobDescriptionService.Update(companyUserAdvertJobDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(CompanyUserAdvertJobDescription companyUserAdvertJobDescription)
        {
            var result = await _companyUserAdvertJobDescriptionService.Delete(companyUserAdvertJobDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(CompanyUserAdvertJobDescription companyUserAdvertJobDescription)
        {
            var result = await _companyUserAdvertJobDescriptionService.Terminate(companyUserAdvertJobDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getall")]
        public async Task<ActionResult> GetAll(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserAdvertJobDescriptionService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserAdvertJobDescriptionService.GetDeletedAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getbyid")]
        public async Task<ActionResult> GetById(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserAdvertJobDescriptionService.GetById(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPost("getalldto")]
        public async Task<ActionResult> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserAdvertJobDescriptionService.GetAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetDeletedAllDTO")]
        public async Task<ActionResult> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserAdvertJobDescriptionService.GetDeletedAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
