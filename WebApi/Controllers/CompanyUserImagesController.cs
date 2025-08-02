using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyUserImagesController : ControllerBase
    {
        ICompanyUserImageService _companyUserImageService;
        private readonly IWebHostEnvironment _environment;
        ICompanyUserService _companyUserService;

        public CompanyUserImagesController(ICompanyUserImageService companyUserImageService, IWebHostEnvironment environment,ICompanyUserService companyUserService)
        {
            _companyUserImageService = companyUserImageService;
            _environment = environment;
            _companyUserService = companyUserService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(CompanyUserImage companyUserImage)
        {
            var result = await _companyUserImageService.Add(companyUserImage);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(CompanyUserImage companyUserImage)
        {
            var result = await _companyUserImageService.Update(companyUserImage);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(CompanyUserImage companyUserImage)
        {
            var result = await _companyUserImageService.Delete(companyUserImage);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(CompanyUserImage companyUserImage)
        {
            var result = await _companyUserImageService.Terminate(companyUserImage);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getall")]
        public async Task<ActionResult> GetAll(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserImageService.GetAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserImageService.GetDeletedAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getbyid")]
        public async Task<ActionResult> GetById(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserImageService.GetById(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getalldto")]
        public async Task<ActionResult> GetAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserImageService.GetAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPost("GetDeletedAllDTO")]
        public async Task<ActionResult> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserImageService.GetDeletedAllDTO(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("uploadimage")]
        public async Task<ActionResult> UploadImage(IFormFile image, string id)
        {
            var companyUser = await _companyUserService.GetById(id);

            string userId = companyUser.Data.UserId;

            if (image == null || image.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }
            if (userId == null)
            {
                return BadRequest("Invalid user ID.");
            }
            try
            {
                var uploadImageHandler = new WebAPI.PublicClasses.CreateImageNameHelper();

                string fullImageName = uploadImageHandler.CreateImageName(image);

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
        public async Task<ActionResult> DeleteImage(CompanyUserImage companyUserImage)
        {
            var result = await _companyUserImageService.DeleteImage(companyUserImage);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
