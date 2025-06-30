using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyFollowsController : ControllerBase
    {
        ICompanyFollowService _companyFollowService;
        public CompanyFollowsController(ICompanyFollowService companyFollowService)
        {
            _companyFollowService = companyFollowService;
        }

        [HttpPost("add")]
        public IActionResult Add(CompanyFollow companyFollow)
        {
            var result = _companyFollowService.Add(companyFollow);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public IActionResult Terminate(CompanyFollow companyFollow)
        {
            var result = _companyFollowService.Terminate(companyFollow);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getall")]
        public IActionResult GetAll(UserAdminDTO userAdminDTO)
        {
            var result = _companyFollowService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getbyid")]
        public IActionResult GetById(string id)
        {
            var result = _companyFollowService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbycompanyid")]
        public IActionResult GetAllByCompanyId(string id)
        {
            var result = _companyFollowService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbypersonelid")]
        public IActionResult GetAllByPersonelId(string id)
        {
            var result = _companyFollowService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getalldto")]
        public IActionResult GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = _companyFollowService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbycompanyiddto")]
        public IActionResult GetAllByCompanyIdDTO(string id)
        {
            var result = _companyFollowService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbypersoneliddto")]
        public IActionResult GetAllByPersonelIdDTO(string id)
        {
            var result = _companyFollowService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
