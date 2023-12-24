/*using KursCode;
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


        public corporationClass() : base("", "", "", "", false, new List<string>(), new List<string>(), new ClientCitizenship(), new ClientEmployment(), new ClientShedule(), new ClientStatus())
        {
            _CorporationName = "";
            _Work_experience_min = 0;
            _Work_experience_max = 0;
            _Work_experience_need = false;
            _Salary = 0;
            _UserId = user.userId;
        }

        [JsonConstructor]
        private corporationClass(string corporationName, string post, string email, string city, string description, bool distant, List<string> personal_qualities, List<string> skills, ClientCitizenship citizenship, ClientEmployment employment, ClientShedule shedule, ClientStatus status, int work_experience_min, int work_experience_max,
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
            string corpJson = this.ToJson();

            using (dbHelper)
            {
                dbHelper.InsertData("corporationTable", new[] { "JSON_corporation", "UserId" },new object[] { corpJson, _UserId});
            }

        }

        public List<string> ReadAllJsonFromDatabase()
        {
            string query = "SELECT JSON_corporation FROM corporationTable;";

            List<string> jsonStrings;

            using (dbHelper)
            {
                string condition = $"UserId = {_UserId}";

                string[] columns = { "JSON_corporation" };

                List<Dictionary<string, object>> results = dbHelper.SearchData("corporationTable", columns, condition);

                jsonStrings = results
                    .Select(result => result.TryGetValue("JSON_corporation", out object jsonValue) ? jsonValue.ToString() : null)
                    .Where(jsonString => jsonString != null)
                    .ToList();
            }

            return jsonStrings;
        }

        public int GetId(string corporationJson)
        {
            string tableName = "corporationTable";
            string[] columns = { "JSON_corporation", "Id" };
            string condition = $"JSON_corporation = @{corporationJson}";

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
            using(dbHelper)
            {
                dbHelper.RemoveData(itemIdToDelete);
            }
        }


    }
}
*/