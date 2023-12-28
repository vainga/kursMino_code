using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using KursCode.MVVM.View.UserControls;
using System.Collections.ObjectModel;
using KursCode.MVVM.Model;
using System.Text.RegularExpressions;
using System.Numerics;
using System.Windows.Controls;
using Clients;
using KursCode.Interfaces;
using System.Xml.Linq;
using KursCode.MVVM.Model.Managers;

namespace KursCode.MVVM.ViewModel
{
    public class addWorkerViewModel : baseViewModel
    {
        
        
        public addWorkerViewModel()
        {
            SelectPDFCommand = new RelayCommand(SelectPDF);
            OnPropertyChanged(nameof(SelectedPDFFilePath));

            textBoxListSkills = new ObservableCollection<TextBox>();
            textBoxListQualities = new ObservableCollection<TextBox>();
            SaveCommand = new RelayCommand(Save);
            worker = new workerClass();
        }

        IimageManager imageManager = new imageManager();
        IpdfManager pdfManager = new pdfManager();
        iviewModelFormatManager formatManager = new viewFormatManager();

        static private int _userId;
        public int UserId
        {
            get { return _userId; }
            set 
            { if (_userId != value) 
                {
                    _userId = value;
                } 
            }
        }


        private workerClass worker;
        private BitmapImage _workerPhoto;
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

