using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entities.PageModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyUserAdvertsController : ControllerBase
    {
        ICompanyUserAdvertService _companyUserAdvertService;
        ICompanyUserService _companyUserService;
        private readonly IWebHostEnvironment _environment;
        public CompanyUserAdvertsController(ICompanyUserAdvertService companyUserAdvertService, IWebHostEnvironment environment, ICompanyUserService companyUserService)
        {
            _companyUserAdvertService = companyUserAdvertService;
            _environment = environment;
            _companyUserService = companyUserService;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(CompanyUserAdvert companyUserAdvert)
        {
            var result = await _companyUserAdvertService.Add(companyUserAdvert);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(CompanyUserAdvert companyUserAdvert)
        {
            var result = await _companyUserAdvertService.Update(companyUserAdvert);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(CompanyUserAdvert companyUserAdvert)
        {
            var result = await _companyUserAdvertService.Delete(companyUserAdvert);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("terminate")]
        public async Task<ActionResult> Terminate(CompanyUserAdvert companyUserAdvert)
        {
            var result = await _companyUserAdvertService.Terminate(companyUserAdvert);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _companyUserAdvertService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getdeletedall")]
        public async Task<ActionResult> GetDeletedAll(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserAdvertService.GetDeletedAll(userAdminDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("getallbypage")]
        public async Task<ActionResult> GetAllByPage(CompanyUserAdvertPageModel companyUserAdvertPageModel)
        {
            var result = await _companyUserAdvertService.GetAllByPage(companyUserAdvertPageModel);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _companyUserAdvertService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getalldto")]
        public async Task<ActionResult> GetAllDTO()
        {
            var result = await _companyUserAdvertService.GetAllDTO();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetDeletedAllDTO")]
        public async Task<ActionResult> GetDeletedAllDTO(UserAdminDTO userAdminDTO)
        {
            var result = await _companyUserAdvertService.GetDeletedAllDTO(userAdminDTO);
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
        public async Task<ActionResult> DeleteImage(CompanyUserAdvert companyUserAdvert)
        {
            var result = await _companyUserAdvertService.DeleteImage(companyUserAdvert);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
