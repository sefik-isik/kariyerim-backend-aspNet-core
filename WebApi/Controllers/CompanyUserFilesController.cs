using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyUserFilesController : ControllerBase
    {
        ICompanyUserFileService _companyUserFileService;
        private readonly IWebHostEnvironment _environment;


        public CompanyUserFilesController(ICompanyUserFileService companyUserFileService, IWebHostEnvironment environment)
        {
            _companyUserFileService = companyUserFileService;
            _environment = environment;

        }

        [HttpPost("add")]
        public IActionResult Add(CompanyUserFile companyUserFile)
        {
            var result = _companyUserFileService.Add(companyUserFile);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CompanyUserFile companyUserFile)
        {
            var result = _companyUserFileService.Update(companyUserFile);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CompanyUserFile companyUserFile)
        {
            var result = _companyUserFileService.Delete(companyUserFile);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll(int userId)
        {
            var result = _companyUserFileService.GetAll(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public IActionResult GetDeletedAll(int userId)
        {
            var result = _companyUserFileService.GetDeletedAll(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _companyUserFileService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getalldto")]
        public IActionResult GetAllDTO(int id)
        {
            var result = _companyUserFileService.GetAllDTO(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getalldeleteddto")]
        public IActionResult GetAllDeletedDTO(int id)
        {
            var result = _companyUserFileService.GetAllDeletedDTO(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


        [HttpPost("uploadfile")]
        public IActionResult UploadFile(IFormFile file, int id)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }
            if (id <= 0)
            {
                return BadRequest("Invalid user ID.");
            }
            try
            {
                var uploadFileHandler = new WebAPI.PublicClasses.CreateFileNameHelper();

                string fullFileName = uploadFileHandler.CreateFileName(file);

                string uploadsFolder = _environment.WebRootPath + "\\uploads\\files\\" + id + "\\";

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

                return Ok(new { type = "https://localhost:7088/" + "/uploads/files/" + id + "/", name = fullFileName });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
