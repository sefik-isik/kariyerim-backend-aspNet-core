using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelUserAddressesController : ControllerBase
    {
        IPersonelUserAddressService _personelUserAddressService;

        public PersonelUserAddressesController(IPersonelUserAddressService personelUserAddressService)
        {
            _personelUserAddressService = personelUserAddressService;
        }

        [HttpPost("add")]
        public IActionResult Add(PersonelUserAddress personelUserAddress)
        {
            var result = _personelUserAddressService.Add(personelUserAddress);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(PersonelUserAddress personelUserAddress)
        {
            var result = _personelUserAddressService.Update(personelUserAddress);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(PersonelUserAddress personelUserAddress)
        {
            var result = _personelUserAddressService.Delete(personelUserAddress);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll(int userId)
        {
            var result = _personelUserAddressService.GetAll(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int personelUserAddressId)
        {
            var result = _personelUserAddressService.GetById(personelUserAddressId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdto")]
        public IActionResult GetUserAddressDTO(int userId)
        {
            var result = _personelUserAddressService.GetUserAddressDTO(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeleteddto")]
        public IActionResult GetUserAddressDeletedDTO(int userId)
        {
            var result = _personelUserAddressService.GetUserAddressDeletedDTO(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
