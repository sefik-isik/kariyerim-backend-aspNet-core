using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Memory;
using SixLabors.ImageSharp.Processing;

namespace WebAPI.PublicClasses
{
    public class ResizeFileHelper
    {
        public string ImageResize(Image image, int maxWidth, int maxHeight)
        {
            if (image.Width > maxWidth || image.Height > maxHeight)
            {
                double widthRatio = (double)image.Width / (double)maxWidth;
                double heightRatio = (double)image.Height / (double)maxHeight;
                double ratio = Math.Max(widthRatio, heightRatio);
                int newWidth = (int)(image.Width / ratio);
                int newHeight = (int)(image.Height / ratio);

                return newWidth.ToString() + "," + newHeight.ToString();
            }
            else
            {
                return image.Width.ToString() + "," + image.Height.ToString();
            }
        }
    }
}
