using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KursCode.Interfaces
{
    public interface IimageManager
    {
        string ConvertImageToBase64(BitmapImage image);
        BitmapImage SelectImage();
        Bitmap ConvertImage(string base64String);
        ImageBrush ConvertBitmapToImageBrush(Bitmap bitmap);
    }
}
