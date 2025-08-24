using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityDescriptionsController : ControllerBase
    {
        IUniversityDescriptionService _universityDescriptionService;

        public UniversityDescriptionsController(IUniversityDescriptionService universityDescriptionService)
        {
            _universityDescriptionService = universityDescriptionService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(UniversityDescription universityDescription)
        {
            var result = await _universityDescriptionService.Add(universityDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(UniversityDescription universityDescription)
        {
            var result = await _universityDescriptionService.Update(universityDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(UniversityDescription universityDescription)
        {
            var result = await _universityDescriptionService.Delete(universityDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(UniversityDescription universityDescription)
        {
            var result = await _universityDescriptionService.Terminate(universityDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _universityDescriptionService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll()
        {
            var result = await _universityDescriptionService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _universityDescriptionService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getalldto")]
        public async Task<ActionResult> GetAllDTO()
        {
            var result = await _universityDescriptionService.GetAllDTO();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedalldto")]
        public async Task<ActionResult> GetDeletedAllDTO()
        {
            var result = await _universityDescriptionService.GetDeletedAllDTO();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getallbyuniversityiddto")]
        public async Task<ActionResult> GetAllByUniversityIdDTO(string id)
        {
            var result = await _universityDescriptionService.GetAllByUniversityIdDTO(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
