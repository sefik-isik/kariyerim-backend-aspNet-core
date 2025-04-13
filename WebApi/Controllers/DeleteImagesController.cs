using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteImagesController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ICompanyUserImageService _companyUserImageService;

        public DeleteImagesController(IWebHostEnvironment environment, ICompanyUserImageService companyUserImageService)
        {
            _environment = environment;
            _companyUserImageService = companyUserImageService;
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
