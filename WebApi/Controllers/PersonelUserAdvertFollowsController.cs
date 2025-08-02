using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelUserAdvertFollowsController : ControllerBase
    {
        IPersonelUserAdvertFollowService _personelUserAdvertFollowService;
        public PersonelUserAdvertFollowsController(IPersonelUserAdvertFollowService advertFollowService)
        {
            _personelUserAdvertFollowService = advertFollowService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(PersonelUserAdvertFollow advertFollow)
        {
            var result = await _personelUserAdvertFollowService.Add(advertFollow);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(PersonelUserAdvertFollow advertFollow)
        {
            var result = await _personelUserAdvertFollowService.Terminate(advertFollow);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getall")]
        public async Task<ActionResult> GetAll(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUserAdvertFollowService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getbyid")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _personelUserAdvertFollowService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbycompanyid")]
        public async Task<ActionResult> GetAllByCompanyId(string id)
        {
            var result = await _personelUserAdvertFollowService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbypersonelid")]
        public async Task<ActionResult> GetAllByPersonelId(string id)
        {
            var result = await _personelUserAdvertFollowService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getalldto")]
        public async Task<ActionResult> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUserAdvertFollowService.GetAllDTO(userAdminDTO.Id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbyadvertiddto")]
        public async Task<ActionResult> GetAllByAdvertIdDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUserAdvertFollowService.GetAllByAdvertIdDTO(userAdminDTO.Id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbypersoneliddto")]
        public async Task<ActionResult> GetAllByPersonelIdDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUserAdvertFollowService.GetAllByPersonelIdDTO(userAdminDTO.Id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

    }
}
