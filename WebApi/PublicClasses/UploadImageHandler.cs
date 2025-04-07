using DataAccess.Abstract;
using Entities.Concrete;

namespace WebAPI.PublicClasses
{
    public class UploadImageHandler
    {
        public string UploadImage(IFormFile file)
        {

            //extention
            List<string> allowedExtensions = new List<string> { ".jpg", ".jpeg", ".png", ".gif" };
            string fileExtension = Path.GetExtension(file.FileName).ToLower();
            if (!allowedExtensions.Contains(fileExtension))
            {
                throw new Exception("Invalid file type. Only .jpg, .jpeg, .png, and .gif are allowed.");
            }
            //size
            if (file.Length > 5 * 1024 * 1024) // 5 MB
            {
                throw new Exception("File size exceeds the limit of 5 MB.");
            }
            //name
            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
            if (fileName.Length > 50)
            {
                throw new Exception("File name exceeds the limit of 50 characters.");
            }
            //path
            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads/images");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }
            //file name
            string uniqueFileName = Guid.NewGuid().ToString();
            string filePath = Path.Combine(uploadsFolder, uniqueFileName) + fileExtension; ;
            //save file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            //return file path


            return filePath;
        }
    }
}
