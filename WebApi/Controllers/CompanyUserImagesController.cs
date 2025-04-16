using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Memory;
using SixLabors.ImageSharp.Processing;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyUserImagesController : ControllerBase
    {
        ICompanyUserImageService _companyUserImageService;
        private readonly IWebHostEnvironment _environment;

        public CompanyUserImagesController(ICompanyUserImageService companyUserImageService, IWebHostEnvironment environment)
        {
            _companyUserImageService = companyUserImageService;
            _environment = environment;

        }

        [HttpPost("add")]
        public IActionResult Add(CompanyUserImage companyUserImage)
        {
            var result = _companyUserImageService.Add(companyUserImage);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CompanyUserImage companyUserImage)
        {
            var result = _companyUserImageService.Update(companyUserImage);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CompanyUserImage companyUserImage)
        {
            var result = _companyUserImageService.Delete(companyUserImage);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll(int userId)
        {
            var result = _companyUserImageService.GetAll(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int companyUserImageId)
        {
            var result = _companyUserImageService.GetById(companyUserImageId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getalldto")]
        public IActionResult GetAllDTO(int userId)
        {
            var result = _companyUserImageService.GetAllDTO(userId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


        [HttpPost("uploadimage")]
        public IActionResult UploadImage(IFormFile image, int userId)
        {
            if (image == null || image.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }
            if (userId <= 0)
            {
                return BadRequest("Invalid user ID.");
            }
            try
            {
                var uploadImageHandler = new WebAPI.PublicClasses.CreateFileNameHelper();

                string fullImageName = uploadImageHandler.CreateFileName(image);

                string uploadsFolder = _environment.WebRootPath + "\\uploads\\images\\" + userId + "\\";

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string fullImagePath = uploadsFolder + fullImageName;

                //save file
                using (var stream = new FileStream(fullImagePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                string uploadsThumbFolder = _environment.WebRootPath + "\\uploads\\images\\" + userId + "\\thumbs\\";

                if (!Directory.Exists(uploadsThumbFolder))
                {
                    Directory.CreateDirectory(uploadsThumbFolder);
                }

                string fullImageThumbPath = uploadsThumbFolder + fullImageName;

                //save thumb file
                using (var thumbImage = Image.Load(image.OpenReadStream()))
                {
                    string newSize = new WebAPI.PublicClasses.ResizeFileHelper().ImageResize(thumbImage, 600, 600);
                    string[] sizeArray = newSize.Split(',');

                    thumbImage.Mutate(x => x.Resize(Convert.ToInt32(sizeArray[0]), Convert.ToInt32(sizeArray[1])));

                    thumbImage.Save(fullImageThumbPath);
                }


                return Ok(new { type = "https://localhost:7088/" + "/uploads/images/" + userId + "/", name = fullImageName });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("deleteimage")]
        public IActionResult DeleteImage(CompanyUserImage companyUserImage)
        {
            string fullImagePath = _environment.WebRootPath + "\\uploads\\images\\" + companyUserImage.UserId + "\\" + companyUserImage.ImageName;

            if (System.IO.File.Exists(fullImagePath))
            {
                System.IO.File.Delete(fullImagePath);

            }

            string fullThumbImagePath = _environment.WebRootPath + "\\uploads\\images\\" + companyUserImage.UserId + "\\thumbs\\" + companyUserImage.ImageName;

            if (System.IO.File.Exists(fullThumbImagePath))
            {
                System.IO.File.Delete(fullThumbImagePath);

            }

            companyUserImage.ImagePath = "https://localhost:7088/" + "/uploads/images/common/";
            companyUserImage.ImageName = "noImage.jpg";

            var result = _companyUserImageService.Update(companyUserImage);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
