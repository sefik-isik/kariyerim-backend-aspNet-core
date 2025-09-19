using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyUserAdvertCitiesController : ControllerBase
    {
        ICompanyUserAdvertCityService _companyUserAdvertCityService;
        public CompanyUserAdvertCitiesController(ICompanyUserAdvertCityService companyUserAdvertCityService)
        {
            _companyUserAdvertCityService = companyUserAdvertCityService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(CompanyUserAdvertCity companyUserAdvertCity)
        {
            var result = await _companyUserAdvertCityService.Add(companyUserAdvertCity);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(CompanyUserAdvertCity companyUserAdvertCity)
        {
            var result = await _companyUserAdvertCityService.Update(companyUserAdvertCity);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(CompanyUserAdvertCity companyUserAdvertCity)
        {
            var result = await _companyUserAdvertCityService.Delete(companyUserAdvertCity);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(CompanyUserAdvertCity companyUserAdvertCity)
        {
            var result = await _companyUserAdvertCityService.Terminate(companyUserAdvertCity);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getall")]
        public async Task<ActionResult> GetAll(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserAdvertCityService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserAdvertCityService.GetDeletedAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getbyid")]
        public async Task<ActionResult> GetById(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserAdvertCityService.GetById(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPost("getalldto")]
        public async Task<ActionResult> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserAdvertCityService.GetAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getdeletedalldto")]
        public async Task<ActionResult> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserAdvertCityService.GetDeletedAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getallbyiddto")]
        public async Task<ActionResult> GetAllByIdDTO(string id)
        {
            var result = await _companyUserAdvertCityService.GetAllByIdDTO(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
