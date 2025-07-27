using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityDepartmentDescriptionsController : ControllerBase
    {
        IUniversityDepartmentDescriptionService _universityDepartmentDescriptionService;

        public UniversityDepartmentDescriptionsController(IUniversityDepartmentDescriptionService universityDepartmentDescriptionService)
        {
            _universityDepartmentDescriptionService = universityDepartmentDescriptionService;
        }

        [HttpPost("add")]
        public IActionResult Add(UniversityDepartmentDescription universitydepartmentDescription)
        {
            var result = _universityDepartmentDescriptionService.Add(universitydepartmentDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UniversityDepartmentDescription universitydepartmentDescription)
        {
            var result = _universityDepartmentDescriptionService.Update(universitydepartmentDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(UniversityDepartmentDescription universitydepartmentDescription)
        {
            var result = _universityDepartmentDescriptionService.Delete(universitydepartmentDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public IActionResult Terminate(UniversityDepartmentDescription universitydepartmentDescription)
        {
            var result = _universityDepartmentDescriptionService.Terminate(universitydepartmentDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _universityDepartmentDescriptionService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public IActionResult GetDeletedAll()
        {
            var result = _universityDepartmentDescriptionService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(string id)
        {
            var result = _universityDepartmentDescriptionService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getalldto")]
        public IActionResult GetAllDTO()
        {
            var result = _universityDepartmentDescriptionService.GetAllDTO();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedalldto")]
        public IActionResult GetDeletedAllDTO()
        {
            var result = _universityDepartmentDescriptionService.GetDeletedAllDTO();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getalldepartmentiddto")]
        public IActionResult GetAllByDeparttmetIdDTO(string id)
        {
            var result = _universityDepartmentDescriptionService.GetAllByUniversityDeparttmetIdDTO(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
