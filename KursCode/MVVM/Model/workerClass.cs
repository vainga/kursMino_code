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
    public class workerClass
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

        [JsonInclude]
        [JsonPropertyName("Post")]
        public string _Post { get; private set; }

        [JsonInclude]
        [JsonPropertyName("Email")]
        public string _Email { get; private set; }

        [JsonInclude]
        [JsonPropertyName("City")]
        public string _City { get; private set; }

        [JsonInclude]
        [JsonPropertyName("Description")]
        public string _Description { get; private set; }

        [JsonInclude]
        [JsonPropertyName("Personal_qualities")]
        public ObservableCollection<string> _Personal_qualities { get; private set; }

        [JsonInclude]
        [JsonPropertyName("Skills")]
        public ObservableCollection<string> _Skills { get; private set; }

        [JsonInclude]
        [JsonPropertyName("Status")]
        public string _Status { get; private set; }

        [JsonInclude]
        [JsonPropertyName("Sitizenship")]
        public string _Citizenship { get; private set; }

        [JsonInclude]
        [JsonPropertyName("Shedule")]
        public string _Shedule { get; private set; }

        [JsonInclude]
        [JsonPropertyName("Empoyment")]
        public string _Empoyment { get; private set; }

        [JsonInclude]
        [JsonPropertyName("_WorkerName")]
        public string _WorkerName { get; private set; }
        
        [JsonInclude]
        [JsonPropertyName("_Surname")]
        public string _Surname { get; private set; }
        
        [JsonInclude]
        [JsonPropertyName("_Work_experience")]
        public string _Work_experience { get;  private set; }
        
        [JsonInclude]
        [JsonPropertyName("_Salary_need")]
        public string _Salary_need { get;  private set; }

        [JsonInclude]
        [JsonPropertyName("_PDF")]
        public string _PdfFile { get; set; }
        
        [JsonInclude]
        [JsonPropertyName("_Photo")]
        public string _WorkerPhoto { get; set; }

        [JsonInclude]
        [JsonPropertyName("PhoneNumber")]
        public string _PhoneNumber { get; set; }

        [JsonInclude]
        [JsonPropertyName("Education")]
        public string _Education { get; set; }

        [JsonInclude]
        [JsonPropertyName("Age")]
        public string _Age { get; set; }

        [JsonInclude]
        [JsonPropertyName("_Sex")]
        public string _sex { get; private set; }



    }
}