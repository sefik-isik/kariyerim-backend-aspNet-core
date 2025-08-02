using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entities.PageModel;
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
        public async Task<ActionResult> Add(CompanyUser companyUser)
        {
            var result = await _companyUserService.Add(companyUser);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(CompanyUser companyUser)
        {
            var result = await _companyUserService.Update(companyUser);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(CompanyUser companyUser)
        {
            var result = await _companyUserService.Delete(companyUser);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(CompanyUser companyUser)
        {
            var result = await _companyUserService.Terminate(companyUser);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getall")]
        public async Task<ActionResult> GetAll(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserService.GetDeletedAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getallbypage")]
        public async Task<ActionResult> GetAllByPage(string? sortColumn, string? sortOrder, int pageIndex = 0, int pageSize = 100)
        {
            CompanyUserPageModel positionPageModel = new CompanyUserPageModel
            {
                SortColumn = sortColumn,
                SortOrder = sortOrder,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            var result = await _companyUserService.GetAllByPage(positionPageModel);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getbyid")]
        public async Task<ActionResult> GetById(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserService.GetByAdminId(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getalldto")]
        public async Task<ActionResult> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserService.GetAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetDeletedAllDTO")]
        public async Task<ActionResult> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserService.GetDeletedAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

    }
}
