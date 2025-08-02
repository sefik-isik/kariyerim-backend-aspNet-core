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
        public async Task<ActionResult> Add(PersonelUserFollowCompanyUser personelUserFollowCompanyUser)
        {
            var result = await _personelUserFollowCompanyUserService.Add(personelUserFollowCompanyUser);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(PersonelUserFollowCompanyUser personelUserFollowCompanyUser)
        {
            var result = await _personelUserFollowCompanyUserService.Terminate(personelUserFollowCompanyUser);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getall")]
        public async Task<ActionResult> GetAll(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUserFollowCompanyUserService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getbyid")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _personelUserFollowCompanyUserService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbycompanyid")]
        public async Task<ActionResult> GetAllByCompanyId(string id)
        {
            var result = await _personelUserFollowCompanyUserService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbypersonelid")]
        public async Task<ActionResult> GetAllByPersonelId(string id)
        {
            var result = await _personelUserFollowCompanyUserService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getalldto")]
        public async Task<ActionResult> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUserFollowCompanyUserService.GetAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbycompanyiddto")]
        public async Task<ActionResult> GetAllByCompanyIdDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUserFollowCompanyUserService.GetAllByCompanyIdDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbypersoneliddto")]
        public async Task<ActionResult> GetAllByPersonelIdDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUserFollowCompanyUserService.GetAllByPersonelIdDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
