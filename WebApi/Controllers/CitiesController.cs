using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpPost("add")]
        public IActionResult Add(City city)
        {
            var result = _cityService.Add(city);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(City city)
        {
            var result = _cityService.Update(city);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(City city)
        {
            var result = _cityService.Delete(city);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _cityService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int cityId)
        {
            var result = _cityService.GetById(cityId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getcitydto")]
        public IActionResult GetCityDTO()
        {
            var result = _cityService.GetCityDTO();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getcitydeleteddto")]
        public IActionResult GetCityDletedDTO()
        {
            var result = _cityService.GetCityDeletedDTO();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

    }
}
