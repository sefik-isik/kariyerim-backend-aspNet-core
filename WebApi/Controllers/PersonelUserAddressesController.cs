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
        public IActionResult GetAll(int id)
        {
            var result = _personelUserAddressService.GetAll(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public IActionResult GetDeletedAll(int id)
        {
            var result = _personelUserAddressService.GetDeletedAll(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _personelUserAddressService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getalldto")]
        public IActionResult GetAllDTO(int id)
        {
            var result = _personelUserAddressService.GetAllDTO(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getalldeleteddto")]
        public IActionResult GetAllDeletedDTO(int id)
        {
            var result = _personelUserAddressService.GetAllDeletedDTO(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
