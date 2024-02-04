using Clients;
using KursCode.Data;
using KursCode.Interfaces;
using KursCode.MVVM.Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KursCode.MVVM.ViewModel
{
    public class interviewWindowViewModel : baseViewModel
    {
        //private Iinterview _interview;
        //public Iinterview Interview
        //{
        //    get { return _interview; }
        //    set
        //    {
        //        if (_interview != value)
        //        {
        //            _interview = value;
        //            OnPropertyChanged(nameof(Interview));
        //        }
        //    }
        //}



        //public interviewWindowViewModel()
        //{
        //    Interview = new InterviewClass();
        //    CorporationNamesAndPositions = new ObservableCollection<string>();
        //    LoadCorporationListCommand = new RelayCommand(LoadCorporationList);
        //    commandSave = new RelayCommand(Save);
        //    LoadCorporationList();
        //}

        //public DateTime Date 
        //{ get { return _interview.Date; }
        //    set {
        //        if(_interview.Date != value)
        //        {
        //            Interview = new InterviewClass(value,_interview.Time,_interview.Duration,_interview.Worker,_interview.Vacancy) ;
        //            OnPropertyChanged(nameof(Date));
        //        }
        //    } 
        //}

        //public TimeSpan Time {
        //    get
        //    {
        //        return _interview.Time;
        //    } 
        //    set
        //    {
        //        if(_interview.Time != value)
        //        {
        //            Interview = new InterviewClass(_interview.Date, value, _interview.Duration, _interview.Worker, _interview.Vacancy);
        //            OnPropertyChanged(nameof(Time));
        //        }
        //    }
        //}

        //public TimeSpan Duration 
        //{ get 
        //    {
        //        return _interview.Duration;
        //    }
        //  set {
        //        if( _interview.Duration != value)
        //        {
        //            Interview = new InterviewClass(_interview.Date, _interview.Time, value, _interview.Worker, _interview.Vacancy);
        //            OnPropertyChanged(nameof(Duration));
        //        }
        //    } 
        //}

        //private static workerClass _worker;
        //public workerClass Worker
        //{
        //    get { return _worker; }
        //    set
        //    {
        //        if (_worker != value)
        //        {
        //            _worker = value;
        //            OnPropertyChanged(nameof(Worker));
        //        }
        //    }
        //}

        //public corporationClass Vacancy
        //{
        //    get { return _interview.Vacancy; }

        //    set {
        //        if (_interview.Vacancy != value)
        //        {
        //            Interview = new InterviewClass(_interview.Date, _interview.Time, _interview.Duration, _interview.Worker, value);
        //            OnPropertyChanged(nameof(Vacancy));
        //        }
        //    }
        //}

        //private static int _userId;
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

        //private static string GetCorporationDBPath(int userid)
        //{
        //    string executablePath = AppDomain.CurrentDomain.BaseDirectory;
        //    string parentPath = Directory.GetParent(executablePath).FullName;
        //    string dataFolderPath = Path.Combine(parentPath, "Data");
        //    string userFolderPath = Path.Combine(dataFolderPath, "UserData");
        //    string userSpecificFolderPath = Path.Combine(userFolderPath, $"{userid}_ID_User");
        //    Directory.CreateDirectory(userSpecificFolderPath);
        //    return userSpecificFolderPath;
        //}

        //private string _selectedCorporation;

        //public string SelectedCorporation
        //{
        //    get { return _selectedCorporation; }
        //    set
        //    {
        //        _selectedCorporation = value;
        //        OnPropertyChanged(nameof(SelectedCorporation));
        //        Vacancy = CorporationList.FirstOrDefault(c => $"{c._CorporationName} - {c._Post}" == value);
        //    }
        //}


        //private ObservableCollection<corporationClass> _corporationList;
        //public ObservableCollection<corporationClass> CorporationList
        //{
        //    get { return _corporationList; }
        //    set
        //    {
        //        _corporationList = value;
        //        OnPropertyChanged(nameof(CorporationList));
        //    }
        //}

        //public ObservableCollection<string> CorporationNamesAndPositions { get; set; }
        //public ICommand LoadCorporationListCommand { get; }
        //private void LoadCorporationList()
        //{
        //    int userId = UserId;
        //    string corporationFolderPath = GetCorporationDBPath(userId);
        //    string corporationDataFilePath = Path.Combine(corporationFolderPath, "corporation.json");
        //    DatabaseHelper dbHelper = new DatabaseHelper(corporationDataFilePath);

        //    List<corporationClass> jsonObjects = dbHelper.GetAllEntities<corporationClass>(corporationDataFilePath);
        //    CorporationList = new ObservableCollection<corporationClass>(jsonObjects);

        //    CorporationNamesAndPositions.Clear();
        //    foreach (var corporation in CorporationList)
        //    {
        //        string nameAndPosition = $"{corporation._CorporationName} - {corporation._Post}";
        //        CorporationNamesAndPositions.Add(nameAndPosition);
        //    }
        //    OnPropertyChanged(nameof(CorporationNamesAndPositions));
        //}

        //public event EventHandler SaveSuccessful;
        //protected virtual void OnSaveSuccessful()
        //{
        //    SaveSuccessful?.Invoke(this, EventArgs.Empty);
        //}

        //public ICommand commandSave{ get; set; }
        //private void Save()
        //{
        //    try
        //    {
        //        Interview = new InterviewClass(Date, Time, Duration, _worker, Vacancy);
        //        Interview.AddData(UserId);
        //        OnSaveSuccessful();
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}
