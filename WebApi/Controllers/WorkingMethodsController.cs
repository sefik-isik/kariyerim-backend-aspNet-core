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
        public async Task<ActionResult> Add(WorkingMethod workingMethod)
        {
            var result = await _workingMethodService.Add(workingMethod);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(WorkingMethod workingMethod)
        {
            var result = await _workingMethodService.Update(workingMethod);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(WorkingMethod workingMethod)
        {
            var result = await _workingMethodService.Delete(workingMethod);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(WorkingMethod workingMethod)
        {
            var result = await _workingMethodService.Terminate(workingMethod);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _workingMethodService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll()
        {
            var result = await _workingMethodService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _workingMethodService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
