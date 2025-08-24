using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityDepartmentDescriptionsController : ControllerBase
    {
        IUniversityDepartmentDescriptionService _universityDepartmentDescriptionService;

        public UniversityDepartmentDescriptionsController(IUniversityDepartmentDescriptionService universityDepartmentDescriptionService)
        {
            _universityDepartmentDescriptionService = universityDepartmentDescriptionService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(UniversityDepartmentDescription universitydepartmentDescription)
        {
            var result = await _universityDepartmentDescriptionService.Add(universitydepartmentDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(UniversityDepartmentDescription universitydepartmentDescription)
        {
            var result = await _universityDepartmentDescriptionService.Update(universitydepartmentDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(UniversityDepartmentDescription universitydepartmentDescription)
        {
            var result = await _universityDepartmentDescriptionService.Delete(universitydepartmentDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(UniversityDepartmentDescription universitydepartmentDescription)
        {
            var result = await _universityDepartmentDescriptionService.Terminate(universitydepartmentDescription);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _universityDepartmentDescriptionService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll()
        {
            var result = await _universityDepartmentDescriptionService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _universityDepartmentDescriptionService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getalldto")]
        public async Task<ActionResult> GetAllDTO()
        {
            var result = await _universityDepartmentDescriptionService.GetAllDTO();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedalldto")]
        public async Task<ActionResult> GetDeletedAllDTO()
        {
            var result = await _universityDepartmentDescriptionService.GetDeletedAllDTO();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getallbyuniversitydeparttmetIddto")]
        public async Task<ActionResult> GetAllByUniversityDeparttmetIdDTO(string id)
        {
            var result = await _universityDepartmentDescriptionService.GetAllByUniversityDeparttmetIdDTO(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
