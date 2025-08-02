using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelUserCoverLettersController : ControllerBase
    {
        IPersonelUserCoverLetterService _personelUserCoverLetterService;

        public PersonelUserCoverLettersController(IPersonelUserCoverLetterService personelUserCoverLetter)
        {
            _personelUserCoverLetterService = personelUserCoverLetter;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(PersonelUserCoverLetter personelUserCoverLetter)
        {
            var result = await _personelUserCoverLetterService.Add(personelUserCoverLetter);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(PersonelUserCoverLetter personelUserCoverLetter)
        {
            var result = await _personelUserCoverLetterService.Update(personelUserCoverLetter);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(PersonelUserCoverLetter personelUserCoverLetter)
        {
            var result = await _personelUserCoverLetterService.Delete(personelUserCoverLetter);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(PersonelUserCoverLetter personelUserCoverLetter)
        {
            var result = await _personelUserCoverLetterService.Terminate(personelUserCoverLetter);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getall")]
        public async Task<ActionResult> GetAll(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUserCoverLetterService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUserCoverLetterService.GetDeletedAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getbyid")]
        public async Task<ActionResult> GetById(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUserCoverLetterService.GetById(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getalldto")]
        public async Task<ActionResult> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUserCoverLetterService.GetAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetDeletedAllDTO")]
        public async Task<ActionResult> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUserCoverLetterService.GetDeletedAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
