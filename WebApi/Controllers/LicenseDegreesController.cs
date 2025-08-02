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
        public async Task<ActionResult> Add(LicenseDegree licenseDegree)
        {
            var result = await _licenseDegreeService.Add(licenseDegree);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(LicenseDegree licenseDegree)
        {
            var result = await _licenseDegreeService.Update(licenseDegree);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(LicenseDegree licenseDegree)
        {
            var result = await _licenseDegreeService.Delete(licenseDegree);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(LicenseDegree licenseDegree)
        {
            var result = await _licenseDegreeService.Terminate(licenseDegree);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _licenseDegreeService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll()
        {
            var result = await _licenseDegreeService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getbyid")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _licenseDegreeService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
