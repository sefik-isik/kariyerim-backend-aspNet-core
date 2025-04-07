using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxOfficesController : ControllerBase
    {
        ITaxOfficeService _officeService;

        public TaxOfficesController(ITaxOfficeService officeService)
        {
            _officeService = officeService;
        }

        [HttpPost("add")]
        public IActionResult Add(TaxOffice taxOffice)
        {
            var result = _officeService.Add(taxOffice);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(TaxOffice taxOffice)
        {
            var result = _officeService.Update(taxOffice);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(TaxOffice taxOffice)
        {
            var result = _officeService.Delete(taxOffice);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _officeService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int taxOfficeId)
        {
            var result = _officeService.GetById(taxOfficeId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
