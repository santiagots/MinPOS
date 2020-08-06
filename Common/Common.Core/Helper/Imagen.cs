using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Common.Core.Helper
{
    public class Imagen
    {
        public static byte[] ImageToByteArray(Image imageIn)
        {
            if (imageIn == null) return null;

            using (var ms = new MemoryStream())
            {
                Bitmap bm = new Bitmap(imageIn);
                bm.Save(ms, ImageFormat.Jpeg);

                return ms.ToArray();
            }
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn == null) return null;

            using (var ms = new MemoryStream(byteArrayIn))
            {
                var returnImage = Image.FromStream(ms);

                return returnImage;
            }
        }

        public static Image Compress(Image imageIn)
        {
            byte[] photoBytes = ImageToByteArray(imageIn);

            ISupportedImageFormat format = new JpegFormat { Quality = 70 };
            Size size = new Size(250, 0);

            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    // Initialize the ImageFactory using the overload to preserve EXIF metadata.
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        // Load, resize, set the format and quality and save an image.
                        imageFactory.Load(inStream)
                                    .Resize(size)
                                    .Format(format)
                                    .Save(outStream);
                    }
                    return Image.FromStream(outStream);
                }
            }
        }
    }
}
