using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelUserCvSummariesController : ControllerBase
    {
        IPersonelUserCvSummaryService _cvSummaryService;

        public PersonelUserCvSummariesController(IPersonelUserCvSummaryService cvSummaryService)
        {
            _cvSummaryService = cvSummaryService;
        }

        [HttpPost("add")]
        public IActionResult Add(PersonelUserCvSummary cvSummary)
        {
            var result = _cvSummaryService.Add(cvSummary);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(PersonelUserCvSummary cvSummary)
        {
            var result = _cvSummaryService.Update(cvSummary);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(PersonelUserCvSummary cvSummary)
        {
            var result = _cvSummaryService.Delete(cvSummary);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll(int userId)
        {
            var result = _cvSummaryService.GetAll(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int cvSummaryId)
        {
            var result = _cvSummaryService.GetById(cvSummaryId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
