/*using KursCode;
using Microsoft.Data.Sqlite;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using KursCode.Data;
using System.Windows.Controls;
using KursCode.MVVM.Model;

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
        public int _Work_experience { get;  private set; }
        [JsonInclude]
        [JsonPropertyName("_Salary_need")]
        public int _Salary_need { get;  private set; }

        [JsonInclude]
        [JsonPropertyName("_UserId")]
        public static int _UserId { get; private set; }   
        
        public byte[] _PdfFile { get; private set; }
        public Image _WorkerPhoto { get; set; }

        public IUser user { get; set; }
        DatabaseHelper dbHelper = new DatabaseHelper(GetWorkerDBPath());


        public workerClass() : base("", "", "", "", false, new List<string>(), new List<string>(), new ClientCitizenship(), new ClientEmployment(),new ClientShedule(), new ClientStatus())
        {
            _WorkerName = "";
            _Surname = "";
            _Work_experience = 0;
            _Salary_need = 0;
            _UserId = user.userId;
            _PdfFile = null;
            _WorkerPhoto = null;
        }

        private workerClass(string workerName,string surname, string post, string email, string city, string description,bool distant, List<string> personal_qualities, List<string> skills, ClientCitizenship citizenship, ClientEmployment employment, ClientShedule shedule, ClientStatus status, int work_experience, int salary, int salary_need, byte[] pdfFile, Image workerPhoto)
        : base(post, email, city, description, distant, personal_qualities, skills, citizenship, employment, shedule, status)

        {
            _WorkerName = workerName;
            _Surname = surname;
            _Work_experience = work_experience;
            _Salary_need = salary_need;
            _UserId = user.userId;
            _PdfFile = pdfFile;
            _WorkerPhoto = workerPhoto;
        }

        private static string GetWorkerDBPath()
        {
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string parentPath = Directory.GetParent(executablePath).FullName;
            string dataFolderPath = Path.Combine(parentPath, "Data");
            string userFolderPath = Path.Combine(dataFolderPath, "UserData");
            string userSpecificFolderPath = Path.Combine(userFolderPath, $"{_UserId}_ID_User");
            string workerDbPath = Path.Combine(userSpecificFolderPath, $"{_UserId}_ID_workersndata.db");

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
            string corpJson = this.ToJson();

            using (var dbHelper = new DatabaseHelper(GetWorkerDBPath()))
            {
                dbHelper.CreateDatabase(GetWorkerDBPath(), "workerTable", "JSON_worker TEXT, UserId INTEGER,Photo TEXT, PDF BLOB");
                dbHelper.InsertData("workerTable", new[] { "JSON_worker", "UserId", "Photo", "PDF"}, new object[] { corpJson, _UserId });
            }
        }

        public List<string> ReadAllJsonFromDatabase()
        {
            string query = "SELECT JSON_worker FROM workerTable;";

            List<string> jsonStrings;

            using (dbHelper)
            {
                string condition = $"UserId = {_UserId}";

                string[] columns = { "JSON_worker" };

                List<Dictionary<string, object>> results = dbHelper.SearchData("workerTable", columns, condition);

                jsonStrings = results
                    .Select(result => result.TryGetValue("JSON_worker", out object jsonValue) ? jsonValue.ToString() : null)
                    .Where(jsonString => jsonString != null)
                    .ToList();
            }

            return jsonStrings;
        }

        public int GetId(string workerJson)
        {
            string tableName = "workerTable";
            string[] columns = { "JSON_worker", "Id" };
            string condition = $"JSON_worker = {workerJson}";

            using (dbHelper)
            {
                List<Dictionary<string, object>> searchResults = dbHelper.SearchData(tableName, columns, condition);
                if (searchResults.Count > 0)
                {
                    return Convert.ToInt32(searchResults[0]["Id"]);
                }
            }

            return -1;
        }

        public void RemoveData(int itemIdToDelete)
        {
            using (dbHelper)
            {
                dbHelper.RemoveData(itemIdToDelete);
            }
        }

    }
}*/