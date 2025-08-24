using Business.Abstract;
using Entities.Concrete;
using Entities.PageModel;
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
        public async Task<ActionResult> Add(UniversityDepartment universityDepartment)
        {
            var result = await _universityDepartmentService.Add(universityDepartment);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(UniversityDepartment universityDepartment)
        {
            var result = await _universityDepartmentService.Update(universityDepartment);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(UniversityDepartment universityDepartment)
        {
            var result = await _universityDepartmentService.Delete(universityDepartment);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(UniversityDepartment universityDepartment)
        {
            var result = await _universityDepartmentService.Terminate(universityDepartment);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _universityDepartmentService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbypage")]
        public async Task<ActionResult> GetAllByPage(UniversityDepartmentPageModel universityDepartmentPageModel)
        {
            var result = await _universityDepartmentService.GetAllByPage(universityDepartmentPageModel);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll()
        {
            var result = await _universityDepartmentService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _universityDepartmentService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
