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
        public IActionResult Add(ModelMenu modelMenu)
        {
            var result = _modelMenuService.Add(modelMenu);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(ModelMenu modelMenu)
        {
            var result = _modelMenuService.Update(modelMenu);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(ModelMenu modelMenu)
        {
            var result = _modelMenuService.Delete(modelMenu);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _modelMenuService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int modelMenuId)
        {
            var result = _modelMenuService.GetById(modelMenuId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
