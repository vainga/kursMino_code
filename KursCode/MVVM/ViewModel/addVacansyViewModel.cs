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
using System.Windows.Input;
using System.Windows.Media.Imaging;

//namespace KursCode.MVVM.ViewModel
//{
//    public class addVacansyViewModel : baseViewModel
//    {
//        public addVacansyViewModel()
//        {
//            SelectPDFCommand = new RelayCommand(SelectPDF);
//            OnPropertyChanged(nameof(SelectedPDFFilePath));
//            textBoxListSkills = new ObservableCollection<TextBox>();
//            textBoxListQualities = new ObservableCollection<TextBox>();
//            SaveCommand = new RelayCommand(Save);
//            corporation = new corporationClass();
//        }

//        IpdfManager pdfManager = new pdfManager();
//        iviewModelFormatManager formatManager = new viewFormatManager();

//        static private int _userId;
//        public int UserId
//        {
//            get { return _userId; }
//            set
//            {
//                if (_userId != value)
//                {
//                    _userId = value;
//                }
//            }
//        }

//        private corporationClass corporation;
//        private Visibility _selectedImageVisibility;
//        private Visibility _photoIconVisibility;
//        private Visibility _errorMessageVisibility = Visibility.Collapsed;
//        public Visibility ErrorMessageVisibility
//        {
//            get { return _errorMessageVisibility; }
//            set
//            {
//                if (_errorMessageVisibility != value)
//                {
//                    _errorMessageVisibility = value;
//                    OnPropertyChanged(nameof(ErrorMessageVisibility));
//                }
//            }
//        }

//        //corporation = new corporationClass(corporation._CorporationName, corporation._Post, corporation._Email, corporation._City, corporation._Description, corporation._Personal_qualities, corporation._Skills, corporation._Citizenship, corporation._Empoyment, corporation._Shedule, corporation._Status, corporation._Work_experience_min, corporation._Work_experience_max, corporation._Salary_min, corporation._Salary_max, corporation._Phone_number, corporation._Education, corporation._Age, corporation._PDF);


//        public ObservableCollection<string> Skills
//        {
//            get { return corporation._Skills; }
//            set
//            {
//                if (corporation._Skills != value)
//                {
//                    corporation = new corporationClass(corporation._CorporationName, corporation._Post, corporation._Email, corporation._City, corporation._Description, corporation._Personal_qualities, value, corporation._Citizenship, corporation._Empoyment,
//                        corporation._Shedule, corporation._Status,
//                        corporation._Work_experience, corporation._Salary_min, corporation._Salary_max, corporation._Phone_number, corporation._Education, corporation._Age, corporation._PDF);
//                    OnPropertyChanged(nameof(Skills));
//                }
//            }
//        }

//        public ObservableCollection<string> Qualities
//        {
//            get { return corporation._Personal_qualities; }
//            set
//            {
//                if (corporation._Personal_qualities != value)
//                {
//                    corporation = new corporationClass(corporation._CorporationName, corporation._Post, corporation._Email, corporation._City, corporation._Description, value, corporation._Skills, corporation._Citizenship, corporation._Empoyment, corporation._Shedule, corporation._Status, corporation._Work_experience, corporation._Salary_min, corporation._Salary_max, corporation._Phone_number, corporation._Education, corporation._Age, corporation._PDF);
//                    OnPropertyChanged(nameof(Qualities));
//                }
//            }
//        }

//        private ObservableCollection<TextBox> textBoxListQualities;
//        public ObservableCollection<TextBox> TextBoxListQualities
//        {
//            get { return textBoxListQualities; }
//            set
//            {
//                if (textBoxListQualities != value)
//                {
//                    textBoxListQualities = value;
//                    OnPropertyChanged(nameof(TextBoxListQualities));
//                }
//            }
//        }

//        private ObservableCollection<TextBox> textBoxListSkills;
//        public ObservableCollection<TextBox> TextBoxListSkills
//        {
//            get { return textBoxListSkills; }
//            set
//            {
//                if (textBoxListSkills != value)
//                {
//                    textBoxListSkills = value;
//                    OnPropertyChanged(nameof(TextBoxListSkills));
//                }
//            }
//        }

