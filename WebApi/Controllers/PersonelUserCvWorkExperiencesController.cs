using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelUserCvWorkExperiencesController : ControllerBase
    {
        IPersonelUserCvWorkExperienceService _personelUserCvWorkExperienceService;

        public PersonelUserCvWorkExperiencesController(IPersonelUserCvWorkExperienceService personelUserCvWorkExperienceService)
        {
            _personelUserCvWorkExperienceService = personelUserCvWorkExperienceService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(PersonelUserCvWorkExperience personelUserCvWorkExperience)
        {
            var result = await _personelUserCvWorkExperienceService.Add(personelUserCvWorkExperience);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(PersonelUserCvWorkExperience personelUserCvWorkExperience)
        {
            var result = await _personelUserCvWorkExperienceService.Update(personelUserCvWorkExperience);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(PersonelUserCvWorkExperience personelUserCvWorkExperience)
        {
            var result = await _personelUserCvWorkExperienceService.Delete(personelUserCvWorkExperience);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(PersonelUserCvWorkExperience personelUserCvWorkExperience)
        {
            var result = await _personelUserCvWorkExperienceService.Terminate(personelUserCvWorkExperience);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getall")]
        public async Task<ActionResult> GetAll(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUserCvWorkExperienceService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUserCvWorkExperienceService.GetDeletedAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getbyid")]
        public async Task<ActionResult> GetById(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUserCvWorkExperienceService.GetById(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getalldto")]
        public async Task<ActionResult> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUserCvWorkExperienceService.GetAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetDeletedAllDTO")]
        public async Task<ActionResult> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUserCvWorkExperienceService.GetDeletedAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
