using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityImagesController : ControllerBase
    {
        IUniversityImageService _universityImageService;
        IUniversityService _universityService;
        private readonly IWebHostEnvironment _environment;

        public UniversityImagesController(IUniversityImageService universityImageService, IUniversityService universityService, IWebHostEnvironment environment)
        {
            _universityImageService = universityImageService;
            _universityService = universityService;
            _environment = environment;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(UniversityImage universityImage)
        {
            var result = await _universityImageService.Add(universityImage);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(UniversityImage universityImage)
        {
            var result = await _universityImageService.Update(universityImage);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(UniversityImage universityImage)
        {
            var result = await _universityImageService.Delete(universityImage);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(UniversityImage universityImage)
        {
            var result = await _universityImageService.Terminate(universityImage);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _universityImageService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll()
        {
            var result = await _universityImageService.GetDeletedAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getallbyid")]
        public async Task<ActionResult> GetAllById(string id)
        {
            var result = await _universityImageService.GetAllById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getuniversitymainimage")]
        public async Task<ActionResult> GetUniversityMainImage(string id)
        {
            var result = await _universityImageService.GetUniversityMainImage(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getuniversitylogoimage")]
        public async Task<ActionResult> GetUniversityLogoImage(string id)
        {
            var result = await _universityImageService.GetUniversityLogoImage(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _universityImageService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("uploadimage")]
        public async Task<ActionResult> UploadImage(IFormFile image, string id)
        {
            var university = await _universityService.GetById(id);
            string universityId = university.Data.Id;

            if (image == null || image.Length == 0)
            {
                return BadRequest("No image uploaded.");
            }
            if (universityId == null)
            {
                return BadRequest("Invalid university ID.");
            }
            try
            {
                var uploadImageHandler = new WebAPI.PublicClasses.CreateImageNameHelper();

                string fullImageName = uploadImageHandler.CreateImageName(image);

                string uploadsFolder = _environment.WebRootPath + "\\uploads\\images\\" + universityId + "\\";

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

                string uploadsThumbFolder = _environment.WebRootPath + "\\uploads\\images\\" + universityId + "\\thumbs\\";

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


                return Ok(new { type = "https://localhost:7088/" + "/uploads/images/" + universityId + "/", name = fullImageName });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("deleteimage")]
        public async Task<ActionResult> DeleteImage(UniversityImage universityImage)
        {
            var result = await _universityImageService.DeleteImage(universityImage);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
