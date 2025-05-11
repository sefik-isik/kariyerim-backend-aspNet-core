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
        IPersonelUserCvWorkExperienceService _cvWorkExperienceService;

        public PersonelUserCvWorkExperiencesController(IPersonelUserCvWorkExperienceService cvWorkExperienceService)
        {
            _cvWorkExperienceService = cvWorkExperienceService;
        }

        [HttpPost("add")]
        public IActionResult Add(PersonelUserCvWorkExperience cvWorkExperience)
        {
            var result = _cvWorkExperienceService.Add(cvWorkExperience);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(PersonelUserCvWorkExperience cvWorkExperience)
        {
            var result = _cvWorkExperienceService.Update(cvWorkExperience);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(PersonelUserCvWorkExperience cvWorkExperience)
        {
            var result = _cvWorkExperienceService.Delete(cvWorkExperience);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getall")]
        public IActionResult GetAll(UserAdminDTO userAdminDTO)
        {
            var result = _cvWorkExperienceService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getdeletedall")]
        public IActionResult GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var result = _cvWorkExperienceService.GetDeletedAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getbyid")]
        public IActionResult GetById(UserAdminDTO userAdminDTO)
        {
            var result = _cvWorkExperienceService.GetById(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
