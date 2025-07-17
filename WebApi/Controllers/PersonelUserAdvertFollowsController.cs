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
        public IActionResult Add(PersonelUserAdvertFollow advertFollow)
        {
            var result = _personelUserAdvertFollowService.Add(advertFollow);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public IActionResult Terminate(PersonelUserAdvertFollow advertFollow)
        {
            var result = _personelUserAdvertFollowService.Terminate(advertFollow);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getall")]
        public IActionResult GetAll(UserAdminDTO userAdminDTO)
        {
            var result = _personelUserAdvertFollowService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getbyid")]
        public IActionResult GetById(string id)
        {
            var result = _personelUserAdvertFollowService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbycompanyid")]
        public IActionResult GetAllByCompanyId(string id)
        {
            var result = _personelUserAdvertFollowService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbypersonelid")]
        public IActionResult GetAllByPersonelId(string id)
        {
            var result = _personelUserAdvertFollowService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getalldto")]
        public IActionResult GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = _personelUserAdvertFollowService.GetAllDTO(userAdminDTO.Id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbyadvertiddto")]
        public IActionResult GetAllByAdvertIdDTO(UserAdminDTO userAdminDTO)
        {
            var result = _personelUserAdvertFollowService.GetAllByAdvertIdDTO(userAdminDTO.Id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbypersoneliddto")]
        public IActionResult GetAllByPersonelIdDTO(UserAdminDTO userAdminDTO)
        {
            var result = _personelUserAdvertFollowService.GetAllByPersonelIdDTO(userAdminDTO.Id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

    }
}
