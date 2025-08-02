using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionLevelsController : ControllerBase
    {
        IPositionLevelService _positionLevelService;

        public PositionLevelsController(IPositionLevelService positionLevelService)
        {
            _positionLevelService = positionLevelService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(PositionLevel positionLevel)
        {
            var result = await _positionLevelService.Add(positionLevel);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(PositionLevel positionLevel)
        {
            var result = await _positionLevelService.Update(positionLevel);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(PositionLevel positionLevel)
        {
            var result = await _positionLevelService.Delete(positionLevel);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(PositionLevel positionLevel)
        {
            var result = await _positionLevelService.Terminate(positionLevel);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _positionLevelService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll()
        {
            var result = await _positionLevelService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getbyid")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _positionLevelService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
