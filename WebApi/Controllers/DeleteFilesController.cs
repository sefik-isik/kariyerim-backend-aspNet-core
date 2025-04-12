using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteFilesController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        private ICompanyUserFileService _companyUserFileService;

        public DeleteFilesController(ICompanyUserFileService companyUserFileService, IWebHostEnvironment environment)
        {
            _companyUserFileService = companyUserFileService;
            _environment = environment;
        }

        [HttpPost("deletefile")]
        public IActionResult DeleteFile(CompanyUserFile companyUserFile)
        {
            string fullFilePath = _environment.WebRootPath + "\\uploads\\files\\" + companyUserFile.UserId + "\\" + companyUserFile.FileName;

            if (System.IO.File.Exists(fullFilePath))
            {
                System.IO.File.Delete(fullFilePath);

            }

            companyUserFile.FilePath = "noPath";
            companyUserFile.FileName = "noFile";

            var result = _companyUserFileService.Update(companyUserFile);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
