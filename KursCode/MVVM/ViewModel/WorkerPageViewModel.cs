using Clients;
using KursCode.Data;
using KursCode.MVVM.View.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.IO.IsolatedStorage;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.IO;
using System.Windows.Media;

namespace KursCode.MVVM.ViewModel
{
    public class WorkersPageViewModel : baseViewModel
    {

        //private List<workerClass> workerDataList = new List<workerClass>();
        //private ObservableCollection<ClientsUserControlMini> _miniWorkers;
        //private DatabaseHelper _dbHelper;

        //public WorkersPageViewModel()
        //{
        //    _dbHelper = new DatabaseHelper(GetWorkerDBPath(_userId));
        //    _clientsUserControlMax = new ClientsUserControlMax(_userId);
        //    LoadDataFromJson();
        //}

        //private int _userId;
        //public int UserId
        //{
        //    get { return _userId; }
        //    set
        //    {
        //        if (_userId != value)
        //        {
        //            _userId = value;
        //            OnPropertyChanged(nameof(UserId));
        //        }
        //    }
        //}

        //private Visibility _borderVisibility;
        //public Visibility BorderVisibility
        //{
        //    get { return _borderVisibility; }
        //    set
        //    {
        //        if (_borderVisibility != value)
        //        {
        //            _borderVisibility = value;
        //            OnPropertyChanged(nameof(BorderVisibility));
        //        }
        //    }
        //}

        //public ObservableCollection<ClientsUserControlMini> MiniWorkers
        //{
        //    get { return _miniWorkers; }
        //    set
        //    {
        //        _miniWorkers = value;
        //        OnPropertyChanged(nameof(MiniWorkers));
        //    }
        //}

        //private static string GetWorkerDBPath(int userId)
        //{
        //    string executablePath = AppDomain.CurrentDomain.BaseDirectory;
        //    string parentPath = Directory.GetParent(executablePath).FullName;
        //    string dataFolderPath = Path.Combine(parentPath, "Data");
        //    string userFolderPath = Path.Combine(dataFolderPath, "UserData");
        //    string workerDbPath = Path.Combine(userFolderPath, $"{userId}_ID_User");
        //    Directory.CreateDirectory(workerDbPath);
        //    return workerDbPath;
        //}

        //public void LoadDataFromJson()
        //{
        //    string workerFolderPath = GetWorkerDBPath(_userId);
        //    string workerDataFilePath = Path.Combine(workerFolderPath, "worker.json");
        //    var dataList = _dbHelper.GetAllEntities<workerClass>(workerDataFilePath);

        //    MiniWorkers = new ObservableCollection<ClientsUserControlMini>();
        //    var userControlMax = new ClientsUserControlMax(_userId);

        //    foreach (var data in dataList)
        //    {
        //        var userControlMini = new ClientsUserControlMini();
        //        userControlMini.SetData(data);

        //        userControlMini.VerticalAlignment = VerticalAlignment.Top;
        //        Thickness margin = new Thickness(10, 0, 10, 15);
        //        userControlMini.Margin = margin;

        //        userControlMini.MiniControlClicked += (sender, e) =>
        //        {
        //            userControlMax.UserId = _userId;

        //        };
        //        userControlMini.MouseEnter += DynamicUserControl_MouseEnter;
        //        userControlMini.MouseLeave += DynamicUserControl_MouseLeave;
        //        userControlMini.MouseDown += DynamicUserControl_MouseDown;
                
        //        workerDataList.Add(data);
        //        MiniWorkers.Add(userControlMini);
        //    }
        //}

        //private ClientsUserControlMini _selectedMiniWorker;
        //public ClientsUserControlMini SelectedMiniWorker
        //{
        //    get { return _selectedMiniWorker; }
        //    set
        //    {
        //        _selectedMiniWorker = value;
        //        _clientsUserControlMax.UserId = UserId;
        //        OnPropertyChanged(nameof(SelectedMiniWorker));
        //    }
        //}

        //private ClientsUserControlMax _clientsUserControlMax;
        //public ClientsUserControlMax _ClientsUserControlMax
        //{
        //    get { return _clientsUserControlMax; }
        //    set
        //    {
        //        if (_clientsUserControlMax != value)
        //        {
        //            _clientsUserControlMax = value;
        //            _clientsUserControlMax.UserId = UserId;
        //            OnPropertyChanged(nameof(ClientsUserControlMax));
        //        }
        //    }
        //}

        //private void DynamicUserControl_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    var clickedControl = (ClientsUserControlMini)sender;

        //    if (_selectedMiniWorker != null && _selectedMiniWorker != clickedControl)
        //    {
        //        _selectedMiniWorker.mainBorder.BorderBrush = Brushes.Black;
        //    }

        //    _selectedMiniWorker = clickedControl;
        //    _selectedMiniWorker.mainBorder.BorderBrush = Brushes.Blue;


        //    _clientsUserControlMax.ClearData();

        //    var matchingWorkerData = workerDataList.FirstOrDefault(data =>
        //    data._Surname == _selectedMiniWorker.Surname.Text &&
        //    data._WorkerName == _selectedMiniWorker.Name.Text &&
        //    data._Post == _selectedMiniWorker.Post.Text);

        //    _clientsUserControlMax.SetData(matchingWorkerData);

        //    _selectedMiniWorker.OnMiniControlClicked();
        //}

        //private void DynamicUserControl_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    ((ClientsUserControlMini)sender).SetDarkBackground();
        //}

        //private void DynamicUserControl_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    ((ClientsUserControlMini)sender).RestoreBackground();
        //}

        //public event PropertyChangedEventHandler PropertyChanged;

        //public void OnPropertyChanged([CallerMemberName] string prop = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        //}
        
        //public void UpdateMiniWorkers()
        //{
        //    LoadDataFromJson();
        //    OnPropertyChanged(nameof(MiniWorkers));
        //}
    }
}
