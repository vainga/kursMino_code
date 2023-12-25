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

namespace KursCode.MVVM.ViewModel
{
    public class addWorkerViewModel : INotifyPropertyChanged
    {
        public addWorkerViewModel()
        {
            UserControlViewModels = new ObservableCollection<ClientSkillViewModel>();
            SelectPDFCommand = new RelayCommand(SelectPDF);
            OnPropertyChanged(nameof(SelectedPDFFilePath));
        }

        private BitmapImage _workerPhoto;
        private Visibility _selectedImageVisibility;
        private Visibility _photoIconVisibility;
        public ObservableCollection<ClientSkillViewModel> UserControlViewModels { get; set; }

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
                    Education = value;
                    OnPropertyChanged(nameof(Education));
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
                    Age = value;
                    OnPropertyChanged(nameof(Age));
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
                    WorkExperience = value;
                    OnPropertyChanged(nameof(WorkExperience));
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
