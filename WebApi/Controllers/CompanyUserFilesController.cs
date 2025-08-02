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
        public async Task<ActionResult> Add(CompanyUserFile companyUserFile)
        {
            var result = await _companyUserFileService.Add(companyUserFile);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(CompanyUserFile companyUserFile)
        {
            var result = await _companyUserFileService.Update(companyUserFile);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(CompanyUserFile companyUserFile)
        {
            var result = await _companyUserFileService.Delete(companyUserFile);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(CompanyUserFile companyUserFile)
        {
            var result = await _companyUserFileService.Terminate(companyUserFile);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getall")]
        public async Task<ActionResult> GetAll(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserFileService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserFileService.GetDeletedAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getbyid")]
        public async Task<ActionResult> GetById(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserFileService.GetById(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getalldto")]
        public async Task<ActionResult> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserFileService.GetAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetDeletedAllDTO")]
        public async Task<ActionResult> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserFileService.GetDeletedAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


        [HttpPost("uploadfile")]
        public async Task<ActionResult> UploadFile(IFormFile file, string id)
        {
            var companyUser = await _companyUserService.GetById(id);

            string userId = companyUser.Data.UserId;

            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }
            if (userId == null)
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
        public async Task<ActionResult> DeleteFile(CompanyUserFile companyUserFile)
        {

            var companyUser = await _companyUserService.GetById(companyUserFile.CompanyUserId);

            string userId = companyUser.Data.UserId;

            string fullFilePath = _environment.WebRootPath + "\\uploads\\files\\" + userId + "\\" + companyUserFile.FileName;

            if (System.IO.File.Exists(fullFilePath))
            {
                System.IO.File.Delete(fullFilePath);

            }

            companyUserFile.FilePath = "noPath";
            companyUserFile.FileName = "noFile";

            var result = await _companyUserFileService.Update(companyUserFile);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
