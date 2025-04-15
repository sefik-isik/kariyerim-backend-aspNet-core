using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyUserAddressesController : ControllerBase
    {
        ICompanyUserAddressService _companyUserAddressService;

        public CompanyUserAddressesController(ICompanyUserAddressService companyUserAddressService)
        {
            _companyUserAddressService = companyUserAddressService;
        }

        [HttpPost("add")]
        public IActionResult Add(CompanyUserAddress companyUserAddress)
        {
            var result = _companyUserAddressService.Add(companyUserAddress);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CompanyUserAddress companyUserAddress)
        {
            var result = _companyUserAddressService.Update(companyUserAddress);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CompanyUserAddress companyUserAddress)
        {
            var result = _companyUserAddressService.Delete(companyUserAddress);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll(int userId)
        {
            var result = _companyUserAddressService.GetAll(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int companyUserAddressId)
        {
            var result = _companyUserAddressService.GetById(companyUserAddressId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getdto")]
        public IActionResult GetCompanyUserAddressDTO(int userId)
        {
            var result = _companyUserAddressService.GetCompanyUserAddressDTO(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeleteddto")]
        public IActionResult GetCompanyUserAddressDeletedDTO(int userId)
        {
            var result = _companyUserAddressService.GetCompanyUserAddressDeletedDTO(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
