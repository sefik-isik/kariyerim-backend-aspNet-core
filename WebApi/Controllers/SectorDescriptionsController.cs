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
        public IActionResult Add(SectorDescription sectorDescription)
        {
            var result = _sectorDescriptionService.Add(sectorDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(SectorDescription sectorDescription)
        {
            var result = _sectorDescriptionService.Update(sectorDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(SectorDescription sectorDescription)
        {
            var result = _sectorDescriptionService.Delete(sectorDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public IActionResult Terminate(SectorDescription sectorDescription)
        {
            var result = _sectorDescriptionService.Terminate(sectorDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _sectorDescriptionService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public IActionResult GetDeletedAll()
        {
            var result = _sectorDescriptionService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(string id)
        {
            var result = _sectorDescriptionService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getalldto")]
        public IActionResult GetAllDTO()
        {
            var result = _sectorDescriptionService.GetAllDTO();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedalldto")]
        public IActionResult GetDeletedAllDTO()
        {
            var result = _sectorDescriptionService.GetDeletedAllDTO();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getallsectoriddto")]
        public IActionResult GetAllBySectorIdDTO(string id)
        {
            var result = _sectorDescriptionService.GetAllBySectorIdDTO(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
