using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        ICompanyUserService _companyUserService;


        public CompanyUserFilesController(ICompanyUserFileService companyUserFileService, IWebHostEnvironment environment, ICompanyUserService companyUserService)
        {
            _companyUserFileService = companyUserFileService;
            _environment = environment;
            _companyUserService = companyUserService;

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

        [HttpPost("getall")]
        public IActionResult GetAll(UserAdminDTO userAdminDTO)
        {
            var result = _companyUserFileService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getdeletedall")]
        public IActionResult GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var result = _companyUserFileService.GetDeletedAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getbyid")]
        public IActionResult GetById(UserAdminDTO userAdminDTO)
        {
            var result = _companyUserFileService.GetById(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getalldto")]
        public IActionResult GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = _companyUserFileService.GetAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getalldeleteddto")]
        public IActionResult GetAllDeletedDTO(UserAdminDTO userAdminDTO)
        {
            var result = _companyUserFileService.GetAllDeletedDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


        [HttpPost("uploadfile")]
        public IActionResult UploadFile(IFormFile file, int id)
        {
            var companyUser = _companyUserService.GetById(id);

            int userId = companyUser.Data.UserId;

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
                var uploadFileHandler = new WebAPI.PublicClasses.CreateFileNameHelper();

                string fullFileName = uploadFileHandler.CreateFileName(file);

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

        [HttpPost("deletefile")]
        public IActionResult DeleteFile(CompanyUserFile companyUserFile)
        {

            var companyUser = _companyUserService.GetById(companyUserFile.CompanyUserId);

            int userId = companyUser.Data.UserId;

            string fullFilePath = _environment.WebRootPath + "\\uploads\\files\\" + userId + "\\" + companyUserFile.FileName;

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
