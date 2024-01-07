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
        private int _workerId;
        public int WorkerId
        {
            get { return _workerId; }
            set { _workerId = value; }
        }

        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private string status;
        public string _Status
        {
            get { return status; }
            set { status = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Post")]
        private string post;
        public string _Post
        {
            get { return post; }
            set {  post = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Email")]
        private string email;
        public string _Email
        {
            get { return email; }
            set { email = value; }
        }

        [JsonInclude]
        [JsonPropertyName("City")]
        private string city;
        public string _City
        {
            get { return city; }
            set { city = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Description")]
        private string description;
        public string _Description
        {
            get { return description;}
            set { description = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Personal_qualities")]
        private ObservableCollection<string> personal_qualities;
        public ObservableCollection<string> _Personal_qualities
        {
            get { return personal_qualities; }
            set {  personal_qualities = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Skills")]
        private ObservableCollection<string> skills;
        public ObservableCollection<string> _Skills
        {
            get { return skills; }
            set { skills = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Citizenship")]
        private string citizenship;
        public string _Citizenship
        {
            get { return  citizenship; }
            set { citizenship = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Shedule")]
        private string shedule;
        public string _Shedule
        {
            get { return shedule; }
            set { shedule = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Empoyment")]
        private string employment;
        public string _Empoyment
        {
            get { return employment; }
            set { employment = value; }
        }

        [JsonInclude]
        [JsonPropertyName("_WorkerName")]
        private string workerName;
        public string _WorkerName
        {
            get { return workerName; }
            set { workerName = value; }
        }

        [JsonInclude]
        [JsonPropertyName("_Surname")]
        private string surname;
        public string _Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        
        [JsonInclude]
        [JsonPropertyName("_Work_experience")]
        private string work_experience;
        public string _Work_experience
        {
            get { return work_experience; }
            set { work_experience = value; }
        }

        [JsonInclude]
        [JsonPropertyName("_Salary_need")]
        private string salary_need;
        public string _Salary_need
        {
            get { return salary_need; }
            set { salary_need = value; }
        }

        [JsonInclude]
        [JsonPropertyName("_PDF")]
        private string[] pdf;
        public string[] _PdfFiles
        {
            get { return pdf; }
            set { pdf = value; }
        }

        [JsonInclude]
        [JsonPropertyName("_Photo")]
        private string workerPhoto;
        public string _WorkerPhoto
        {
            get { return workerPhoto; }
            set { workerPhoto = value; }
        }

        [JsonInclude]
        [JsonPropertyName("PhoneNumber")]
        private string phoneNumber;
        public string _PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Education")]
        private string education;
        public string _Education
        {
            get { return education; }
            set { education = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Age")]
        private string age;
        public string _Age
        {
            get { return age; }
            set { age = value; }
        }

        [JsonInclude]
        [JsonPropertyName("_Sex")]
        private string sex;
        public string _sex
        {
            get { return sex; }
            set { sex = value; }
        }



    }
}