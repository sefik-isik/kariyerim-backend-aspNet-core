using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenceDegreesController : ControllerBase
    {
        ILicenceDegreeService _licenceDegreeService;

        public LicenceDegreesController(ILicenceDegreeService licenceDegreeService)
        {
            _licenceDegreeService = licenceDegreeService;
        }

        [HttpPost("add")]
        public IActionResult Add(LicenceDegree LicenceDegree)
        {
            var result = _licenceDegreeService.Add(LicenceDegree);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(LicenceDegree LicenceDegree)
        {
            var result = _licenceDegreeService.Update(LicenceDegree);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(LicenceDegree LicenceDegree)
        {
            var result = _licenceDegreeService.Delete(LicenceDegree);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _licenceDegreeService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _licenceDegreeService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
