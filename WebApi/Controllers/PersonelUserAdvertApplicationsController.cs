using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelUserAdvertApplicationsController : ControllerBase
    {
        IPersonelUserAdvertApplicationService _personelUseradvertApplicationService;
        public PersonelUserAdvertApplicationsController(IPersonelUserAdvertApplicationService advertApplicationService)
        {
            _personelUseradvertApplicationService = advertApplicationService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(PersonelUserAdvertApplication advertApplication)
        {
            var result = await _personelUseradvertApplicationService.Add(advertApplication);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(PersonelUserAdvertApplication advertApplication)
        {
            var result = await _personelUseradvertApplicationService.Terminate(advertApplication);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getall")]
        public async Task<ActionResult> GetAll(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUseradvertApplicationService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getbyid")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _personelUseradvertApplicationService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbycompanyid")]
        public async Task<ActionResult> GetAllByCompanyId(string id)
        {
            var result = await _personelUseradvertApplicationService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbypersonelid")]
        public async Task<ActionResult> GetAllByPersonelId(string id)
        {
            var result = await _personelUseradvertApplicationService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getalldto")]
        public async Task<ActionResult> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUseradvertApplicationService.GetAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbycompanyiddto")]
        public async Task<ActionResult> GetAllByCompanyUserIdDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUseradvertApplicationService.GetAllByCompanyUserIdDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbypersoneliddto")]
        public async Task<ActionResult> GetAllByPersonelIdDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUseradvertApplicationService.GetAllByPersonelUserIdDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbyadvertiddto")]
        public async Task<ActionResult> GetAllByAdvertIdDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUseradvertApplicationService.GetAllByAdvertIdDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
