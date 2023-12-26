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
    class workerClass: clientsClass
    {
        [JsonInclude]
        [JsonPropertyName("_WorkerName")]
        public string _WorkerName { get; private set; }
        
        [JsonInclude]
        [JsonPropertyName("_Surname")] //Нужно ли?
        public string _Surname { get; private set; }
        
        [JsonInclude]
        [JsonPropertyName("_Work_experience")]
        public string _Work_experience { get;  private set; }
        
        [JsonInclude]
        [JsonPropertyName("_Salary_need")]
        public string _Salary_need { get;  private set; }

        [JsonInclude]
        [JsonPropertyName("_UserId")]
        public static int _UserId { get; private set; }

        [JsonInclude]
        [JsonPropertyName("_PDF")]
        public string _PdfFile { get; private set; }
        //public byte[] _PdfFile { get; private set; }
        
        [JsonInclude]
        [JsonPropertyName("_Photo")]
        public string _WorkerPhoto { get; set; }

        [JsonInclude]
        [JsonPropertyName("PhoneNumber")]
        public string _PhoneNumber { get; set; }

        [JsonInclude]
        [JsonPropertyName("Education")]
        public string _Education { get; set; }

        public IUser user { get; set; }

        DatabaseHelper dbHelper = new DatabaseHelper(GetWorkerDBPath());

        public workerClass() : base("", "", "", "", new ObservableCollection<string>(), new ObservableCollection<string>(), new Dictionary<int, string>(), new Dictionary<int, string>(),new Dictionary<int, string>(), new Dictionary<int, string>())
        {
            user = new User();
            _WorkerName = "";
            _Surname = "";
            _Work_experience = "";
            _Salary_need ="";
            _UserId = -1;
            _PdfFile = "";
            _WorkerPhoto = "";
            _PhoneNumber = "";
            _Education = "";
        }

        public workerClass(string workerName,string surname, string post, string email, string city, string description, int userID ,ObservableCollection<string> personal_qualities, ObservableCollection<string> skills, Dictionary<int, string> citizenship, Dictionary<int, string> employment, Dictionary<int, string> shedule, Dictionary<int, string> status, string work_experience, string salary_need, string pdfFile, string workerPhoto, string phoneNumber, string education)
        : base(post, email, city, description, personal_qualities, skills, citizenship, employment, shedule, status)

        {
            _WorkerName = workerName;
            _Surname = surname;
            _Work_experience = work_experience;
            _Salary_need = salary_need;
            _UserId = userID;
            _PdfFile = pdfFile;
            _WorkerPhoto = workerPhoto;
            _PhoneNumber = phoneNumber;
            _Education = education;
        }

        private static string GetWorkerDBPath()
        {
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string parentPath = Directory.GetParent(executablePath).FullName;
            string dataFolderPath = Path.Combine(parentPath, "Data");
            string userFolderPath = Path.Combine(dataFolderPath, "UserData");
            string workerDbPath = Path.Combine(userFolderPath, $"{_UserId}_ID_User");
            Directory.CreateDirectory(workerDbPath);
            return workerDbPath;
        }


        private string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        private workerClass FromJson(string json)
        {
            return JsonSerializer.Deserialize<workerClass>(json);
        }

        public string ImageToBase64(string imagePath)
        {
            byte[] imageBytes = File.ReadAllBytes(imagePath);
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }

        public void AddData()
        {
            string workerFolderPath = GetWorkerDBPath();
            string workerDataFilePath = Path.Combine(workerFolderPath, "worker.json");
            DatabaseHelper dbHelper = new DatabaseHelper(workerDataFilePath);
            List<string> jsonStrings = dbHelper.GetAllEntities<string>(GetWorkerDBPath());
            int nextId = dbHelper.GetNextEntityId((string jsonString) => 0, jsonStrings);
            dbHelper.SaveEntityToFile(ToJson(), jsonStrings);
        }

        public List<string> ReadAllJsonFromDatabase()
        {
            List<string> jsonStrings = dbHelper.GetAllEntities<string>(GetWorkerDBPath());

            return jsonStrings;
        }

        public int GetId(string workerJson)
        {
            return dbHelper.GetNextEntityId((string jsonString) => 0, dbHelper.GetAllEntities<string>(GetWorkerDBPath()));
        }

        public void RemoveData(int itemIdToDelete)
        {
            using (dbHelper)
            {
                dbHelper.RemoveEntity((string jsonString) => GetId(jsonString) == itemIdToDelete, dbHelper.GetAllEntities<string>(GetWorkerDBPath()));
            }
        }

    }
}