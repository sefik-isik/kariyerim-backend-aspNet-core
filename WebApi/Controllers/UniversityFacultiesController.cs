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
        public async Task<ActionResult> Add(UniversityFaculty universityFaculty)
        {
            var result = await _universityFacultyService.Add(universityFaculty);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(UniversityFaculty universityFaculty)
        {
            var result = await _universityFacultyService.Update(universityFaculty);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(UniversityFaculty universityFaculty)
        {
            var result = await _universityFacultyService.Delete(universityFaculty);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(UniversityFaculty universityFaculty)
        {
            var result = await _universityFacultyService.Terminate(universityFaculty);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _universityFacultyService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll()
        {
            var result = await _universityFacultyService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _universityFacultyService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
