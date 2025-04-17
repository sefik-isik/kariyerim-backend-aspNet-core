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
        public IActionResult GetAll(int id)
        {
            var result = _personelUserFileService.GetAll(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _personelUserFileService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getalldto")]
        public IActionResult GetAllDTO(int id)
        {
            var result = _personelUserFileService.GetAllDTO(id);
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