//        private string _errorMessageContent = "Ошибка!";
//        public string ErrorMessageContent
//        {
//            get { return _errorMessageContent; }
//            set
//            {
//                if (_errorMessageContent != value)
//                {
//                    _errorMessageContent = value;
//                    OnPropertyChanged(nameof(ErrorMessageContent));
//                }
//            }
//        }

//        public event EventHandler SaveSuccessfulVavancy;
//        protected virtual void OnSaveSuccessfulVacansy()
//        {
//            SaveSuccessfulVavancy?.Invoke(this, EventArgs.Empty);
//        }

//        public ICommand SaveCommand { get; private set; }
//        private void Save()
//        {
//            //try
//            //{
//                foreach (var textBox in textBoxListSkills)
//                {
//                    Skills.Add(textBox.Text);
//                }
//                foreach (var textBox in textBoxListQualities)
//                {
//                    Qualities.Add(textBox.Text);
//                }
//            //if (!string.IsNullOrEmpty(corporation._CorporationName) &&
//            //!string.IsNullOrEmpty(corporation._Post) &&
//            //!string.IsNullOrEmpty(corporation._Email) &&
//            //!string.IsNullOrEmpty(corporation._City) &&
//            //!string.IsNullOrEmpty(corporation._Description) &&
//            // corporation._Personal_qualities.Count!=0 &&
//            // corporation._Skills.Count != 0 &&
//            //!string.IsNullOrEmpty(corporation._Citizenship) &&
//            //!string.IsNullOrEmpty(corporation._Empoyment) &&
//            //!string.IsNullOrEmpty(corporation._Shedule) &&
//            //!string.IsNullOrEmpty(corporation._Status) &&
//            //!string.IsNullOrEmpty(corporation._Work_experience) &&
//            //!string.IsNullOrEmpty(corporation._Salary_min) &&
//            //!string.IsNullOrEmpty(corporation._Salary_max) &&
//            //!string.IsNullOrEmpty(corporation._Phone_number) &&
//            //!string.IsNullOrEmpty(corporation._Education) &&
//            //!string.IsNullOrEmpty(corporation._Age))
//            //{
//            //    _errorMessageVisibility = Visibility.Visible;
//            //    _errorMessageContent = "Все поля(кроме pdf) должны быть заполнены!";
//            //    OnPropertyChanged(nameof(ErrorMessageContent));
//            //    OnPropertyChanged(nameof(ErrorMessageVisibility));
//            //}
//            //else
//            //{
//                    corporation.AddData(_userId);
//                    OnSaveSuccessfulVacansy();
//                    //corporation.AddData(_userId);
//            //    }
//            //}
//            //catch (Exception ex)
//            //{
//            //    _errorMessageVisibility = Visibility.Visible;
//            //    _errorMessageContent = ex.Message;
//            //    OnPropertyChanged(nameof(ErrorMessageContent));
//            //    OnPropertyChanged(nameof(ErrorMessageVisibility));
//            //}
//        }

//        public string CorporationName
//        {
//            get { return corporation._CorporationName; }
//            set
//            {
//                if (corporation._CorporationName != value)
//                {
//                    corporation = new corporationClass(value, corporation._Post, corporation._Email, corporation._City, corporation._Description, corporation._Personal_qualities, corporation._Skills, corporation._Citizenship, corporation._Empoyment, corporation._Shedule, corporation._Status, corporation._Work_experience, corporation._Salary_min, corporation._Salary_max, corporation._Phone_number, corporation._Education, corporation._Age, corporation._PDF);
//                    OnPropertyChanged(nameof(CorporationName));
//                }
//            }
//        }

//        public string Post
//        {
//            get { return corporation._Post; }
//            set
//            {
//                if (corporation._Post != value)
//                {
//                    corporation = new corporationClass(corporation._CorporationName, value, corporation._Email, corporation._City, corporation._Description, corporation._Personal_qualities, corporation._Skills, corporation._Citizenship, corporation._Empoyment, corporation._Shedule, corporation._Status, corporation._Work_experience, corporation._Salary_min, corporation._Salary_max, corporation._Phone_number, corporation._Education, corporation._Age, corporation._PDF);
//                    OnPropertyChanged(nameof(Post));
//                }
//            }
//        }

