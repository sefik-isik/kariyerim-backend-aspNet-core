using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingMethodsController : ControllerBase
    {
        IWorkingMethodService _workingMethodService;

        public WorkingMethodsController(IWorkingMethodService workingMethodService)
        {
            _workingMethodService = workingMethodService;
        }

        [HttpPost("add")]
        public IActionResult Add(WorkingMethod workingMethod)
        {
            var result = _workingMethodService.Add(workingMethod);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(WorkingMethod workingMethod)
        {
            var result = _workingMethodService.Update(workingMethod);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(WorkingMethod workingMethod)
        {
            var result = _workingMethodService.Delete(workingMethod);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _workingMethodService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public IActionResult GetDeletedAll()
        {
            var result = _workingMethodService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _workingMethodService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
