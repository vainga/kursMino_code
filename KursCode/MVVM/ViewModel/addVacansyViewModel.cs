using Clients;
using KursCode.Interfaces;
using KursCode.MVVM.Model.Managers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace KursCode.MVVM.ViewModel
{
    public class addVacansyViewModel : baseViewModel
    {
        public addVacansyViewModel()
        {
            SelectPDFCommand = new RelayCommand(SelectPDF);
            OnPropertyChanged(nameof(SelectedPDFFilePath));
            textBoxListSkills = new ObservableCollection<TextBox>();
            textBoxListQualities = new ObservableCollection<TextBox>();
            SaveCommand = new RelayCommand(Save);
            corporation = new corporationClass();
        }

        IpdfManager pdfManager = new pdfManager();
        iviewModelFormatManager formatManager = new viewFormatManager();

        static private int _userId;
        public int UserId
        {
            get { return _userId; }
            set
            {
                if (_userId != value)
                {
                    _userId = value;
                }
            }
        }

        private corporationClass corporation;
        private Visibility _selectedImageVisibility;
        private Visibility _photoIconVisibility;
        private Visibility _errorMessageVisibility = Visibility.Collapsed;
        public Visibility ErrorMessageVisibility
        {
            get { return _errorMessageVisibility; }
            set
            {
                if (_errorMessageVisibility != value)
                {
                    _errorMessageVisibility = value;
                    OnPropertyChanged(nameof(ErrorMessageVisibility));
                }
            }
        }

        //public corporationClass(string corporationName, string post, string email, string city, string description, bool distant, ObservableCollection<string> personal_qualities, ObservableCollection<string> skills, string citizenship, string employment, string shedule, string status, int work_experience_min, int work_experience_max,
        //    bool work_experience_need, int salary)
        //    : base(post, email, city, description, personal_qualities, skills, citizenship, employment, shedule, status)

        public ObservableCollection<string> Skills
        {
            get { return corporation._Skills; }
            set
            {
                if (corporation._Skills != value)
                {
                    corporation = new corporationClass(corporation._CorporationName,corporation._Post,corporation._Email,corporation._City,corporation._Description,)
                    OnPropertyChanged(nameof(Skills));
                }
            }
        }

        public ObservableCollection<string> Qualities
        {
            get { return worker._Personal_qualities; }
            set
            {
                if (worker._Personal_qualities != value)
                {
                    worker = new workerClass(worker._WorkerName, worker._Surname, worker._Post, worker._Email, worker._City, worker._Description, _userId, value, worker._Skills, worker._Citizenship, worker._Empoyment, worker._Shedule, null, worker._Work_experience, worker._Salary_need, worker._PdfFile, worker._WorkerPhoto, worker._PhoneNumber, worker._Education, worker._Age);
                    OnPropertyChanged(nameof(Qualities));
                }
            }
        }

        private ObservableCollection<TextBox> textBoxListQualities;
        public ObservableCollection<TextBox> TextBoxListQualities
        {
            get { return textBoxListQualities; }
            set
            {
                if (textBoxListQualities != value)
                {
                    textBoxListQualities = value;
                    OnPropertyChanged(nameof(TextBoxListQualities));
                }
            }
        }

        private ObservableCollection<TextBox> textBoxListSkills;
        public ObservableCollection<TextBox> TextBoxListSkills
        {
            get { return textBoxListSkills; }
            set
            {
                if (textBoxListSkills != value)
                {
                    textBoxListSkills = value;
                    OnPropertyChanged(nameof(TextBoxListSkills));
                }
            }
        }

        private string _errorMessageContent = "Ошибка!";
        public string ErrorMessageContent
        {
            get { return _errorMessageContent; }
            set
            {
                if (_errorMessageContent != value)
                {
                    _errorMessageContent = value;
                    OnPropertyChanged(nameof(ErrorMessageContent));
                }
            }
        }

        public event EventHandler SaveSuccessful;
        protected virtual void OnSaveSuccessful()
        {
            SaveSuccessful?.Invoke(this, EventArgs.Empty);
        }

        private void Save()
        {
            try
            {
                foreach (var textBox in textBoxListSkills)
                {
                    Skills.Add(textBox.Text);
                }
                foreach (var textBox in textBoxListQualities)
                {
                    Qualities.Add(textBox.Text);
                }
                if (string.IsNullOrWhiteSpace(worker._WorkerName) ||
                    string.IsNullOrWhiteSpace(worker._Surname) ||
                    string.IsNullOrWhiteSpace(worker._Post) ||
                    string.IsNullOrWhiteSpace(worker._Email) ||
                    string.IsNullOrWhiteSpace(worker._City) ||
                    string.IsNullOrWhiteSpace(worker._Description) ||
                    worker._Skills == null || worker._Skills.Count == 0 ||
                    worker._Citizenship == null ||
                    worker._Empoyment == null ||
                    worker._Shedule == null ||
                    worker._Personal_qualities == null || worker._Personal_qualities.Count == 0)
                {
                    _errorMessageVisibility = Visibility.Visible;
                    _errorMessageContent = "Все поля(кроме фотографии и pdf) должны быть заполнены!";
                    OnPropertyChanged(nameof(ErrorMessageContent));
                    OnPropertyChanged(nameof(ErrorMessageVisibility));
                }
                else
                {
                    OnSaveSuccessful();
                    worker.AddData(_userId);
                }
            }
            catch (Exception ex)
            {
                _errorMessageVisibility = Visibility.Visible;
                _errorMessageContent = ex.Message;
                OnPropertyChanged(nameof(ErrorMessageContent));
                OnPropertyChanged(nameof(ErrorMessageVisibility));
            }
        }


    }
}
