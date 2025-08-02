using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : ControllerBase
    {
        IOperationClaimService _operationClaimService;

        public OperationClaimsController(IOperationClaimService operationClaimService)
        {
            this._operationClaimService = operationClaimService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(OperationClaim operationClaim)
        {
            var result = await _operationClaimService.Add(operationClaim);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(OperationClaim operationClaim)
        {
            var result = await _operationClaimService.Update(operationClaim);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(OperationClaim operationClaim)
        {
            var result = await _operationClaimService.Delete(operationClaim);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(OperationClaim operationClaim)
        {
            var result = await _operationClaimService.Terminate(operationClaim);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _operationClaimService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll()
        {
            var result = await _operationClaimService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _operationClaimService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