//        public string Location
//        {
//            get { return corporation._City; }
//            set
//            {
//                if (corporation._City != value)
//                {
//                    corporation = new corporationClass(corporation._CorporationName, corporation._Post, corporation._Email, value, corporation._Description, corporation._Personal_qualities, corporation._Skills, corporation._Citizenship, corporation._Empoyment, corporation._Shedule, corporation._Status, corporation._Work_experience, corporation._Salary_min, corporation._Salary_max, corporation._Phone_number, corporation._Education, corporation._Age, corporation._PDF);
//                    OnPropertyChanged(nameof(Location));
//                }
//            }
//        }

//        public string Education
//        {
//            get { return corporation._Education; }
//            set
//            {
//                if (corporation._Education != value)
//                {
//                    corporation = new corporationClass(corporation._CorporationName, corporation._Post, corporation._Email, corporation._City, corporation._Description, corporation._Personal_qualities, corporation._Skills, corporation._Citizenship, corporation._Empoyment, corporation._Shedule, corporation._Status, corporation._Work_experience, corporation._Salary_min, corporation._Salary_max, corporation._Phone_number, value, corporation._Age, corporation._PDF);
//                    OnPropertyChanged(nameof(Education));
//                }
//            }
//        }

//        public string _salary_min;
//        public string SalaryMIn
//        {
//            get { return corporation._Salary_min; }
//            set
//            {
//                if (corporation._Salary_min != value)
//                {
//                    _salary_min = formatManager.FormatNumeric(value);
//                    corporation = new corporationClass(corporation._CorporationName, corporation._Post, corporation._Email, corporation._City, corporation._Description, corporation._Personal_qualities, corporation._Skills, corporation._Citizenship, corporation._Empoyment, corporation._Shedule, corporation._Status, corporation._Work_experience, _salary_min, corporation._Salary_max, corporation._Phone_number, corporation._Education, corporation._Age, corporation._PDF);
//                    OnPropertyChanged(nameof(SalaryMIn));
//                }
//            }
//        }

//        public string _salary_max;
//        public string SalaryMax
//        {
//            get { return corporation._Salary_max; }
//            set
//            {
//                if (corporation._Salary_max != value)
//                {
//                    _salary_max = formatManager.FormatNumeric(value);
//                    corporation = new corporationClass(corporation._CorporationName, corporation._Post, corporation._Email, corporation._City, corporation._Description, corporation._Personal_qualities, corporation._Skills, corporation._Citizenship, corporation._Empoyment, corporation._Shedule, corporation._Status, corporation._Work_experience, corporation._Salary_min, _salary_max, corporation._Phone_number, corporation._Education, corporation._Age, corporation._PDF);
//                    OnPropertyChanged(nameof(SalaryMax));
//                }
//            }
//        }

//        public string Email
//        {
//            get { return corporation._Email; }
//            set
//            {
//                if (corporation._Email != value)
//                {
//                    corporation = new corporationClass(corporation._CorporationName, corporation._Post, formatManager.RemoveSpaces(value), corporation._City, corporation._Description, corporation._Personal_qualities, corporation._Skills, corporation._Citizenship, corporation._Empoyment, corporation._Shedule, corporation._Status, corporation._Work_experience, corporation._Salary_min, corporation._Salary_max, corporation._Phone_number, corporation._Education, corporation._Age, corporation._PDF);
//                    OnPropertyChanged(nameof(Email));
//                }
//            }
//        }

//        public string Description
//        {
//            get { return corporation._Description; }
//            set
//            {
//                if (corporation._Description != value)
//                {
//                    corporation = new corporationClass(corporation._CorporationName, corporation._Post, corporation._Email, corporation._City, value, corporation._Personal_qualities, corporation._Skills, corporation._Citizenship, corporation._Empoyment, corporation._Shedule, corporation._Status, corporation._Work_experience, corporation._Salary_min, corporation._Salary_max, corporation._Phone_number, corporation._Education, corporation._Age, corporation._PDF);
//                    OnPropertyChanged(nameof(Description));
//                }
//            }
//        }

