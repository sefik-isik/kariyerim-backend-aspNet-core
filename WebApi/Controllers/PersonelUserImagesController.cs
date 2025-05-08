using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        private IPersonelUserService _personelUserService;

        public PersonelUserImagesController(IPersonelUserImageService personelUserImageService, IWebHostEnvironment webHostEnvironment, IPersonelUserService personelUserService)
        {
            _personelUserImageService = personelUserImageService;
            _environment = webHostEnvironment;
            _personelUserService = personelUserService;

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

        [HttpPost("getall")]
        public IActionResult GetAll(UserAdminDTO userAdminDTO)
        {
            var result = _personelUserImageService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getdeletedall")]
        public IActionResult GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var result = _personelUserImageService.GetDeletedAll(userAdminDTO);
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
            PersonelUser personelUser = _personelUserService.GetByUserId(id);

            int userId = personelUser.UserId;

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
        public IActionResult DeleteImage(PersonelUserImage personelUserImage)
        {
            PersonelUser personelUser = _personelUserService.GetByUserId(personelUserImage.PersonelUserId);

            int userId = personelUser.UserId;

            string fullImagePath = _environment.WebRootPath + "\\uploads\\images\\" + userId + "\\" + personelUserImage.ImageName;

            if (System.IO.File.Exists(fullImagePath))
            {
                System.IO.File.Delete(fullImagePath);

            }

            string fullThumbImagePath = _environment.WebRootPath + "\\uploads\\images\\" + userId + "\\thumbs\\" + personelUserImage.ImageName;

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
