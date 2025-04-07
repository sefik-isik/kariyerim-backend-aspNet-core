using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverLicensesController : ControllerBase
    {
        IDriverLicenseService _licenseService;

        public DriverLicensesController(IDriverLicenseService licenseService)
        {
            _licenseService = licenseService;
        }

        [HttpPost("add")]
        public IActionResult Add(DriverLicense driverLicense)
        {
            var result = _licenseService.Add(driverLicense);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(DriverLicense driverLicense)
        {
            var result = _licenseService.Update(driverLicense);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(DriverLicense driverLicense)
        {
            var result = _licenseService.Delete(driverLicense);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _licenseService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int driverLicenseId)
        {
            var result = _licenseService.GetById(driverLicenseId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