//        private string _age;
//        public string Age
//        {
//            get { return corporation._Age; }
//            set
//            {
//                if (corporation._Age != value)
//                {
//                    _age = formatManager.FormatNumeric(value);
//                    corporation = new corporationClass(corporation._CorporationName, corporation._Post, corporation._Email, corporation._City, corporation._Description, corporation._Personal_qualities, corporation._Skills, corporation._Citizenship, corporation._Empoyment, corporation._Shedule, corporation._Status, corporation._Work_experience, corporation._Salary_min, corporation._Salary_max, corporation._Phone_number, corporation._Education, _age, corporation._PDF);
//                    OnPropertyChanged(nameof(Age));
//                    UpdateDisplayTextAge();
//                }
//            }
//        }

//        private string _workExperience;
//        public string WorkExperience
//        {
//            get { return corporation._Work_experience; }
//            set
//            {
//                if (corporation._Work_experience != value)
//                {
//                    _workExperience = formatManager.FormatNumeric(value);
//                    corporation = new corporationClass(corporation._CorporationName, corporation._Post, corporation._Email, corporation._City, corporation._Description, corporation._Personal_qualities, corporation._Skills, corporation._Citizenship, corporation._Empoyment, corporation._Shedule, corporation._Status, _workExperience, corporation._Salary_min, corporation._Salary_max, corporation._Phone_number, corporation._Education, corporation._Age, corporation._PDF);
//                    OnPropertyChanged(nameof(WorkExperience));
//                    UpdateDisplayTextWE();
//                }
//            }
//        }

//        private string _selectedPDFFilePath = "PDF(необязательно)";
//        public string SelectedPDFFilePath
//        {
//            get { return _selectedPDFFilePath; }
//            set
//            {
//                if (_selectedPDFFilePath != value)
//                {
//                    _selectedPDFFilePath = value;
//                    OnPropertyChanged(nameof(SelectedPDFFilePath));
//                }
//            }
//        }

//        private ICommand _selectPDFCommand;
//        public ICommand SelectPDFCommand
//        {
//            get { return _selectPDFCommand; }
//            set
//            {
//                if (_selectPDFCommand != value)
//                {
//                    _selectPDFCommand = value;
//                    OnPropertyChanged(nameof(SelectPDFCommand));
//                }
//            }
//        }

//        public void SelectPDF()
//        {
//            try
//            {
//                pdfManager.SelectPDF();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Ошибка PDF!");
//            }
//        }

