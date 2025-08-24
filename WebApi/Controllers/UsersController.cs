using Business.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using Entities.PageModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("getbyiddto")]
        public async Task<ActionResult> GetByIdDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _userService.GetByIdDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(User user)
        {
            var result = await _userService.Update(user);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(User user)
        {
            var result = await _userService.Delete(user);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(User user)
        {
            var result = await _userService.Terminate(user);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getalldto")]
        public async Task<ActionResult> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _userService.GetAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallcompanyuserdto")]
        public async Task<ActionResult> GetAllCompanyUserDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _userService.GetAllCompanyUserDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallpersoneluserdto")]
        public async Task<ActionResult> GetAllPersonelUserDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _userService.GetAllPersonelUserDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbypage")]
        public async Task<ActionResult> GetAllByPage(UserPageModel userPageModel)
        {
            var result = await _userService.GetAllByPage(userPageModel);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetDeletedAllDTO")]
        public async Task<ActionResult> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _userService.GetDeletedAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

    }
}
