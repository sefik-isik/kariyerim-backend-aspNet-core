using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityFacultiesController : ControllerBase
    {
        IUniversityFacultyService _universityFacultyService;

        public UniversityFacultiesController(IUniversityFacultyService universityFacultyService)
        {
            _universityFacultyService = universityFacultyService;
        }

        [HttpPost("add")]
        public IActionResult Add(UniversityFaculty universityFaculty)
        {
            var result = _universityFacultyService.Add(universityFaculty);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UniversityFaculty universityFaculty)
        {
            var result = _universityFacultyService.Update(universityFaculty);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(UniversityFaculty universityFaculty)
        {
            var result = _universityFacultyService.Delete(universityFaculty);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public IActionResult Terminate(UniversityFaculty universityFaculty)
        {
            var result = _universityFacultyService.Terminate(universityFaculty);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _universityFacultyService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public IActionResult GetDeletedAll()
        {
            var result = _universityFacultyService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(string id)
        {
            var result = _universityFacultyService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
