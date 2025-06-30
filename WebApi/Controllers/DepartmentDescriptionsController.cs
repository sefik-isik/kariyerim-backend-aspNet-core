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
    public class DepartmentDescriptionsController : ControllerBase
    {
        IDepartmentDescriptionService _departmentDescriptionService;

        public DepartmentDescriptionsController(IDepartmentDescriptionService departmentDescriptionService)
        {
            _departmentDescriptionService = departmentDescriptionService;
        }

        [HttpPost("add")]
        public IActionResult Add(DepartmentDescription departmentDescription)
        {
            var result = _departmentDescriptionService.Add(departmentDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(DepartmentDescription departmentDescription)
        {
            var result = _departmentDescriptionService.Update(departmentDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(DepartmentDescription departmentDescription)
        {
            var result = _departmentDescriptionService.Delete(departmentDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public IActionResult Terminate(DepartmentDescription departmentDescription)
        {
            var result = _departmentDescriptionService.Terminate(departmentDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _departmentDescriptionService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public IActionResult GetDeletedAll()
        {
            var result = _departmentDescriptionService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(string id)
        {
            var result = _departmentDescriptionService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getalldto")]
        public IActionResult GetAllDTO()
        {
            var result = _departmentDescriptionService.GetAllDTO();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedalldto")]
        public IActionResult GetDeletedAllDTO()
        {
            var result = _departmentDescriptionService.GetDeletedAllDTO();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
