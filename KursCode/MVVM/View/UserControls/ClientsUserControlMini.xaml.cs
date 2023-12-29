  using Clients;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Drawing;


namespace KursCode.MVVM.View.UserControls
{
    public partial class ClientsUserControlMini : UserControl
    {

        public ClientsUserControlMini()
        {
            InitializeComponent();
        }

        private workerClass _workerData;
        public workerClass WorkerData
        {
            get { return _workerData; }
            set { if(_workerData != value)
                    _workerData = value;
            }
        }



        private Bitmap ConvertImage(string base64String)
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

        private ImageBrush ConvertBitmapToImageBrush(Bitmap bitmap)
        {
            if (bitmap == null)
            {
                // Handle the case where the bitmap is null (return a default ImageBrush, log an error, etc.)
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

        public void SetDarkBackground()
        {
            mainBorder.Background = System.Windows.Media.Brushes.LightGray;
        }

        // Метод для восстановления исходного цвета фона
        public void RestoreBackground()
        {
            mainBorder.Background = System.Windows.Media.Brushes.White;
        }

        public void SetData(workerClass data)
        {
            this.Surname.Text = data._Surname;
            this.Name.Text = data._WorkerName;
            this.Post.Text = data._Post;
            ImageBrush imageBrush = ConvertBitmapToImageBrush(ConvertImage(data._WorkerPhoto));

            if (imageBrush != null)
            {
                if (this.Photo == null)
                {
                    this.Photo = new ImageBrush();
                }

                this.Photo.ImageSource = imageBrush.ImageSource;
                _workerData = data;
            }
            else
            {
                Console.WriteLine("Image conversion failed or resulted in a null ImageBrush.");
            }
        }

        public void SetData(corporationClass data)
        {
            this.Surname.Text = data._CorporationName;
            this.Name.Visibility = Visibility.Collapsed;
            this.Post.Text = data._Post;
            photoEllips.Visibility = Visibility.Collapsed;
        }

        public workerClass GetData()
        {
            return _workerData;
        }

        public event EventHandler<EventArgs> MiniControlClicked;
        public void OnMiniControlClicked()
        {
            MiniControlClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