        public ObservableCollection<string> Skills
        {
            get { return worker._Skills; }
            set
            {
                if (worker._Skills != value)
                {
                    worker = new workerClass(worker._WorkerName, worker._Surname, worker._Post, worker._Email, worker._City, worker._Description, _userId, worker._Personal_qualities, value, worker._Citizenship, worker._Empoyment, worker._Shedule, null
                        , worker._Work_experience, worker._Salary_need, worker._PdfFile, worker._WorkerPhoto,worker._PhoneNumber,worker._Education,worker._Age);
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
                    worker = new workerClass(worker._WorkerName, worker._Surname, worker._Post, worker._Email, worker._City, worker._Description, _userId, value, worker._Skills, worker._Citizenship, worker._Empoyment, worker._Shedule, null, worker._Work_experience, worker._Salary_need, worker._PdfFile, worker._WorkerPhoto, worker._PhoneNumber,worker._Education,worker._Age);
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

        private string _errorMessageContent = "Ошибка!";
        public ICommand SaveCommand { get; private set; }
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
                    worker.AddData(_userId);
                    OnSaveSuccessful();
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

        private string _workerName;
        public string WorkerName
        {
            get { return worker._WorkerName; }
            set
            {
                if (worker._WorkerName != value)
                {
                    _workerName = formatManager.FormatLetter(value);
                    worker = new workerClass(_workerName, worker._Surname, worker._Post, worker._Email, worker._City, worker._Description, _userId, worker._Personal_qualities, worker._Skills, worker._Citizenship, worker._Empoyment, worker._Shedule, null, worker._Work_experience, worker._Salary_need, worker._PdfFile, worker._WorkerPhoto, worker._PhoneNumber, worker._Education, worker._Age);
                    OnPropertyChanged(nameof(WorkerName));
                }
            }
        }

        public string WorkerSurname
        {
            get { return worker._Surname; }
            set
            {
                if (worker._Surname != value)
                {
                    worker = new workerClass(worker._WorkerName, formatManager.FormatLetter(value), worker._Post, worker._Email, worker._City, worker._Description, _userId, worker._Personal_qualities, worker._Skills, worker._Citizenship, worker._Empoyment, worker._Shedule, null, worker._Work_experience, worker._Salary_need, worker._PdfFile, worker._WorkerPhoto, worker._PhoneNumber, worker._Education, worker._Age);
                    OnPropertyChanged(nameof(WorkerSurname));
                }
            }
        }

        public string Post
        {
            get { return worker._Post; }
            set
            {
                if (worker._Post != value)
                {
                    worker = new workerClass(worker._WorkerName, worker._Surname, value, worker._Email, worker._City, worker._Description, _userId, worker._Personal_qualities, worker._Skills, worker._Citizenship, worker._Empoyment, worker._Shedule, null, worker._Work_experience, worker._Salary_need, worker._PdfFile, worker._WorkerPhoto, worker._PhoneNumber, worker._Education, worker._Age);
                    OnPropertyChanged(nameof(Post));
                }
            }
        }

        public string Location
        {
            get { return worker._City; }
            set
            {
                if (worker._City != value)
                {
                    worker = new workerClass(worker._WorkerName, worker._Surname, worker._Post, worker._Email, value, worker._Description, _userId, worker._Personal_qualities, worker._Skills, worker._Citizenship, worker._Empoyment, worker._Shedule, null, worker._Work_experience, worker._Salary_need, worker._PdfFile, worker._WorkerPhoto, worker._PhoneNumber, worker._Education, worker._Age);
                    OnPropertyChanged(nameof(Location));
                }
            }
        }

        public string Education
        {
            get { return worker._Education; }
            set
            {
                if (worker._Education != value)
                {
                    worker = new workerClass(worker._WorkerName, worker._Surname, worker._Post, worker._Email, worker._City, worker._Description, _userId, worker._Personal_qualities, worker._Skills, worker._Citizenship, worker._Empoyment, worker._Shedule, null, worker._Work_experience, worker._Salary_need, worker._PdfFile, worker._WorkerPhoto, worker._PhoneNumber, value, worker._Age);
                    OnPropertyChanged(nameof(Education));
                }
            }
        }

        public string _salary;
        public string Salary
        {
            get { return worker._Salary_need; }
            set
            {
                if (worker._Salary_need != value)
                {
                    _salary = formatManager.FormatNumeric(value);
                    worker = new workerClass(worker._WorkerName, worker._Surname, worker._Post, worker._Email, worker._City, worker._Description, _userId, worker._Personal_qualities, worker._Skills, worker._Citizenship, worker._Empoyment, worker._Shedule, null, worker._Work_experience, _salary, worker._PdfFile, worker._WorkerPhoto, worker._PhoneNumber, worker._Education, worker._Age);
                    OnPropertyChanged(nameof(Salary));
                }
            }
        }

        public string Email
        {
            get { return worker._Email; }
            set
            {
                if (worker._Email != value)
                {
                    worker = new workerClass(worker._WorkerName, worker._Surname, worker._Post, formatManager.RemoveSpaces(value), worker._City, worker._Description, _userId, worker._Personal_qualities, worker._Skills, worker._Citizenship, worker._Empoyment, worker._Shedule, null, worker._Work_experience, worker._Salary_need, worker._PdfFile, worker._WorkerPhoto, worker._PhoneNumber, worker._Education, worker._Age);
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public string Description
        {
            get { return worker._Description; }
            set
            {
                if (worker._Description != value)
                {
                    worker = new workerClass(worker._WorkerName, worker._Surname, worker._Post, worker._Email, worker._City, value, _userId, worker._Personal_qualities, worker._Skills, worker._Citizenship, worker._Empoyment, worker._Shedule, null, worker._Work_experience, worker._Salary_need, worker._PdfFile, worker._WorkerPhoto, worker._PhoneNumber, worker._Education, worker._Age);
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        private string _age;
        public string Age
        {
            get { return worker._Age; }
            set
            {
                if (worker._Age != value)
                {
                    _age = formatManager.FormatNumeric(value);
                    worker = new workerClass(worker._WorkerName, worker._Surname, worker._Post, worker._Email, worker._City, worker._Description, _userId, worker._Personal_qualities, worker._Skills, worker._Citizenship, worker._Empoyment, worker._Shedule, null, worker._Work_experience, worker._Salary_need, worker._PdfFile, worker._WorkerPhoto, worker._PhoneNumber, worker._Education, _age);                   
                    OnPropertyChanged(nameof(Age));
                    UpdateDisplayTextAge();
                }
            }
        }

        private string _workExperience;
        public string WorkExperience
        {
            get { return worker._Work_experience; }
            set
            {
                if (worker._Work_experience != value)
                {
                    _workExperience = formatManager.FormatNumeric(value);
                    worker = new workerClass(worker._WorkerName, worker._Surname, worker._Post, worker._Email, worker._City, worker._Description, _userId, worker._Personal_qualities, worker._Skills, worker._Citizenship, worker._Empoyment, worker._Shedule, null, _workExperience, worker._Salary_need, worker._PdfFile, worker._WorkerPhoto, worker._PhoneNumber, worker._Education, worker._Age);
                    OnPropertyChanged(nameof(WorkExperience));
                    UpdateDisplayTextWE();
                }
            }
        }

        private string _selectedPDFFilePath = "PDF(необязательно)";
        public string SelectedPDFFilePath
        {
            get { return _selectedPDFFilePath; }
            set
            {
                if (_selectedPDFFilePath != value)
                {
                    _selectedPDFFilePath = value;
                    OnPropertyChanged(nameof(SelectedPDFFilePath));
                }
            }
        }

        public BitmapImage WorkerPhoto
        {
            get { return _workerPhoto; }
            set
            {
                if (_workerPhoto != value)
                {
                    _workerPhoto = value;
                    OnPropertyChanged(nameof(WorkerPhoto));
                }
            }
        }

        public Visibility SelectedImageVisibility
        {
            get { return _selectedImageVisibility; }
            set
            {
                if (_selectedImageVisibility != value)
                {
                    _selectedImageVisibility = value;
                    OnPropertyChanged(nameof(SelectedImageVisibility));
                }
            }
        }

        public Visibility PhotoIconVisibility
        {
            get { return _photoIconVisibility; }
            set
            {
                if (_photoIconVisibility != value)
                {
                    _photoIconVisibility = value;
                    OnPropertyChanged(nameof(PhotoIconVisibility));
                }
            }
        }       

        public string Base64StringImage
        {
            get { return worker._WorkerPhoto; }
            set
            {
                if (worker._WorkerPhoto != value)
                {
                    worker = new workerClass(worker._WorkerName, worker._Surname, worker._Post, worker._Email, worker._City, worker._Description, _userId, worker._Personal_qualities, worker._Skills, worker._Citizenship, worker._Empoyment, worker._Shedule, null, worker._Work_experience, worker._Salary_need, worker._PdfFile, value, worker._PhoneNumber, worker._Education, worker._Age);
                    OnPropertyChanged(nameof(Base64StringImage));
                }
            }
        }


        public void SelectImage()
        {
            try
            {
                    imageManager.SelectImage(WorkerPhoto,worker._WorkerPhoto);
                    SelectedImageVisibility = Visibility.Visible;
                    PhotoIconVisibility = Visibility.Collapsed;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка IMAGE!");
            }
        }


        private ICommand _selectPDFCommand;
        public ICommand SelectPDFCommand
        {
            get { return _selectPDFCommand; }
            set
            {
                if (_selectPDFCommand != value)
                {
                    _selectPDFCommand = value;
                    OnPropertyChanged(nameof(SelectPDFCommand));
                }
            }
        }

        public void SelectPDF()
        {
            try
            {
                pdfManager.SelectPDF(SelectedPDFFilePath, worker._PdfFile);
            }
            catch(Exception ex ) 
            {
                MessageBox.Show("Ошибка PDF!");
            }
        }

        //                SelectedPDFFilePath = fileName;
        //worker._PdfFile = base64String;
        //            SelectedPDFFilePath = fileName;
        //string fileName = Path.GetFileName(openFileDialog.FileName);


        public string Base64String
        {
            get { return worker._PdfFile; }
            set
            {
                try
                {
                    if (worker._PdfFile != value)
                    {
                        worker = new workerClass(worker._WorkerName, worker._Surname, worker._Post, worker._Email, worker._City, worker._Description, _userId, worker._Personal_qualities, worker._Skills, worker._Citizenship, worker._Empoyment, worker._Shedule, null, worker._Work_experience, worker._Salary_need, value, worker._WorkerPhoto, worker._PhoneNumber, worker._Education, worker._Age);
                        OnPropertyChanged(nameof(Base64String));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading pdf: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private Dictionary<int, string> _Citizenship = new Dictionary<int, string>
        {
            {1,"Российская Федерация" },
            {2,"Другое" }
        };

        public Dictionary<int, string> Citizenship
        {
            get { return _Citizenship; }
        }

        private Dictionary<int, string> _Shedule = new Dictionary<int, string>
        {
            {1,"Полный день" },
            {2,"Сменный график" },
            {3,"Гибкий график" },
            {4,"Удаленная работа" },
            {5,"Вахтовый метод" }
        };

        public Dictionary<int, string> Shedule
        {
            get { return _Shedule; }
        }

        Dictionary<int, string> _Empoyment = new Dictionary<int, string>
        {
            {1,"Полная" },
            {2,"Частичная" },
            {3,"Стажировка" }
        };
        public Dictionary<int, string> Empoyment
        {
            get { return _Empoyment; }
        }

        public string SelectedCitizenship
        {
            get { return worker._Citizenship; }
            set
            {
                if (worker._Citizenship != value)
                {
                    worker = new workerClass(worker._WorkerName, worker._Surname, worker._Post, worker._Email, worker._City, worker._Description, _userId, worker._Personal_qualities, worker._Skills, value, worker._Empoyment, worker._Shedule, null, worker._Work_experience, worker._Salary_need, worker._PdfFile, worker._WorkerPhoto, worker._PhoneNumber, worker._Education, worker._Age);
                    OnPropertyChanged(nameof(SelectedCitizenship));
                }
            }
        }

        public string SelectedShedule
        {
            get { return worker._Shedule; }
            set
            {
                if (worker._Shedule != value)
                {
                    worker = new workerClass(worker._WorkerName, worker._Surname, worker._Post, worker._Email, worker._City, worker._Description, _userId, worker._Personal_qualities, worker._Skills, worker._Citizenship, worker._Empoyment, value, null, worker._Work_experience, worker._Salary_need, worker._PdfFile, worker._WorkerPhoto, worker._PhoneNumber, worker._Education, worker._Age);
                    OnPropertyChanged(nameof(SelectedShedule));
                }
            }
        }

        public string SelectedEmpoyment
        {
            get { return worker._Empoyment; }
            set
            {
                if (worker._Empoyment != value)
                {
                    worker = new workerClass(worker._WorkerName, worker._Surname, worker._Post, worker._Email, worker._City, worker._Description, _userId, worker._Personal_qualities, worker._Skills, worker._Citizenship, value, worker._Shedule, null, worker._Work_experience, worker._Salary_need, worker._PdfFile, worker._WorkerPhoto, worker._PhoneNumber, worker._Education, worker._Age);
                    OnPropertyChanged(nameof(SelectedEmpoyment));
                }
            }
        }

        public string _phoneNumber;
        public string PhoneNumber
        {
            get { return worker._PhoneNumber; }
            set
            {
                if (worker._PhoneNumber != value)
                {
                    _phoneNumber= formatManager.FormatPhoneNumber(value);
                    worker = new workerClass(worker._WorkerName, worker._Surname, worker._Post, worker._Email, worker._City, worker._Description, _userId, worker._Personal_qualities, worker._Skills, worker._Citizenship, worker._Empoyment, worker._Shedule, null, worker._Work_experience, worker._Salary_need, worker._PdfFile, worker._WorkerPhoto, _phoneNumber, worker._Education, worker._Age);
                    OnPropertyChanged(nameof(PhoneNumber));
                }
            }
        }

        private string _yearTextAge = "лет";
        public string YearTextAge
        {
            get { return _yearTextAge; }
            set
            {
                if (_yearTextAge != value)
                {
                    _yearTextAge = value;
                    OnPropertyChanged(nameof(YearTextAge));
                }
            }
        }

        private string _yearTextWE = "лет";
        public string YearTextWE
        {
            get { return _yearTextWE; }
            set
            {
                if (_yearTextWE != value)
                {
                    _yearTextWE = value;
                    OnPropertyChanged(nameof(YearTextWE));
                }
            }
        }

        private void UpdateDisplayTextWE()
        {
            if (int.TryParse(_workExperience, out int age))
            {
                int lastDigit = age % 10;
                int lastTwoDigits = age % 100;

                if (lastDigit == 1 && lastTwoDigits != 11)
                    YearTextWE = "год";
                else if (lastDigit >= 2 && lastDigit <= 4 && (lastTwoDigits < 10 || lastTwoDigits >= 20))
                    YearTextWE = "года";
                else
                    YearTextWE = "лет";
            }
            else
            {
            }
        }

        private void UpdateDisplayTextAge()
        {
            if (int.TryParse(_age, out int age))
            {
                int lastDigit = age % 10;
                int lastTwoDigits = age % 100;

                if (lastDigit == 1 && lastTwoDigits != 11)
                    YearTextAge = "год";
                else if (lastDigit >= 2 && lastDigit <= 4 && (lastTwoDigits < 10 || lastTwoDigits >= 20))
                    YearTextAge = "года";
                else
                    YearTextAge = "лет";
            }
            else
            {
            }
        }
    }
}
