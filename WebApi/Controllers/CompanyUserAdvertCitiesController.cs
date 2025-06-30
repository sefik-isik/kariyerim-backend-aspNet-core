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
        public IActionResult Add(CompanyUserAdvertCity companyUserAdvertCity)
        {
            var result = _companyUserAdvertCityService.Add(companyUserAdvertCity);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CompanyUserAdvertCity companyUserAdvertCity)
        {
            var result = _companyUserAdvertCityService.Update(companyUserAdvertCity);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CompanyUserAdvertCity companyUserAdvertCity)
        {
            var result = _companyUserAdvertCityService.Delete(companyUserAdvertCity);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public IActionResult Terminate(CompanyUserAdvertCity companyUserAdvertCity)
        {
            var result = _companyUserAdvertCityService.Terminate(companyUserAdvertCity);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getall")]
        public IActionResult GetAll(UserAdminDTO userAdminDTO)
        {
            var result = _companyUserAdvertCityService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getdeletedall")]
        public IActionResult GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var result = _companyUserAdvertCityService.GetDeletedAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getbyid")]
        public IActionResult GetById(UserAdminDTO userAdminDTO)
        {
            var result = _companyUserAdvertCityService.GetById(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPost("getalldto")]
        public IActionResult GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = _companyUserAdvertCityService.GetAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetDeletedAllDTO")]
        public IActionResult GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = _companyUserAdvertCityService.GetDeletedAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
