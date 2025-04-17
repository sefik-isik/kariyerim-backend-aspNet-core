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
    public class PersonelUserImagesController : ControllerBase
    {
        IPersonelUserImageService _personelUserImageService;
        private readonly IWebHostEnvironment _environment;

        public PersonelUserImagesController(IPersonelUserImageService personelUserImageService, IWebHostEnvironment webHostEnvironment)
        {
            _personelUserImageService = personelUserImageService;
            _environment = webHostEnvironment;
        }

        [HttpPost("add")]
        public IActionResult Add(PersonelUserImage personelUserImage)
        {
            var result = _personelUserImageService.Add(personelUserImage);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(PersonelUserImage personelUserImage)
        {
            var result = _personelUserImageService.Update(personelUserImage);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(PersonelUserImage personelUserImage)
        {
            var result = _personelUserImageService.Delete(personelUserImage);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll(int id)
        {
            var result = _personelUserImageService.GetAll(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _personelUserImageService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("uploadimage")]
        public IActionResult UploadImage(IFormFile image, int id)
        {
            if (image == null || image.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }
            if (id <= 0)
            {
                return BadRequest("Invalid user ID.");
            }
            try
            {
                var uploadImageHandler = new WebAPI.PublicClasses.CreateFileNameHelper();

                string fullImageName = uploadImageHandler.CreateFileName(image);

                string uploadsFolder = _environment.WebRootPath + "\\uploads\\images\\" + id + "\\";

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

                string uploadsThumbFolder = _environment.WebRootPath + "\\uploads\\images\\" + id + "\\thumbs\\";

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


                return Ok(new { type = "https://localhost:7088/" + "/uploads/images/" + id + "/", name = fullImageName });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("deleteimage")]
        public IActionResult DeleteImage(PersonelUserImage personelUserImage)
        {
            string fullImagePath = _environment.WebRootPath + "\\uploads\\images\\" + personelUserImage.UserId + "\\" + personelUserImage.ImageName;

            if (System.IO.File.Exists(fullImagePath))
            {
                System.IO.File.Delete(fullImagePath);

            }

            string fullThumbImagePath = _environment.WebRootPath + "\\uploads\\images\\" + personelUserImage.UserId + "\\thumbs\\" + personelUserImage.ImageName;

            if (System.IO.File.Exists(fullThumbImagePath))
            {
                System.IO.File.Delete(fullThumbImagePath);

            }

            personelUserImage.ImagePath = "https://localhost:7088/" + "/uploads/images/common/";
            personelUserImage.ImageName = "noImage.jpg";

            var result = _personelUserImageService.Update(personelUserImage);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

    }
}
