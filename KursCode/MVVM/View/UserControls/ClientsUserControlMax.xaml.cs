using Clients;
using KursCode.Interfaces;
using KursCode.MVVM.View.Windows.Dialog;
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
using KursCode.MVVM.Model.Managers;
using Microsoft.Win32;
using System.Diagnostics;

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

        IimageManager imageManager = new imageManager();
        IpdfManager pdfManager = new pdfManager();
        private byte[] pdfData {get; set; }

        public void SetData(corporationClass corpData)
        {
            Surname.Text = corpData._CorporationName;
            Name.Visibility = Visibility.Collapsed;
            TextAge.Text = "Возраст от: ";
            imageBorder.Visibility = Visibility.Collapsed;
            Age.Text = corpData._Age;
            Location.Text = corpData._City;
            Education.Text = corpData._Education;
            Citizenship.Text = corpData._Citizenship;
            Work_experience.Text = corpData._Work_experience;
            Empoyment.Text = corpData._Empoyment;
            Shedule.Text = corpData._Shedule;
            salaryText.Text = "Зарплата";
            StringBuilder skillsBuilder = new StringBuilder();
            foreach (var skill in corpData._Skills)
            {
                if (skillsBuilder.Length > 0)
                {
                    skillsBuilder.Append(", ");
                }
                skillsBuilder.Append(skill);
            }
            Skills.Text = skillsBuilder.ToString();

            StringBuilder qualitiesBuilder = new StringBuilder();
            foreach (var quality in corpData._Personal_qualities)
            {
                if (qualitiesBuilder.Length > 0)
                {
                    qualitiesBuilder.Append(", ");
                }
                qualitiesBuilder.Append(quality);
            }
            Qualities.Text = qualitiesBuilder.ToString();

            Description.Text = corpData._Description;
            Post.Text = corpData._Post;
            Salary.Text = "от: " + corpData._Salary_min + " до: " + corpData._Salary_max;
            Phone_number.Text = corpData._Phone_number;
            Email.Text = corpData._Email;
            
            if(corpData._PDF != "")
                pdfData = pdfManager.fromBase64toPdf(corpData._PDF);
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
                selectedImage.Source = imageManager.ConvertBitmapToImageBrush(imageManager.ConvertImage(workerData._WorkerPhoto)).ImageSource;
            }
            if(workerData._PdfFile != "")
                pdfData = pdfManager.fromBase64toPdf(workerData._PdfFile);

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

        private void PDF_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (pdfData == null || pdfData.Length == 0)
                {
                    MessageBox.Show("Нет данных PDF для открытия.", "Ошибка");
                    return;
                }

                string tempPdfPath = System.IO.Path.GetTempFileName();

                File.WriteAllBytes(tempPdfPath, pdfData);

                Process.Start(new ProcessStartInfo
                {
                    FileName = tempPdfPath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при открытии PDF:");
            }
        }

        private void interview_Button_Click(object sender, RoutedEventArgs e)
        {
            InterviewWindow interviewWindow = new InterviewWindow();
            interviewWindow.ShowDialog();
        }
    }
}
