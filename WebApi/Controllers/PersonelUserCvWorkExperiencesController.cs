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
        public IActionResult Add(PersonelUserCvWorkExperience personelUserCvWorkExperience)
        {
            var result = _personelUserCvWorkExperienceService.Add(personelUserCvWorkExperience);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(PersonelUserCvWorkExperience personelUserCvWorkExperience)
        {
            var result = _personelUserCvWorkExperienceService.Update(personelUserCvWorkExperience);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(PersonelUserCvWorkExperience personelUserCvWorkExperience)
        {
            var result = _personelUserCvWorkExperienceService.Delete(personelUserCvWorkExperience);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public IActionResult Terminate(PersonelUserCvWorkExperience personelUserCvWorkExperience)
        {
            var result = _personelUserCvWorkExperienceService.Terminate(personelUserCvWorkExperience);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getall")]
        public IActionResult GetAll(UserAdminDTO userAdminDTO)
        {
            var result = _personelUserCvWorkExperienceService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getdeletedall")]
        public IActionResult GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var result = _personelUserCvWorkExperienceService.GetDeletedAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getbyid")]
        public IActionResult GetById(UserAdminDTO userAdminDTO)
        {
            var result = _personelUserCvWorkExperienceService.GetById(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getalldto")]
        public IActionResult GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = _personelUserCvWorkExperienceService.GetAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetDeletedAllDTO")]
        public IActionResult GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = _personelUserCvWorkExperienceService.GetDeletedAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
