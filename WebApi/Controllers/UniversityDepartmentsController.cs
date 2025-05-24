using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityDepartmentsController : ControllerBase
    {
        IUniversityDepartmentService _universityDepartmentService;

        public UniversityDepartmentsController(IUniversityDepartmentService universityDepartmentService)
        {
            _universityDepartmentService = universityDepartmentService;
        }

        [HttpPost("add")]
        public IActionResult Add(UniversityDepartment universityDepartment)
        {
            var result = _universityDepartmentService.Add(universityDepartment);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UniversityDepartment universityDepartment)
        {
            var result = _universityDepartmentService.Update(universityDepartment);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(UniversityDepartment universityDepartment)
        {
            var result = _universityDepartmentService.Delete(universityDepartment);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _universityDepartmentService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public IActionResult GetDeletedAll()
        {
            var result = _universityDepartmentService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _universityDepartmentService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getalldto")]
        public IActionResult GetAllDTO()
        {
            var result = _universityDepartmentService.GetAllDTO();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedalldto")]
        public IActionResult GetDeletedAllDTO()
        {
            var result = _universityDepartmentService.GetDeletedAllDTO();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
