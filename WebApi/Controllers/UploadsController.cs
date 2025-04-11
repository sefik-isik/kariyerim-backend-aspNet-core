using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadsController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        private ICompanyUserFileService _companyUserFileService;

        public UploadsController(IWebHostEnvironment environment, ICompanyUserFileService companyUserFileService)
        {
            _environment = environment;
            _companyUserFileService = companyUserFileService;
        }

        [HttpPost("uploadfiles")]
        public IActionResult UploadFile(IFormFile file, int userId)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }
            if (userId <= 0)
            {
                return BadRequest("Invalid user ID.");
            }
            try
            {

                // Call the UploadHandler to handle the file upload
                var uploadFileHandler = new WebAPI.PublicClasses.UploadFileHandler();

                string fullFileName = uploadFileHandler.UploadFile(file);

                string uploadsFolder = _environment.WebRootPath + "\\uploads\\files\\" + userId + "\\";



                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string fullFilePath = uploadsFolder + fullFileName;

                //save file
                using (var stream = new FileStream(fullFilePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return Ok(new { type = "https://localhost:7088/" + "/uploads/files/" + userId + "/", name = fullFileName });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("deletefiles")]
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

        [HttpPost("uploadimages")]
        public IActionResult UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }
            try
            {
                // Call the UploadHandler to handle the file upload
                var uploadHandler = new WebAPI.PublicClasses.UploadImageHandler();
                string filePath = uploadHandler.UploadImage(file);

                return Ok(new { ImageName = filePath });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
