using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseDegreesController : ControllerBase
    {
        ILicenseDegreeService _licenseDegreeService;

        public LicenseDegreesController(ILicenseDegreeService licenseDegreeService)
        {
            _licenseDegreeService = licenseDegreeService;
        }

        [HttpPost("add")]
        public IActionResult Add(LicenseDegree licenseDegree)
        {
            var result = _licenseDegreeService.Add(licenseDegree);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(LicenseDegree licenseDegree)
        {
            var result = _licenseDegreeService.Update(licenseDegree);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(LicenseDegree licenseDegree)
        {
            var result = _licenseDegreeService.Delete(licenseDegree);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public IActionResult Terminate(LicenseDegree licenseDegree)
        {
            var result = _licenseDegreeService.Terminate(licenseDegree);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _licenseDegreeService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getdeletedall")]
        public IActionResult GetDeletedAll()
        {
            var result = _licenseDegreeService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(string id)
        {
            var result = _licenseDegreeService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
