using KursCode.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.IO;
using KursCode.Data;
using Clients;
using KursCode.Interfaces;

namespace KursCode.MVVM.ViewModel
{
    public class interviewPageViewModel : baseViewModel
    {
        //    public interviewPageViewModel()
        //    {
        //        Interview = new InterviewClass();
        //        LoadAllInterviewsCommand = new RelayCommand(LoadAllInterviews);
        //        LoadAllInterviews();
        //    }

        //private ObservableCollection<InterviewClass> _interviewList;
        //    public ObservableCollection<InterviewClass> InterviewList
        //    {
        //        get { return _interviewList; }
        //        set
        //        {
        //            _interviewList = value;
        //            OnPropertyChanged(nameof(InterviewList));
        //        }
        //    }

        //    public ICommand LoadAllInterviewsCommand { get; }

        //    public string GetDBPath(int userid)
        //    {
        //        string executablePath = AppDomain.CurrentDomain.BaseDirectory;
        //        string parentPath = Directory.GetParent(executablePath).FullName;
        //        string dataFolderPath = Path.Combine(parentPath, "Data");
        //        string userFolderPath = Path.Combine(dataFolderPath, "UserData");
        //        string userSpecificFolderPath = Path.Combine(userFolderPath, $"{userid}_ID_User");
        //        Directory.CreateDirectory(userSpecificFolderPath);
        //        string corporationDataFilePath = Path.Combine(userSpecificFolderPath, "interviews.json");
        //        return corporationDataFilePath;
        //    }

        //    public DateTime Date
        //    {
        //        get { return _interview.Date; }
        //        set
        //        {
        //            if (_interview.Date != value)
        //            {
        //                Interview = new InterviewClass(value, _interview.Time, _interview.Duration, _interview.Worker, _interview.Vacancy);
        //                OnPropertyChanged(nameof(Date));
        //            }
        //        }
        //    }

        //    public TimeSpan Time
        //    {
        //        get
        //        {
        //            return _interview.Time;
        //        }
        //        set
        //        {
        //            if (_interview.Time != value)
        //            {
        //                Interview = new InterviewClass(_interview.Date, value, _interview.Duration, _interview.Worker, _interview.Vacancy);
        //                OnPropertyChanged(nameof(Time));
        //            }
        //        }
        //    }

        //    public TimeSpan Duration
        //    {
        //        get
        //        {
        //            return _interview.Duration;
        //        }
        //        set
        //        {
        //            if (_interview.Duration != value)
        //            {
        //                Interview = new InterviewClass(_interview.Date, _interview.Time, value, _interview.Worker, _interview.Vacancy);
        //                OnPropertyChanged(nameof(Duration));
        //            }
        //        }
        //    }
        //    public workerClass Worker
        //    {
        //        get
        //        {
        //            return _interview.Worker;
        //        }

        //        set
        //        {
        //            if (_interview.Worker != value)
        //            {
        //                Interview = new InterviewClass(_interview.Date, _interview.Time, _interview.Duration, value, _interview.Vacancy);
        //                OnPropertyChanged(nameof(Worker));
        //            }
        //        }
        //    }
        //    public corporationClass Vacancy
        //    {
        //        get { return _interview.Vacancy; }

        //        set
        //        {
        //            if (_interview.Vacancy != value)
        //            {
        //                Interview = new InterviewClass(_interview.Date, _interview.Time, _interview.Duration, _interview.Worker, value);
        //                OnPropertyChanged(nameof(Worker));
        //            }
        //        }
        //    }
        //    private static int _userId;
        //    public int UserId
        //    {
        //        get { return _userId; }
        //        set
        //        {
        //            if (_userId != value)
        //            {
        //                _userId = value;
        //                OnPropertyChanged(nameof(UserId));
        //            }
        //        }
        //    }

        //    private Iinterview _interview;
        //    public Iinterview Interview
        //    {
        //        get { return _interview; }
        //        set
        //        {
        //            if (_interview != value)
        //            {
        //                _interview = value;
        //                OnPropertyChanged(nameof(Interview));
        //            }
        //        }
        //    }

        //    private void LoadAllInterviews()
        //    {
        //        try
        //        {
        //            int userId = UserId;
        //            string dbPath = GetDBPath(userId);
        //            DatabaseHelper dbHelper = new DatabaseHelper(dbPath);

        //            if (File.Exists(dbPath))
        //            {
        //                List<InterviewClass> allInterviews = dbHelper.GetAllEntities<InterviewClass>(dbPath);

        //                InterviewList = new ObservableCollection<InterviewClass>(allInterviews);
        //            }
        //            else
        //            {
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //        }
        //    }
    }
}
