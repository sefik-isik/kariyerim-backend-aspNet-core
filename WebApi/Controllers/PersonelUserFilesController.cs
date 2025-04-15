using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelUserFilesController : ControllerBase
    {
        IPersonelUserFileService _personelUserFileService;
        private readonly IWebHostEnvironment _environment;

        public PersonelUserFilesController(IPersonelUserFileService personelUserFileService, IWebHostEnvironment environment)
        {
            _personelUserFileService = personelUserFileService;
            _environment = environment;

        }

        [HttpPost("add")]
        public IActionResult Add(PersonelUserFile personelUserFile)
        {
            var result = _personelUserFileService.Add(personelUserFile);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(PersonelUserFile personelUserFile)
        {
            var result = _personelUserFileService.Update(personelUserFile);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(PersonelUserFile personelUserFile)
        {
            var result = _personelUserFileService.Delete(personelUserFile);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll(int userId)
        {
            var result = _personelUserFileService.GetAll(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int personelUserFile)
        {
            var result = _personelUserFileService.GetById(personelUserFile);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdto")]
        public IActionResult GetPersonelUserFiletDTO(int userId)
        {
            var result = _personelUserFileService.GetPersonelUserFileDTO(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeleteddto")]
        public IActionResult GetPersonelUserFileDeletedDTO(int userId)
        {
            var result = _personelUserFileService.GetPersonelUserFileDeletedDTO(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("uploadfile")]
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
        public IActionResult DeleteFile(PersonelUserFile personelUserFile)
        {
            string fullFilePath = _environment.WebRootPath + "\\uploads\\files\\" + personelUserFile.UserId + "\\" + personelUserFile.FileName;

            if (System.IO.File.Exists(fullFilePath))
            {
                System.IO.File.Delete(fullFilePath);

            }

            personelUserFile.FilePath = "noPath";
            personelUserFile.FileName = "noFile";

            var result = _personelUserFileService.Update(personelUserFile);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
