using Clients;
using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace KursCode.MVVM.View.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ClientsUserControlMax.xaml
    /// </summary>
    public partial class ClientsUserControlMax : UserControl
    {


        public ClientsUserControlMax()
        {
            InitializeComponent();
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

        public void SetData(corporationClass corpData)
        {
            Surname.Text = corpData._CorporationName;
        }

        public void SetData(workerClass workerData)
        {
            Surname.Text = workerData._Surname;
            Name.Text = workerData._WorkerName;
            Age.Text = workerData._Age;
            Location.Text = workerData._City;
            Education.Text = workerData._Education;
            Citizenship.Text = workerData._Citizenship;
            Work_experience.Text = workerData._Work_experience;
            Empoyment.Text = workerData._Empoyment;
            Shedule.Text = workerData._Shedule;

            StringBuilder skillsBuilder = new StringBuilder();
            foreach (var skill in workerData._Skills)
            {
                if (skillsBuilder.Length > 0)
                {
                    skillsBuilder.Append(", ");
                }
                skillsBuilder.Append(skill);
            }
            Skills.Text = skillsBuilder.ToString();

            StringBuilder qualitiesBuilder = new StringBuilder();
            foreach (var quality in workerData._Personal_qualities)
            {
                if (qualitiesBuilder.Length > 0)
                {
                    qualitiesBuilder.Append(", ");
                }
                qualitiesBuilder.Append(quality);
            }
            Qualities.Text = qualitiesBuilder.ToString();

            Description.Text = workerData._Description;
            Post.Text = workerData._Post;
            Salary.Text = workerData._Salary_need;
            Phone_number.Text = workerData._PhoneNumber;
            Email.Text = workerData._Email;
            if (workerData._WorkerPhoto!="")
            {
                selectedImage.Source = ConvertBitmapToImageBrush(ConvertImage(workerData._WorkerPhoto)).ImageSource;
            }
        } 

        public void ClearData()
        {
            Surname.Text = "";
            Name.Text = "";
            Age.Text = "";
            Location.Text = "";
            Education.Text = "";
            Citizenship.Text = "";
            Work_experience.Text = "";
            Empoyment.Text = "";
            Shedule.Text = "";
            Skills.Text = "";
            Qualities.Text = "";
            Description.Text = "";
            Post.Text = "";
            Salary.Text = "";
            Phone_number.Text = "";
            Email.Text = "";
            selectedImage.Source = null;
        }
    }
}
