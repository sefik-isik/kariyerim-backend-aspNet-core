using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitiesController : ControllerBase
    {
        IUniversityService universityService;

        public UniversitiesController(IUniversityService universityService)
        {
            this.universityService = universityService;
        }

        [HttpPost("add")]
        public IActionResult Add(University university)
        {
            var result = universityService.Add(university);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(University university)
        {
            var result = universityService.Update(university);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(University university)
        {
            var result = universityService.Delete(university);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = universityService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int universityId)
        {
            var result = universityService.GetById(universityId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
