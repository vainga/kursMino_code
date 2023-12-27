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

namespace KursCode.MVVM.Model.Managers
{
    public class imageManager : IimageManager
    {
        public string ConvertImageToBase64(BitmapImage image)
        {
            if (image != null)
            {
                // Преобразовать BitmapImage в MemoryStream
                MemoryStream memoryStream = new MemoryStream();
                BitmapEncoder encoder = new PngBitmapEncoder(); // Используйте другой энкодер, если формат изображения отличается
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(memoryStream);

                // Преобразовать MemoryStream в массив байт
                byte[] imageBytes = memoryStream.ToArray();

                // Преобразовать массив байт в строку Base64
                string base64String = Convert.ToBase64String(imageBytes);

                return base64String;
            }

            return null;
        }

        public void SelectImage(BitmapImage image,string workImage)
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
                    image = bitmap;


                    workImage = ConvertImageToBase64(bitmap);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }





    }
}
