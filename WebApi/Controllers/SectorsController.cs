using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorsController : ControllerBase
    {
        ISectorService _sectorService;

        public SectorsController(ISectorService sectorService)
        {
            _sectorService = sectorService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(Sector sector)
        {
            var result = await _sectorService.Add(sector);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(Sector sector)
        {
            var result = await _sectorService.Update(sector);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(Sector sector)
        {
            var result = await _sectorService.Delete(sector);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(Sector sector)
        {
            var result = await _sectorService.Terminate(sector);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _sectorService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll()
        {
            var result = await _sectorService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _sectorService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
