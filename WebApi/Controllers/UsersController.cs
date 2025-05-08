using Business.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
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
        public IActionResult GetByIdDTO(UserAdminDTO userAdminDTO)
        {
            var result = _userService.GetByIdDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getcode")]
        public IActionResult GetCode(UserAdminDTO userAdminDTO)
        {
            var result = _userService.GetCode(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getalldto")]
        public IActionResult GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = _userService.GetAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallcompanyuserdto")]
        public IActionResult GetAllCompanyUserDTO(UserAdminDTO userAdminDTO)
        {
            var result = _userService.GetAllCompanyUserDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallpersoneluserdto")]
        public IActionResult GetAllPersonelUserDTO(UserAdminDTO userAdminDTO)
        {
            var result = _userService.GetAllPersonelUserDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getalldeleteddto")]
        public IActionResult GetAllDeletedDTO(UserAdminDTO userAdminDTO)
        {
            var result = _userService.GetAllDeletedDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

    }
}
