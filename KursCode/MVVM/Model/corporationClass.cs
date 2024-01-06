using KursCode;
using Microsoft.Data.Sqlite;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using System.IO;
using KursCode.Data;
using KursCode.MVVM.Model;
using System.Collections.ObjectModel;

namespace Clients
{
    [Serializable]
    public class corporationClass
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
        [JsonPropertyName("_CorporationName")]
        public string _CorporationName { get; private set; }
        [JsonInclude]
        [JsonPropertyName("_Work_experience_min")]
        public string _Work_experience { get; private set; }
        
        [JsonInclude]
        [JsonPropertyName("_Salary_min")]
        public string _Salary_min { get; private set; }

        [JsonInclude]
        [JsonPropertyName("_Salary_max")]
        public string _Salary_max { get; private set; }

        [JsonInclude]
        [JsonPropertyName("_Phone_number")]
        public string _Phone_number { get; private set; }

        [JsonInclude]
        [JsonPropertyName("_Education")]
        public string _Education { get; private set; }

        [JsonInclude]
        [JsonPropertyName("_Age")]
        public string _Age { get; private set; }

        [JsonInclude]
        [JsonPropertyName("_PDF")]
        public string _PDF { get; private set; }

        [JsonInclude]
        [JsonPropertyName("_Sex")]
        public string _sex { get; private set;}



    }
}
