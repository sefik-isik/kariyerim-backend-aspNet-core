using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        private IPersonelUserService _personelUserService;

        public PersonelUserFilesController(IPersonelUserFileService personelUserFileService, IWebHostEnvironment environment, IPersonelUserService personelUserService)
        {
            _personelUserFileService = personelUserFileService;
            _environment = environment;
            _personelUserService = personelUserService;

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

        [HttpPost("terminate")]
        public IActionResult Terminate(PersonelUserFile personelUserFile)
        {
            var result = _personelUserFileService.Terminate(personelUserFile);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getall")]
        public IActionResult GetAll(UserAdminDTO userAdminDTO)
        {
            var result = _personelUserFileService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getdeletedall")]
        public IActionResult GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var result = _personelUserFileService.GetDeletedAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getbyid")]
        public IActionResult GetById(UserAdminDTO userAdminDTO)
        {
            var result = _personelUserFileService.GetById(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getalldto")]
        public IActionResult GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = _personelUserFileService.GetAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetDeletedAllDTO")]
        public IActionResult GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = _personelUserFileService.GetDeletedAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("uploadfile")]
        public IActionResult UploadFile(IFormFile file, string id)
        {
            var personelUser = _personelUserService.GetById(id);

            string userId = personelUser.Data.UserId;

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
        public IActionResult DeleteFile(PersonelUserFile personelUserFile)
        {

            var personelUser = _personelUserService.GetById(personelUserFile.PersonelUserId);

            string userId = personelUser.Data.UserId;

            string fullFilePath = _environment.WebRootPath + "\\uploads\\files\\" + userId + "\\" + personelUserFile.FileName;

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
