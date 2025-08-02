using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageLevelsController : ControllerBase
    {
        ILanguageLevelService _languageLevelService;

        public LanguageLevelsController(ILanguageLevelService languageLevelService)
        {
            _languageLevelService = languageLevelService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(LanguageLevel languageLevel)
        {
            var result = await _languageLevelService.Add(languageLevel);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(LanguageLevel languageLevel)
        {
            var result = await _languageLevelService.Update(languageLevel);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(LanguageLevel languageLevel)
        {
            var result = await _languageLevelService.Delete(languageLevel);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(LanguageLevel languageLevel)
        {
            var result = await _languageLevelService.Terminate(languageLevel);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _languageLevelService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll()
        {
            var result = await _languageLevelService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _languageLevelService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
