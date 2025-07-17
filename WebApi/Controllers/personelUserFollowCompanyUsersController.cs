using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class personelUserFollowCompanyUsersController : ControllerBase
    {
        IPersonelUserFollowCompanyUserService _personelUserFollowCompanyUserService;
        public personelUserFollowCompanyUsersController(IPersonelUserFollowCompanyUserService personelUserFollowCompanyUserService)
        {
            _personelUserFollowCompanyUserService = personelUserFollowCompanyUserService;
        }

        [HttpPost("add")]
        public IActionResult Add(PersonelUserFollowCompanyUser personelUserFollowCompanyUser)
        {
            var result = _personelUserFollowCompanyUserService.Add(personelUserFollowCompanyUser);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public IActionResult Terminate(PersonelUserFollowCompanyUser personelUserFollowCompanyUser)
        {
            var result = _personelUserFollowCompanyUserService.Terminate(personelUserFollowCompanyUser);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getall")]
        public IActionResult GetAll(UserAdminDTO userAdminDTO)
        {
            var result = _personelUserFollowCompanyUserService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getbyid")]
        public IActionResult GetById(string id)
        {
            var result = _personelUserFollowCompanyUserService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbycompanyid")]
        public IActionResult GetAllByCompanyId(string id)
        {
            var result = _personelUserFollowCompanyUserService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbypersonelid")]
        public IActionResult GetAllByPersonelId(string id)
        {
            var result = _personelUserFollowCompanyUserService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getalldto")]
        public IActionResult GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = _personelUserFollowCompanyUserService.GetAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbycompanyiddto")]
        public IActionResult GetAllByCompanyIdDTO(UserAdminDTO userAdminDTO)
        {
            var result = _personelUserFollowCompanyUserService.GetAllByCompanyIdDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbypersoneliddto")]
        public IActionResult GetAllByPersonelIdDTO(UserAdminDTO userAdminDTO)
        {
            var result = _personelUserFollowCompanyUserService.GetAllByPersonelIdDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
