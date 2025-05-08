using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        [HttpPost("getall")]
        public IActionResult GetAll(UserAdminDTO userAdminDTO)
        {
            var result = _companyUserAddressService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getdeletedall")]
        public IActionResult GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var result = _companyUserAddressService.GetDeletedAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _companyUserAddressService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPost("getalldto")]
        public IActionResult GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = _companyUserAddressService.GetAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getalldeleteddto")]
        public IActionResult GetAllDeletedDTO(UserAdminDTO userAdminDTO)
        {
            var result = _companyUserAddressService.GetAllDeletedDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

    }
}
