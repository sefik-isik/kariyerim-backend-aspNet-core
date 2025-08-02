using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        IRegionService _regionService;

        public RegionsController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(Region region)
        {
            var result = await _regionService.Add(region);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(Region region)
        {
            var result = await _regionService.Update(region);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(Region region)
        {
            var result = await _regionService.Delete(region);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(Region region)
        {
            var result = await _regionService.Terminate(region);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _regionService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll()
        {
            var result = await _regionService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _regionService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getalldto")]
        public async Task<ActionResult> GetAllDTO()
        {
            var result = await _regionService.GetAllDTO();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedalldto")]
        public async Task<ActionResult> GetDeletedAllDTO()
        {
            var result = await _regionService.GetDeletedAllDTO();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

    }
}
