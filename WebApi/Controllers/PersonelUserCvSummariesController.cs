using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        [HttpPost("getall")]
        public IActionResult GetAll(UserAdminDTO userAdminDTO)
        {
            var result = _cvSummaryService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getdeletedall")]
        public IActionResult GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var result = _cvSummaryService.GetDeletedAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getbyid")]
        public IActionResult GetById(UserAdminDTO userAdminDTO)
        {
            var result = _cvSummaryService.GetById(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
