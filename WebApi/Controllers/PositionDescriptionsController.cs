using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionDescriptionsController : ControllerBase
    {
        IPositionDescriptionService _positionDescriptionService;

        public PositionDescriptionsController(IPositionDescriptionService positionDescriptionService)
        {
            _positionDescriptionService = positionDescriptionService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(PositionDescription positionDescription)
        {
            var result = await _positionDescriptionService.Add(positionDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(PositionDescription positionDescription)
        {
            var result = await _positionDescriptionService.Update(positionDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(PositionDescription positionDescription)
        {
            var result = await _positionDescriptionService.Delete(positionDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(PositionDescription positionDescription)
        {
            var result = await _positionDescriptionService.Terminate(positionDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _positionDescriptionService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll()
        {
            var result = await _positionDescriptionService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _positionDescriptionService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getalldto")]
        public async Task<ActionResult> GetAllDTO()
        {
            var result = await _positionDescriptionService.GetAllDTO();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedalldto")]
        public async Task<ActionResult> GetDeletedAllDTO()
        {
            var result = await _positionDescriptionService.GetDeletedAllDTO();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getallpositioniddto")]
        public async Task<ActionResult> GetAllByDeparttmetIdDTO(string id)
        {
            var result = await _positionDescriptionService.GetAllByPositionIdDTO(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
