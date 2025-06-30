using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverLicencesController : ControllerBase
    {
        IDriverLicenceService _driverLicenceService;

        public DriverLicencesController(IDriverLicenceService licenceService)
        {
            _driverLicenceService = licenceService;
        }

        [HttpPost("add")]
        public IActionResult Add(DriverLicence driverLicence)
        {
            var result = _driverLicenceService.Add(driverLicence);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(DriverLicence driverLicence)
        {
            var result = _driverLicenceService.Update(driverLicence);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(DriverLicence driverLicence)
        {
            var result = _driverLicenceService.Delete(driverLicence);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public IActionResult Terminate(DriverLicence driverLicence)
        {
            var result = _driverLicenceService.Terminate(driverLicence);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _driverLicenceService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public IActionResult GetDeletedAll()
        {
            var result = _driverLicenceService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(string id)
        {
            var result = _driverLicenceService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
