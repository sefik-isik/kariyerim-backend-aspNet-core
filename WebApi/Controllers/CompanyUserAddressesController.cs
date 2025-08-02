using Business.Abstract;
using Core.Entities.Concrete;
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
        public async Task<ActionResult> Add(CompanyUserAddress companyUserAddress)
        {
            var result = await _companyUserAddressService.Add(companyUserAddress);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(CompanyUserAddress companyUserAddress)
        {
            var result = await _companyUserAddressService.Update(companyUserAddress);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(CompanyUserAddress companyUserAddress)
        {
            var result = await _companyUserAddressService.Delete(companyUserAddress);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(CompanyUserAddress companyUserAddress)
        {
            var result = await _companyUserAddressService.Terminate(companyUserAddress);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getall")]
        public async Task<ActionResult> GetAll(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserAddressService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserAddressService.GetDeletedAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getbyid")]
        public async Task<ActionResult> GetById(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserAddressService.GetById(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPost("getalldto")]
        public async Task<ActionResult> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserAddressService.GetAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetDeletedAllDTO")]
        public async Task<ActionResult> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserAddressService.GetDeletedAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

    }
}
