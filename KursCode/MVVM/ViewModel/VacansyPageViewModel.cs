using Clients;
using KursCode.Data;
using KursCode.MVVM.View.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
namespace KursCode.MVVM.ViewModel
{
    public class VacansyPageViewModel : baseViewModel
    {
        private List<corporationClass> corporationsList = new List<corporationClass>();
        private ObservableCollection<ClientsUserControlMini> _miniWorkers;
        private DatabaseHelper _dbHelper;

        public VacansyPageViewModel()
        {
            _dbHelper = new DatabaseHelper(GetCorporationDBPath(_userId));
            _clientsUserControlMax = new ClientsUserControlMax();
            LoadDataFromJson();
        }

        private static int _userId;
        public int UserId
        {
            get { return _userId; }
            set
            {
                if (_userId != value)
                {
                    _userId = value;
                    OnPropertyChanged(nameof(UserId));
                }
            }

        }

        private Visibility _borderVisibility;
        public Visibility BorderVisibility
        {
            get { return _borderVisibility; }
            set
            {
                if (_borderVisibility != value)
                {
                    _borderVisibility = value;
                    OnPropertyChanged(nameof(BorderVisibility));
                }
            }
        }

        public ObservableCollection<ClientsUserControlMini> MiniWorkers
        {
            get { return _miniWorkers; }
            set
            {
                _miniWorkers = value;
                OnPropertyChanged(nameof(MiniWorkers));
            }
        }

        private static string GetCorporationDBPath(int userid)
        {
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string parentPath = Directory.GetParent(executablePath).FullName;
            string dataFolderPath = Path.Combine(parentPath, "Data");
            string userFolderPath = Path.Combine(dataFolderPath, "UserData");
            string userSpecificFolderPath = Path.Combine(userFolderPath, $"{userid}_ID_User");
            return userSpecificFolderPath;
        }

        public void LoadDataFromJson()
        {
            string corpFolderPath = GetCorporationDBPath(_userId);
            string corpDataFilePath = Path.Combine(corpFolderPath, "corporation.json");
            var dataList = _dbHelper.GetAllEntities<corporationClass>(corpDataFilePath);

            MiniWorkers = new ObservableCollection<ClientsUserControlMini>();

            foreach (var data in dataList)
            {
                var userControlMini = new ClientsUserControlMini();
                userControlMini.SetData(data);

                userControlMini.VerticalAlignment = VerticalAlignment.Top;
                Thickness margin = new Thickness(10, 0, 10, 15);
                userControlMini.Margin = margin;

                userControlMini.MouseEnter += DynamicUserControl_MouseEnter;
                userControlMini.MouseLeave += DynamicUserControl_MouseLeave;
                userControlMini.MouseDown += DynamicUserControl_MouseDown;

                corporationsList.Add(data);
                MiniWorkers.Add(userControlMini);
            }
        }

        private ClientsUserControlMini _selectedMiniWorker;
        public ClientsUserControlMini SelectedMiniWorker
        {
            get { return _selectedMiniWorker; }
            set
            {
                _selectedMiniWorker = value;
                OnPropertyChanged(nameof(SelectedMiniWorker));
            }
        }

        private ClientsUserControlMax _clientsUserControlMax; // Direct reference to ClientsUserControlMax

        public ClientsUserControlMax _ClientsUserControlMax
        {
            get { return _clientsUserControlMax; }
            set
            {
                if (_clientsUserControlMax != value)
                {
                    _clientsUserControlMax = value;
                    OnPropertyChanged(nameof(ClientsUserControlMax));
                }
            }
        }

        private void DynamicUserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var clickedControl = (ClientsUserControlMini)sender;

            if (_selectedMiniWorker != null && _selectedMiniWorker != clickedControl)
            {
                _selectedMiniWorker.mainBorder.BorderBrush = Brushes.Black;
            }

            _selectedMiniWorker = clickedControl;
            _selectedMiniWorker.mainBorder.BorderBrush = Brushes.Blue;


            _clientsUserControlMax.ClearData();

            var matchingWorkerData = corporationsList.FirstOrDefault(data =>
            data._CorporationName == _selectedMiniWorker.Surname.Text && data._Post == _selectedMiniWorker.Post.Text);

            _clientsUserControlMax.SetData(matchingWorkerData);
        }

        private void DynamicUserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            ((ClientsUserControlMini)sender).SetDarkBackground();
        }

        private void DynamicUserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            ((ClientsUserControlMini)sender).RestoreBackground();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void UpdateMiniWorkers()
        {
            LoadDataFromJson();
            OnPropertyChanged(nameof(MiniWorkers));
        }
    }
}
