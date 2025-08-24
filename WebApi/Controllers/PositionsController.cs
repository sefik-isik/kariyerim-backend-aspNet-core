using Business.Abstract;
using Entities.Concrete;
using Entities.PageModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        IPositionService _positionService;

        public PositionsController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(Position position)
        {
            var result = await _positionService.Add(position);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(Position position)
        {
            var result = await _positionService.Update(position);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(Position position)
        {
            var result = await _positionService.Delete(position);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(Position position)
        {
            var result = await _positionService.Terminate(position);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _positionService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbypage")]
        public async Task<ActionResult> GetAllByPage(PositionPageModel positionPageModel)
       {
            var result = await _positionService.GetAllByPage(positionPageModel);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll()
        {
            var result = await _positionService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getbyid")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _positionService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
