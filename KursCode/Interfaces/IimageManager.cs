using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace KursCode.Interfaces
{
    public interface IimageManager
    {
        string ConvertImageToBase64(BitmapImage image);
        void SelectImage(BitmapImage image, string workImage);
    }
}
