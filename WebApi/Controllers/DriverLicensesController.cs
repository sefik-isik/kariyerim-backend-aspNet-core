using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverLicencesController : ControllerBase
    {
        IDriverLicenceService _licenceService;

        public DriverLicencesController(IDriverLicenceService licenceService)
        {
            _licenceService = licenceService;
        }

        [HttpPost("add")]
        public IActionResult Add(DriverLicence driverLicence)
        {
            var result = _licenceService.Add(driverLicence);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(DriverLicence driverLicence)
        {
            var result = _licenceService.Update(driverLicence);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(DriverLicence driverLicence)
        {
            var result = _licenceService.Delete(driverLicence);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _licenceService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public IActionResult GetDeletedAll()
        {
            var result = _licenceService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _licenceService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
