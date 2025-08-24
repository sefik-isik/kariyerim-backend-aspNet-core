using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertFiltersController : ControllerBase
    {
        IAdvertFilterService _advertFilterService;

        public AdvertFiltersController(IAdvertFilterService advertFilterService)
        {
            _advertFilterService = advertFilterService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(AdvertFilter advertFilter)
        {
            var result = await _advertFilterService.Add(advertFilter);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(AdvertFilter advertFilter)
        {
            var result = await _advertFilterService.Terminate(advertFilter);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getfiltersbysearchid")]
        public async Task<ActionResult> GetFiltersBySearchId(string filterid)
        {
            var result = await _advertFilterService.GetFiltersBySearchId(filterid);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
