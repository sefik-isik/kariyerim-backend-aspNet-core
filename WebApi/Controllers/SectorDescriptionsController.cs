using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorDescriptionsController : ControllerBase
    {
        ISectorDescriptionService _sectorDescriptionService;

        public SectorDescriptionsController(ISectorDescriptionService sectorDescriptionService)
        {
            _sectorDescriptionService = sectorDescriptionService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(SectorDescription sectorDescription)
        {
            var result = await _sectorDescriptionService.Add(sectorDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(SectorDescription sectorDescription)
        {
            var result = await _sectorDescriptionService.Update(sectorDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(SectorDescription sectorDescription)
        {
            var result = await _sectorDescriptionService.Delete(sectorDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(SectorDescription sectorDescription)
        {
            var result = await _sectorDescriptionService.Terminate(sectorDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _sectorDescriptionService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll()
        {
            var result = await _sectorDescriptionService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _sectorDescriptionService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getalldto")]
        public async Task<ActionResult> GetAllDTO()
        {
            var result = await _sectorDescriptionService.GetAllDTO();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedalldto")]
        public async Task<ActionResult> GetDeletedAllDTO()
        {
            var result = await _sectorDescriptionService.GetDeletedAllDTO();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getallsectoriddto")]
        public async Task<ActionResult> GetAllBySectorIdDTO(string id)
        {
            var result = await _sectorDescriptionService.GetAllBySectorIdDTO(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
