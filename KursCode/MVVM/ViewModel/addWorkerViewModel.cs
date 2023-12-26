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

                userInputValues = new ObservableCollection<string>();
                textBoxList = new ObservableCollection<TextBox>();
                SaveCommand = new RelayCommand(Save);
            }

            private BitmapImage _workerPhoto;
            private Visibility _selectedImageVisibility;
            private Visibility _photoIconVisibility;

            private ObservableCollection<string> userInputValues;
            public ObservableCollection<string> UserInputValues
            {
                get { return userInputValues; }
                set
                {
                    if (userInputValues != value)
                    {
                        userInputValues = value;
                        OnPropertyChanged(nameof(UserInputValues));
                    }
                }
            }

            private ObservableCollection<TextBox> textBoxList;
            public ObservableCollection<TextBox> TextBoxList
            {
                get { return textBoxList; }
                set
                {
                    if (textBoxList != value)
                    {
                        textBoxList = value;
                        OnPropertyChanged(nameof(TextBoxList));
                    }
                }
            }

            public ICommand SaveCommand { get; private set; }
            private void Save()
            {
                UserInputValues.Clear();
                foreach (var textBox in textBoxList)
                {
                    UserInputValues.Add(textBox.Text);
                }
            }

            private string _workerName;
            public string WorkerName
            {
                get { return _workerName; }
                set
                {
                    if (_workerName != value)
                    {
                        _workerName = value;
                        OnPropertyChanged(nameof(WorkerName));
                    }
                }
            }

            private string _workerSurname;
            public string WorkerSurname
            {
                get { return _workerSurname; }
                set
                {
                    if (_workerSurname != value)
                    {
                        _workerSurname = value;
                        OnPropertyChanged(nameof(WorkerSurname));
                    }
                }
            }

            private string _post;
            public string Post
            {
                get { return _post; }
                set
                {
                    if (_post != value)
                    {
                        _post = value;
                        OnPropertyChanged(nameof(Post));
                    }
                }
            }

            private string _location;
            public string Location
            {
                get { return _location; }
                set
                {
                    if (_location != value)
                    {
                        _location = value;
                        OnPropertyChanged(nameof(Location));
                    }
                }
            }

            private string _edaucation;
            public string Education
            {
                get { return _edaucation; }
                set
                {
                    if (_edaucation != value)
                    {
                        _edaucation = value;
                        OnPropertyChanged(nameof(Education));
                    }
                }
            }

            private string _salary;
            public string Salary
            {
                get { return _salary; }
                set
                {
                    if (_salary != value)
                    {
                        _salary = FormatNumeric(value);
                        OnPropertyChanged(nameof(Salary));
                    }
                }
            }

            private string _email;
            public string Email
            {
                get { return _email; }
                set
                {
                    if (_email != value)
                    {
                        _email = value;
                        OnPropertyChanged(nameof(Email));
                    }
                }
            }

            private string _description;
            public string Description
            {
                get { return _description; }
                set
                {
                    if (_description != value)
                    {
                        _description = value;
                        OnPropertyChanged(nameof(Description));
                    }
                }
            }

            private string _age;
            public string Age
            {
                get { return _age; }
                set
                {
                    if (_age != value)
                    {
                        _age = FormatNumeric(value);
                        OnPropertyChanged(nameof(Age));
                        UpdateDisplayTextAge();
                    }
                }
            }

            private string _workExperience;
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
