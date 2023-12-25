using KursCode;
using Microsoft.Data.Sqlite;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using System.IO;
using KursCode.Data;
using KursCode.MVVM.Model;

namespace Clients
{
    [Serializable]
    internal class corporationClass : clientsClass
    {
        [JsonInclude]
        [JsonPropertyName("_CorporationName")]
        public string _CorporationName { get; private set; }
        [JsonInclude]
        [JsonPropertyName("_Work_experience_min")]
        public int _Work_experience_min { get; private set; }
        [JsonInclude]
        [JsonPropertyName("_Work_experience_max")]
        public int _Work_experience_max { get; private set; }
        [JsonInclude]
        [JsonPropertyName("_Work_experience_need")]
        public bool _Work_experience_need { get; private set; }
        [JsonInclude]
        [JsonPropertyName("_Salary")]
        public int _Salary { get; private set; }

        [JsonInclude]
        [JsonPropertyName("_UserId")]
        public static int _UserId { get; private set; }
        public IUser user { get; set; }

        DatabaseHelper dbHelper = new DatabaseHelper(GetCorporationDBPath());


        public corporationClass() : base("", "", "", "", false, new List<string>(), new List<string>(), new Dictionary<int, string>(), new Dictionary<int, string>(), new Dictionary<int, string>(), new Dictionary<int, string>())
        {
            _CorporationName = "";
            _Work_experience_min = 0;
            _Work_experience_max = 0;
            _Work_experience_need = false;
            _Salary = 0;
            _UserId = user.userId;
        }

        [JsonConstructor]
        private corporationClass(string corporationName, string post, string email, string city, string description, bool distant, List<string> personal_qualities, List<string> skills, Dictionary<int, string> citizenship, Dictionary<int, string> employment, Dictionary<int, string> shedule, Dictionary<int, string> status, int work_experience_min, int work_experience_max,
            bool work_experience_need, int salary)
            : base(post, email, city, description, distant, personal_qualities, skills, citizenship, employment, shedule, status)
        {
            _CorporationName = corporationName;
            _Work_experience_max = work_experience_max;
            _Work_experience_min = work_experience_min;
            _Work_experience_need = work_experience_need;
            _Salary = salary;
            _UserId = user.userId;
        }

        private static string GetCorporationDBPath()
        {
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string parentPath = Directory.GetParent(executablePath).FullName;
            string dataFolderPath = Path.Combine(parentPath, "Data");
            string userFolderPath = Path.Combine(dataFolderPath, "UserData");
            string userSpecificFolderPath = Path.Combine(userFolderPath, $"{_UserId}_ID_User");
            string corporationDbPath = Path.Combine(userSpecificFolderPath, $"{_UserId}_ID_corporationsdata.db");

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

        public void AddData()
        {
            List<string> jsonStrings = dbHelper.GetAllEntities<string>(GetCorporationDBPath());

            int nextId = dbHelper.GetNextEntityId((string jsonString) => 0, jsonStrings);

            dbHelper.SaveEntityToFile(ToJson(), jsonStrings);
        }

        public List<string> ReadAllJsonFromDatabase()
        {
            List<string> jsonStrings = dbHelper.GetAllEntities<string>(GetCorporationDBPath());

            return jsonStrings;
        }

        public int GetId(string workerJson)
        {
            return dbHelper.GetNextEntityId((string jsonString) => 0, dbHelper.GetAllEntities<string>(GetCorporationDBPath()));
        }

        public void RemoveData(int itemIdToDelete)
        {
            using (dbHelper)
            {
                dbHelper.RemoveEntity((string jsonString) => GetId(jsonString) == itemIdToDelete, dbHelper.GetAllEntities<string>(GetCorporationDBPath()));
            }
        }


    }
}
