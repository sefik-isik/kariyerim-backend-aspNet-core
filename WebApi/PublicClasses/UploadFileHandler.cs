namespace WebAPI.PublicClasses
{
    public class UploadFileHandler
    {
        public string UploadFile(IFormFile file)
        {
            //extention
            List<string> allowedExtensions = new List<string> { ".zip", ".rar", ".doc", ".docx", ".pdf" };
            string fileExtension = Path.GetExtension(file.FileName).ToLower();
            if (!allowedExtensions.Contains(fileExtension))
            {
                throw new Exception("Invalid file type. Only .zip, .rar, .doc, .docx and .pdf are allowed.");
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
            
            //file name
            string uniqueFileName = Guid.NewGuid().ToString();
            string fullFileName = Path.Combine( uniqueFileName + fileExtension);


            return fullFileName;
        }
    }
}
