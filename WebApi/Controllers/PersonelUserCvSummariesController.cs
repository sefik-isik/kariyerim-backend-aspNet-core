using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelUserCvSummariesController : ControllerBase
    {
        IPersonelUserCvSummaryService _personelUserCvSummaryService;

        public PersonelUserCvSummariesController(IPersonelUserCvSummaryService personelUserCvSummaryService)
        {
            _personelUserCvSummaryService = personelUserCvSummaryService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(PersonelUserCvSummary personelUserCvSummary)
        {
            var result = await _personelUserCvSummaryService.Add(personelUserCvSummary);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(PersonelUserCvSummary personelUserCvSummary)
        {
            var result = await _personelUserCvSummaryService.Update(personelUserCvSummary);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(PersonelUserCvSummary personelUserCvSummary)
        {
            var result = await _personelUserCvSummaryService.Delete(personelUserCvSummary);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(PersonelUserCvSummary personelUserCvSummary)
        {
            var result = await _personelUserCvSummaryService.Terminate(personelUserCvSummary);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getall")]
        public async Task<ActionResult> GetAll(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUserCvSummaryService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUserCvSummaryService.GetDeletedAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getbyid")]
        public async Task<ActionResult> GetById(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUserCvSummaryService.GetById(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getalldto")]
        public async Task<ActionResult> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUserCvSummaryService.GetAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetDeletedAllDTO")]
        public async Task<ActionResult> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _personelUserCvSummaryService.GetDeletedAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
