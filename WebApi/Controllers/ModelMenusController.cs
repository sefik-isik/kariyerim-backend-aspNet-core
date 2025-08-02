using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelMenusController : ControllerBase
    {
        IModelMenuService _modelMenuService;

        public ModelMenusController(IModelMenuService modelMenuService)
        {
            _modelMenuService = modelMenuService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(ModelMenu modelMenu)
        {
            var result = await _modelMenuService.Add(modelMenu);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(ModelMenu modelMenu)
        {
            var result = await _modelMenuService.Update(modelMenu);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(ModelMenu modelMenu)
        {
            var result = await _modelMenuService.Delete(modelMenu);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(ModelMenu modelMenu)
        {
            var result = await _modelMenuService.Terminate(modelMenu);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _modelMenuService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll()
        {
            var result = await _modelMenuService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _modelMenuService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
