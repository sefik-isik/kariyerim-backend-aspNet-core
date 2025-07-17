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
        public IActionResult Add(PositionLevel positionLevel)
        {
            var result = _positionLevelService.Add(positionLevel);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(PositionLevel positionLevel)
        {
            var result = _positionLevelService.Update(positionLevel);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(PositionLevel positionLevel)
        {
            var result = _positionLevelService.Delete(positionLevel);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public IActionResult Terminate(PositionLevel positionLevel)
        {
            var result = _positionLevelService.Terminate(positionLevel);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _positionLevelService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getdeletedall")]
        public IActionResult GetDeletedAll()
        {
            var result = _positionLevelService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(string id)
        {
            var result = _positionLevelService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
