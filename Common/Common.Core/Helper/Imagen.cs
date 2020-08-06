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
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);

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
    }
}
