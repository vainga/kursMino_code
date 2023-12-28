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
    public class corporationClass : clientsClass
    {
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
        [JsonPropertyName("_UserId")]
        public static int _UserId { get; private set; }

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

        public IUser user { get; set; }

        DatabaseHelper dbHelper = new DatabaseHelper(GetCorporationDBPath(_UserId));


        public corporationClass() : base("", "", "", "", new ObservableCollection<string>(), new ObservableCollection<string>(), "", "", "", "")
        {
            _CorporationName = "";
            _Work_experience = "";
            _Salary_min = "";
            _Salary_max = "";
            _Phone_number = "";
            _Education = "";
            _Age = "";
            _PDF="";
        }

        [JsonConstructor]
        public corporationClass(string corporationName, string post, string email, string city, string description, ObservableCollection<string> personal_qualities, ObservableCollection<string> skills, string citizenship, string employment, string shedule, string status, string work_experience_max
            , string salary_min, string salary_max, string phone_number, string education, string age, string pdf)
            : base(post, email, city, description, personal_qualities, skills, citizenship, employment, shedule, status)
        {
            _CorporationName = corporationName;
            _Work_experience = work_experience_max;
            _Salary_min = salary_min;
            _Salary_max = salary_max;
            _Phone_number = phone_number;
            _Education = education;
            _Age = age;
            _PDF = pdf;
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

        private string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        private corporationClass FromJson(string json)
        {
            return JsonSerializer.Deserialize<corporationClass>(json);
        }

        public void AddData(int userid)
        {
            string workerFolderPath = GetCorporationDBPath(userid);
            string workerDataFilePath = Path.Combine(workerFolderPath, "corporation.json");
            DatabaseHelper dbHelper = new DatabaseHelper(workerDataFilePath);

            if (!File.Exists(workerDataFilePath))
            {
                File.WriteAllText(workerDataFilePath, "[]");
            }

            List<corporationClass> jsonObjects = dbHelper.GetAllEntities<corporationClass>(workerDataFilePath);


            dbHelper.SaveEntityToFile<corporationClass>(this, jsonObjects);
        }

        public List<string> ReadAllJsonFromDatabase(int userId)
        {
            List<string> jsonStrings = dbHelper.GetAllEntities<string>(GetCorporationDBPath(userId));

            return jsonStrings;
        }

        //public int GetId(string corpJson,int userId)
        //{
        //    return dbHelper.GetNextEntityId((string jsonString) => 0, dbHelper.GetAllEntities<string>(GetCorporationDBPath(userId)));
        //}

        //public void RemoveData(int itemIdToDelete)
        //{
        //    using (dbHelper)
        //    {
        //        dbHelper.RemoveEntity((string jsonString) => GetId(jsonString) == itemIdToDelete, dbHelper.GetAllEntities<string>(GetCorporationDBPath()));
        //    }
        //}


    }
}
