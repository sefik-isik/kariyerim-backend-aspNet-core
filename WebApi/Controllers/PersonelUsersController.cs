using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelUsersController : ControllerBase
    {
        IPersonelUserService _personelUserService;

        public PersonelUsersController(IPersonelUserService personelUserService)
        {
            _personelUserService = personelUserService;
        }

        [HttpPost("add")]
        public IActionResult Add(PersonelUser personelUser)
        {
            var result = _personelUserService.Add(personelUser);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(PersonelUser personelUser)
        {
            var result = _personelUserService.Update(personelUser);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(PersonelUser personelUser)
        {
            var result = _personelUserService.Delete(personelUser);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getall")]
        public IActionResult GetAll(UserAdminDTO userAdminDTO)
        {
            var result = _personelUserService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getdeletedall")]
        public IActionResult GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var result = _personelUserService.GetDeletedAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getbyid")]
        public IActionResult GetById(UserAdminDTO userAdminDTO)
        {
            var result = _personelUserService.GetByAdminId(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getalldto")]
        public IActionResult GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = _personelUserService.GetAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetDeletedAllDTO")]
        public IActionResult GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = _personelUserService.GetDeletedAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

    }
}
