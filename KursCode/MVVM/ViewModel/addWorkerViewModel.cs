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

namespace KursCode.MVVM.ViewModel
{
    public class addWorkerViewModel : INotifyPropertyChanged
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

        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { if(_userId != value) { _userId = value; OnPropertyChanged(nameof(UserId)); } }
        }


        private workerClass worker;


        private BitmapImage _workerPhoto;
        private Visibility _selectedImageVisibility;
        private Visibility _photoIconVisibility;

        public ObservableCollection<string> Skills
        {
            get { return worker._Skills; }
            set
            {
                if (worker._Skills != value)
                {
                    worker = new workerClass(worker._WorkerName, worker._Surname, worker._Post, worker._Email, worker._City, worker._Description, _userId, worker._Personal_qualities, value, worker._Citizenship, worker._Empoyment, worker._Shedule, null, worker._Work_experience, worker._Salary_need, worker._PdfFile, worker._WorkerPhoto);
                    OnPropertyChanged(nameof(Skills));
                }
            }
        }

        
        
        //(string workerName, string surname, string post, string email, string city, string description, int userID, ObservableCollection<string> personal_qualities, ObservableCollection<string> skills, Dictionary<int, string> citizenship, Dictionary<int, string> employment, 
        //    Dictionary<int, string> shedule, Dictionary<int, string> status, 
        //    int work_experience, int salary, int salary_need, string pdfFile, string workerPhoto)

        public ObservableCollection<string> Qualities
        {
            get { return worker._Personal_qualities; }
            set
            {
                if (worker._Personal_qualities != value)
                {
                    worker = new workerClass(worker._WorkerName, worker._Surname, worker._Post, worker._Email, worker._City, worker._Description, _userId, value, worker._Skills, worker._Citizenship, worker._Empoyment, worker._Shedule, null, worker._Work_experience, worker._Salary_need, worker._PdfFile, worker._WorkerPhoto, worker._PhoneNumber);
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

        public ICommand SaveCommand { get; private set; }
        private void Save()
        {
            foreach (var textBox in textBoxListSkills)
            {
                Skills.Add(textBox.Text);
            }
            foreach(var textBox in textBoxListQualities)
            {
                Qualities.Add(textBox.Text);
            }
            worker.AddData();
        }

        public string WorkerName
        {
            get { return worker._WorkerName; }
            set
            {
                if (worker._WorkerName != value)
                {
                    worker = new workerClass(value, worker._Surname, worker._Post, worker._Email, worker._City, worker._Description, _userId, worker._Personal_qualities, worker._Skills, worker._Citizenship, worker._Empoyment, worker._Shedule, null, worker._Work_experience, worker._Salary_need, worker._PdfFile, worker._WorkerPhoto, worker._PhoneNumber,worker._Education);
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
                    worker = new workerClass(worker._WorkerName, value, worker._Post, worker._Email, worker._City, worker._Description, _userId, worker._Personal_qualities, worker._Skills, worker._Citizenship, worker._Empoyment, worker._Shedule, null, worker._Work_experience, worker._Salary_need, worker._PdfFile, worker._WorkerPhoto, worker._PhoneNumber, worker._Education);
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
                    worker = new workerClass(worker._WorkerName, worker._Surname, value, worker._Email, worker._City, worker._Description, _userId, worker._Personal_qualities, worker._Skills, worker._Citizenship, worker._Empoyment, worker._Shedule, null, worker._Work_experience, worker._Salary_need, worker._PdfFile, worker._WorkerPhoto, worker._PhoneNumber, worker._Education);
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
                    worker = new workerClass(worker._WorkerName, worker._Surname, worker._Post, worker._Email, value, worker._Description, _userId, worker._Personal_qualities, worker._Skills, worker._Citizenship, worker._Empoyment, worker._Shedule, null, worker._Work_experience, worker._Salary_need, worker._PdfFile, worker._WorkerPhoto, worker._PhoneNumber, worker._Education);
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
                    worker = new workerClass(worker._WorkerName, worker._Surname, worker._Post, worker._Email, worker._City, worker._Description, _userId, worker._Personal_qualities, worker._Skills, worker._Citizenship, worker._Empoyment, worker._Shedule, null, worker._Work_experience, worker._Salary_need, worker._PdfFile, worker._WorkerPhoto, worker._PhoneNumber, value);
                    OnPropertyChanged(nameof(Education));
                }
            }
        }

        public string Salary
        {
            get { return worker._Salary_need; }
            set
            {
                if (worker._Salary_need != value)
                {
                    worker = new workerClass(worker._WorkerName, worker._Surname, worker._Post, worker._Email, worker._City, worker._Description, _userId, worker._Personal_qualities, worker._Skills, worker._Citizenship, worker._Empoyment, worker._Shedule, null, worker._Work_experience, value, worker._PdfFile, worker._WorkerPhoto, worker._PhoneNumber, worker._Education);
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
                    worker = new workerClass(worker._WorkerName, worker._Surname, worker._Post, value, worker._City, worker._Description, _userId, worker._Personal_qualities, worker._Skills, worker._Citizenship, worker._Empoyment, worker._Shedule, null, worker._Work_experience, worker._Salary_need, worker._PdfFile, worker._WorkerPhoto, worker._PhoneNumber, worker._Education);
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
                    worker = new workerClass(worker._WorkerName, worker._Surname, worker._Post, worker._Email, worker._City, value, _userId, worker._Personal_qualities, worker._Skills, worker._Citizenship, worker._Empoyment, worker._Shedule, null, worker._Work_experience, worker._Salary_need, worker._PdfFile, worker._WorkerPhoto, worker._PhoneNumber, worker._Education);
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public string Age
        {
            get { return worker.age; }
            set
            {
                if (_age != value)
                {
                    worker = new workerClass(value, worker._Surname, worker._Post, worker._Email, worker._City, worker._Description, _userId, worker._Personal_qualities, worker._Skills, worker._Citizenship, worker._Empoyment, worker._Shedule, null, worker._Work_experience, worker._Salary_need, worker._PdfFile, worker._WorkerPhoto, worker._PhoneNumber, worker._Education);
                    _age = FormatNumeric(value);
                    OnPropertyChanged(nameof(Age));
                    UpdateDisplayTextAge();
                }
            }
        }

        public string WorkExperience
        {
            get { return _workExperience; }
            set
            {
                if (_workExperience != value)
                {
                    _workExperience = FormatNumeric(value);
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
                    ConvertPDFToBase64Async();
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

        private string ConvertImageToBase64(BitmapImage image)
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

        private string _base64StringImage;
        public string Base64StringImage
        {
            get { return _base64StringImage; }
            set
            {
                if (_base64StringImage != value)
                {
                    _base64StringImage = value;
                    OnPropertyChanged(nameof(Base64StringImage));
                }
            }
        }

        public void SelectImage()
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
                    WorkerPhoto = bitmap;

                    SelectedImageVisibility = Visibility.Visible;
                    PhotoIconVisibility = Visibility.Collapsed;

                        _base64StringImage = ConvertImageToBase64(bitmap);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*",
                Title = "Выберите PDF файл"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = Path.GetFileName(openFileDialog.FileName);
                SelectedPDFFilePath = fileName;
            }
        }

        private string _base64String;
        public string Base64String
        {
            get { return _base64String; }
            set
            {
                if (_base64String != value)
                {
                    _base64String = value;
                    OnPropertyChanged(nameof(Base64String));
                }
            }
        }

        private async void ConvertPDFToBase64Async()
        {
            try
            {
                if (!string.IsNullOrEmpty(SelectedPDFFilePath) && File.Exists(SelectedPDFFilePath))
                {
                    byte[] pdfBytes = await File.ReadAllBytesAsync(SelectedPDFFilePath);
                    string base64String = Convert.ToBase64String(pdfBytes);
                    Base64String = base64String;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting PDF to Base64: {ex.Message}");
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

        private string _selectedCitizenship;
        public string SelectedCitizenship
        {
            get { return _selectedCitizenship; }
            set
            {
                if (_selectedCitizenship != value)
                {
                    _selectedCitizenship = value;
                    OnPropertyChanged(nameof(SelectedCitizenship));
                }
            }
        }

        private string _selectedShedule;
        public string SelectedShedule
        {
            get { return _selectedShedule; }
            set
            {
                if (_selectedShedule != value)
                {
                    _selectedShedule = value;
                    OnPropertyChanged(nameof(SelectedShedule));
                }
            }
        }

        private string _selectedEmpoyment;
        public string SelectedEmpoyment
        {
            get { return _selectedEmpoyment; }
            set
            {
                if (_selectedEmpoyment != value)
                {
                    _selectedEmpoyment = value;
                    OnPropertyChanged(nameof(SelectedEmpoyment));
                }
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (_phoneNumber != value)
                {
                    _phoneNumber = FormatPhoneNumber(value);
                    OnPropertyChanged(nameof(PhoneNumber));
                }
            }
        }

        private string FormatNumeric(string input)
        {
            string digitsOnly = Regex.Replace(input, "[^0-9]", "");

            return digitsOnly;
        }


        private string FormatPhoneNumber(string input)
        {
            string digitsOnly = Regex.Replace(input, "[^0-9]", "");

            if (digitsOnly.Length > 0)
            {
                if (digitsOnly.Length <= 11)
                {
                    digitsOnly = "+7" + digitsOnly.Substring(1);
                    return Regex.Replace(digitsOnly, @"(\d{1})(\d{3})(\d{3})(\d{2})(\d{2})", "$1-$2-$3-$4-$5");
                }
                else
                {
                    digitsOnly = digitsOnly.Substring(0, 11);
                    return FormatPhoneNumber(digitsOnly);
                }
            }

            return string.Empty;
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

        private string _yearTextWE="лет";
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
                //YearTextWE = "Некорректный ввод";
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
                //YearTextAge = "Некорректный ввод";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
