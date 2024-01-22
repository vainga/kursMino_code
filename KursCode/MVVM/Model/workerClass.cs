using KursCode;
using Microsoft.Data.Sqlite;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using KursCode.Data;
using System.Windows.Controls;
using KursCode.MVVM.Model;
using KursCode.Interfaces;
using System.Collections.ObjectModel;

namespace Clients
{
    [Serializable]
    public class workerClass : IWorker
    {
        [JsonInclude]
        [JsonPropertyName("WorkerId")]
        private int _workerId;
        public int WorkerId
        {
            get { return _workerId; }
            set { _workerId = value; }
        }

        [JsonInclude]
        [JsonPropertyName("UserId")]
        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        [JsonInclude]
        [JsonPropertyName("_Status")]
        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Post")]
        private string _post;
        public string Post
        {
            get { return _post; }
            set { _post = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Email")]
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        [JsonInclude]
        [JsonPropertyName("City")]
        private string _city;
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Description")]
        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Personal_qualities")]
        private ObservableCollection<string> _personal_qualities;
        public ObservableCollection<string> Personal_qualities
        {
            get { return _personal_qualities; }
            set { _personal_qualities = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Skills")]
        private ObservableCollection<string> _skills;
        public ObservableCollection<string> Skills
        {
            get { return _skills; }
            set { _skills = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Citizenship")]
        private string _citizenship;
        public string Citizenship
        {
            get { return _citizenship; }
            set { _citizenship = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Shedule")]
        private string _shedule;
        public string Shedule
        {
            get { return _shedule; }
            set { _shedule = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Empoyment")]
        private string _employment;
        public string Empoyment
        {
            get { return _employment; }
            set { _employment = value; }
        }

        [JsonInclude]
        [JsonPropertyName("_WorkerName")]
        private string _workerName;
        public string WorkerName
        {
            get { return _workerName; }
            set { _workerName = value; }
        }

        [JsonInclude]
        [JsonPropertyName("_Surname")]
        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }
        
        [JsonInclude]
        [JsonPropertyName("_Work_experience")]
        private int _work_experience;
        public int Work_experience
        {
            get { return _work_experience; }
            set {
                if (_work_experience >= 0)
                    _work_experience = value;
                throw new ArgumentException("work_experience cannot be less than zero");
            }
        }

        [JsonInclude]
        [JsonPropertyName("_Salary_need")]
        private int _salary_need;
        public int Salary_need
        {
            get { return _salary_need; }
            set {
                if (_salary_need >= 0)
                    _salary_need = value;
                throw new ArgumentException("salary_need cannot be less than zero");
            }
        }

        [JsonInclude]
        [JsonPropertyName("_PDF")]
        private string[] _pdf;
        public string[] PdfFiles
        {
            get { return _pdf; }
            set { _pdf = value; }
        }

        [JsonInclude]
        [JsonPropertyName("_Photo")]
        private string _workerPhoto;
        public string WorkerPhoto
        {
            get { return _workerPhoto; }
            set { _workerPhoto = value; }
        }

        [JsonInclude]
        [JsonPropertyName("PhoneNumber")]
        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Education")]
        private string _education;
        public string Education
        {
            get { return _education; }
            set { _education = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Age")]
        private int _age;
        public int Age
        {
            get { return _age; }
            set {
                if (_age >= 0)
                        _age = value;
                throw new ArgumentException("age cannot be less than zero");
            }
        }

        [JsonInclude]
        [JsonPropertyName("_Sex")]
        private string _sex;
        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }



    }
}