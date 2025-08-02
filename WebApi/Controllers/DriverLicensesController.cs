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
        public async Task<ActionResult> Add(DriverLicence driverLicence)
        {
            var result = await _driverLicenceService.Add(driverLicence);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(DriverLicence driverLicence)
        {
            var result = await _driverLicenceService.Update(driverLicence);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(DriverLicence driverLicence)
        {
            var result = await _driverLicenceService.Delete(driverLicence);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(DriverLicence driverLicence)
        {
            var result = await _driverLicenceService.Terminate(driverLicence);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _driverLicenceService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll()
        {
            var result = await _driverLicenceService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _driverLicenceService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
