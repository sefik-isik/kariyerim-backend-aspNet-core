using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountsController : ControllerBase
    {
        ICountService _countService;

        public CountsController(ICountService countService)
        {
            _countService = countService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(Count count)
        {
            var result = await _countService.Add(count);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(Count count)
        {
            var result = await _countService.Update(count);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(Count count)
        {
            var result = await _countService.Delete(count);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(Count count)
        {
            var result = await _countService.Terminate(count);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _countService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll()
        {
            var result = await _countService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getbyid")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _countService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
