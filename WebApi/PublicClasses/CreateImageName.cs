namespace WebAPI.PublicClasses
{
    public class CreateImageNameHelper
    {
        public string CreateImageName(IFormFile image)
        {
            //extention
            List<string> allowedExtensions = new List<string> { ".png", ".jpg", ".jpeg", ".gif", ".webp" };
            string fileExtension = Path.GetExtension(image.FileName).ToLower();
            if (!allowedExtensions.Contains(fileExtension))
            {
                throw new Exception("Valid file type. Only .png, .jpg, .jpeg, .gif, .webp are allowed.");
            }
            //size
            if (image.Length > 5 * 1024 * 1024) // 5 MB
            {
                throw new Exception("File size exceeds the limit of 5 MB.");
            }
            //name
            string fileName = Path.GetFileNameWithoutExtension(image.FileName);
            if (fileName.Length > 50)
            {
                throw new Exception("File name exceeds the limit of 50 characters.");
            }

            //file name
            string uniqueFileName = Guid.NewGuid().ToString();
            string fullFileName = Path.Combine(uniqueFileName + fileExtension);


            return fullFileName;
        }
    }
}
