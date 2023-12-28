using KursCode.Interfaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Windows.Media;

namespace KursCode.MVVM.Model.Managers
{
    public class imageManager : IimageManager
    {
        public string ConvertImageToBase64(BitmapImage image)
        {
            if (image != null)
            {
                MemoryStream memoryStream = new MemoryStream();
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(memoryStream);

                byte[] imageBytes = memoryStream.ToArray();

                string base64String = Convert.ToBase64String(imageBytes);

                return base64String;
            }

            return null;
        }

        public BitmapImage SelectImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All files (*.*)|*.*",
                Title = "Select an Image"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                    return bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            return null;
        }

            public Bitmap ConvertImage(string base64String)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64String);

                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    using (Bitmap bitmap = new Bitmap(ms))
                    {
                        return new Bitmap(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ImageBrush ConvertBitmapToImageBrush(Bitmap bitmap)
        {
            if (bitmap == null)
            {
                return null;
            }

            try
            {
                MemoryStream memoryStream = new MemoryStream();
                bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);

                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new MemoryStream(memoryStream.ToArray());
                bitmapImage.EndInit();

                ImageBrush imageBrush = new ImageBrush();
                imageBrush.ImageSource = bitmapImage;

                return imageBrush;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting bitmap to ImageBrush: {ex.Message}");
                return null;
            }
        }


    }
}
