using Business.Abstract;
using Entities.Concrete;
using Entities.PageModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxOfficesController : ControllerBase
    {
        ITaxOfficeService _taxOfficeService;

        public TaxOfficesController(ITaxOfficeService officeService)
        {
            _taxOfficeService = officeService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(TaxOffice taxOffice)
        {
            var result = await _taxOfficeService.Add(taxOffice);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(TaxOffice taxOffice)
        {
            var result = await _taxOfficeService.Update(taxOffice);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(TaxOffice taxOffice)
        {
            var result = await _taxOfficeService.Delete(taxOffice);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(TaxOffice taxOffice)
        {
            var result = await _taxOfficeService.Terminate(taxOffice);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _taxOfficeService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getallbypage")]
        public async Task<ActionResult> GetAllByPage(string? sortColumn, string? sortOrder, int pageIndex = 0, int pageSize = 100)
        {
            TaxOfficePageModel positionPageModel = new TaxOfficePageModel
            {
                SortColumn = sortColumn,
                SortOrder = sortOrder,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            var result = await _taxOfficeService.GetAllByPage(positionPageModel);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll()
        {
            var result = await _taxOfficeService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _taxOfficeService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getalldto")]
        public async Task<ActionResult> GetAllDTO()
        {
            var result = await _taxOfficeService.GetAllDTO();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedalldto")]
        public async Task<ActionResult> GetDeletedAllDTO()
        {
            var result = await _taxOfficeService.GetDeletedAllDTO();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
