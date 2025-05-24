using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentDetailsController : ControllerBase
    {
        IDepartmentDetailService _departmentDetailService;

        public DepartmentDetailsController(IDepartmentDetailService departmentDetailService)
        {
            _departmentDetailService = departmentDetailService;
        }

        [HttpPost("add")]
        public IActionResult Add(DepartmentDetail departmentDetail)
        {
            var result = _departmentDetailService.Add(departmentDetail);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(DepartmentDetail departmentDetail)
        {
            var result = _departmentDetailService.Update(departmentDetail);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(DepartmentDetail departmentDetail)
        {
            var result = _departmentDetailService.Delete(departmentDetail);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _departmentDetailService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public IActionResult GetDeletedAll()
        {
            var result = _departmentDetailService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _departmentDetailService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getalldto")]
        public IActionResult GetAllDTO()
        {
            var result = _departmentDetailService.GetAllDTO();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedalldto")]
        public IActionResult GetDeletedAllDTO()
        {
            var result = _departmentDetailService.GetDeletedAllDTO();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
