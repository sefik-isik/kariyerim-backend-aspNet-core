using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertApplicationsController : ControllerBase
    {
        IAdvertApplicationService _advertApplicationService;
        public AdvertApplicationsController(IAdvertApplicationService advertApplicationService)
        {
            _advertApplicationService = advertApplicationService;
        }

        [HttpPost("add")]
        public IActionResult Add(AdvertApplication advertApplication)
        {
            var result = _advertApplicationService.Add(advertApplication);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public IActionResult Terminate(AdvertApplication advertApplication)
        {
            var result = _advertApplicationService.Terminate(advertApplication);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getall")]
        public IActionResult GetAll(UserAdminDTO userAdminDTO)
        {
            var result = _advertApplicationService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getbyid")]
        public IActionResult GetById(string id)
        {
            var result = _advertApplicationService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbycompanyid")]
        public IActionResult GetAllByCompanyId(string id)
        {
            var result = _advertApplicationService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbypersonelid")]
        public IActionResult GetAllByPersonelId(string id)
        {
            var result = _advertApplicationService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getalldto")]
        public IActionResult GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = _advertApplicationService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbycompanyiddto")]
        public IActionResult GetAllByCompanyIdDTO(string id)
        {
            var result = _advertApplicationService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbypersoneliddto")]
        public IActionResult GetAllByPersonelIdDTO(string id)
        {
            var result = _advertApplicationService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
