using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorsController : ControllerBase
    {
        ISectorService _SectorService;

        public SectorsController(ISectorService companyUserSectorService)
        {
            _SectorService = companyUserSectorService;
        }

        [HttpPost("add")]
        public IActionResult Add(Sector companyUserSector)
        {
            var result = _SectorService.Add(companyUserSector);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Sector companyUserSector)
        {
            var result = _SectorService.Update(companyUserSector);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Sector companyUserSector)
        {
            var result = _SectorService.Delete(companyUserSector);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _SectorService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _SectorService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