//        public string Base64String
//        {
//            get { return corporation._PDF; }
//            set
//            {
//                try
//                {
//                    if (corporation._PDF != value)
//                    {
//                        corporation = new corporationClass(corporation._CorporationName, corporation._Post, corporation._Email, corporation._City, corporation._Description, corporation._Personal_qualities, corporation._Skills, corporation._Citizenship, corporation._Empoyment, corporation._Shedule, corporation._Status, corporation._Work_experience, corporation._Salary_min, corporation._Salary_max, corporation._Phone_number, corporation._Education, corporation._Age, value);
//                        OnPropertyChanged(nameof(Base64String));
//                    }
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show($"Error loading pdf: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
//                }
//            }
//        }

//        private Dictionary<int, string> _Citizenship = new Dictionary<int, string>
//        {
//            {1,"Российская Федерация" },
//            {2,"Другое" }
//        };

//        public Dictionary<int, string> Citizenship
//        {
//            get { return _Citizenship; }
//        }

//        private Dictionary<int, string> _Shedule = new Dictionary<int, string>
//        {
//            {1,"Полный день" },
//            {2,"Сменный график" },
//            {3,"Гибкий график" },
//            {4,"Удаленная работа" },
//            {5,"Вахтовый метод" }
//        };

//        public Dictionary<int, string> Shedule
//        {
//            get { return _Shedule; }
//        }

//        Dictionary<int, string> _Empoyment = new Dictionary<int, string>
//        {
//            {1,"Полная" },
//            {2,"Частичная" },
//            {3,"Стажировка" }
//        };
//        public Dictionary<int, string> Empoyment
//        {
//            get { return _Empoyment; }
//        }

//        public string SelectedCitizenship
//        {
//            get { return corporation._Citizenship; }
//            set
//            {
//                if (corporation._Citizenship != value)
//                {
//                    corporation = new corporationClass(corporation._CorporationName, corporation._Post, corporation._Email, corporation._City, corporation._Description, corporation._Personal_qualities, corporation._Skills, value, corporation._Empoyment, corporation._Shedule, corporation._Status, corporation._Work_experience, corporation._Salary_min, corporation._Salary_max, corporation._Phone_number, corporation._Education, corporation._Age, corporation._PDF);
//                    OnPropertyChanged(nameof(SelectedCitizenship));
//                }
//            }
//        }

//        public string SelectedShedule
//        {
//            get { return corporation._Shedule; }
//            set
//            {
//                if (corporation._Shedule != value)
//                {
//                    corporation = new corporationClass(corporation._CorporationName, corporation._Post, corporation._Email, corporation._City, corporation._Description, corporation._Personal_qualities, corporation._Skills, corporation._Citizenship, corporation._Empoyment, value, corporation._Status, corporation._Work_experience, corporation._Salary_min, corporation._Salary_max, corporation._Phone_number, corporation._Education, corporation._Age, corporation._PDF);
//                    OnPropertyChanged(nameof(SelectedShedule));
//                }
//            }
//        }

//        public string SelectedEmpoyment
//        {
//            get { return corporation._Empoyment; }
//            set
//            {
//                if (corporation._Empoyment != value)
//                {
//                    corporation = new corporationClass(corporation._CorporationName, corporation._Post, corporation._Email, corporation._City, corporation._Description, corporation._Personal_qualities, corporation._Skills, corporation._Citizenship, value, corporation._Shedule, corporation._Status, corporation._Work_experience, corporation._Salary_min, corporation._Salary_max, corporation._Phone_number, corporation._Education, corporation._Age, corporation._PDF);
//                    OnPropertyChanged(nameof(SelectedEmpoyment));
//                }
//            }
//        }

//        public string _phoneNumber;
//        public string PhoneNumber
//        {
//            get { return corporation._Phone_number; }
//            set
//            {
//                if (corporation._Phone_number != value)
//                {
//                    _phoneNumber = formatManager.FormatPhoneNumber(value);
//                    corporation = new corporationClass(corporation._CorporationName, corporation._Post, corporation._Email, corporation._City, corporation._Description, corporation._Personal_qualities, corporation._Skills, corporation._Citizenship, corporation._Empoyment, corporation._Shedule, corporation._Status, corporation._Work_experience, corporation._Salary_min, corporation._Salary_max, _phoneNumber, corporation._Education, corporation._Age, corporation._PDF);
//                    OnPropertyChanged(nameof(PhoneNumber));
//                }
//            }
//        }

//        private string _yearTextAge = "лет";
//        public string YearTextAge
//        {
//            get { return _yearTextAge; }
//            set
//            {
//                if (_yearTextAge != value)
//                {
//                    _yearTextAge = value;
//                    OnPropertyChanged(nameof(YearTextAge));
//                }
//            }
//        }

//        private string _yearTextWE = "лет";
//        public string YearTextWE
//        {
//            get { return _yearTextWE; }
//            set
//            {
//                if (_yearTextWE != value)
//                {
//                    _yearTextWE = value;
//                    OnPropertyChanged(nameof(YearTextWE));
//                }
//            }
//        }

//        private void UpdateDisplayTextWE()
//        {
//            if (int.TryParse(_workExperience, out int age))
//            {
//                int lastDigit = age % 10;
//                int lastTwoDigits = age % 100;

//                if (lastDigit == 1 && lastTwoDigits != 11)
//                    YearTextWE = "года";
//                else if (lastDigit >= 2 && lastDigit <= 4 && (lastTwoDigits < 10 || lastTwoDigits >= 20))
//                    YearTextWE = "лет";
//                else
//                    YearTextWE = "лет";
//            }
//            else
//            {
//            }
//        }

//        private void UpdateDisplayTextAge()
//        {
//            if (int.TryParse(_age, out int age))
//            {
//                int lastDigit = age % 10;
//                int lastTwoDigits = age % 100;

//                if (lastDigit == 1 && lastTwoDigits != 11)
//                    YearTextAge = "года";
//                else if (lastDigit >= 2 && lastDigit <= 4 && (lastTwoDigits < 10 || lastTwoDigits >= 20))
//                    YearTextAge = "лет";
//                else
//                    YearTextAge = "лет";
//            }
//            else
//            {
//            }
//        }
//    }
//}
