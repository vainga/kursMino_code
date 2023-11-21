using KursCode;
using Microsoft.Data.Sqlite;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;


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

        public corporationClass() : base("", "", "", "", false, new List<string>(), new List<string>())
        {
            _CorporationName = "";
            _Work_experience_min = 0;
            _Work_experience_max = 0;
            _Work_experience_need = false;
            _Salary = 0;
        }

        [JsonConstructor]
        private corporationClass(string corporationName, string post, string email, string city, string description, bool distant, List<string> personal_qualities, List<string> skills, int work_experience_min, int work_experience_max,
            bool work_experience_need, int salary)
            : base(post, email, city, description, distant, personal_qualities, skills)
        {
            _CorporationName = corporationName;
            _Work_experience_max = work_experience_max;
            _Work_experience_min = work_experience_min;
            _Work_experience_need = work_experience_need;
            _Salary = salary;
        }

        public void EnterInformation()
        {
            int x = 0;
            Console.WriteLine("Введите информацию о работодателе: ");
            Console.Write("Название: "); _CorporationName = Console.ReadLine();
            Console.Write("Нужен ли опыт работы: "); x = int.Parse(Console.ReadLine());
            if (x == 1)
            {
                _Work_experience_need = true;
                Console.Write("Нижняя граница опыта работы: "); _Work_experience_min = int.Parse(Console.ReadLine());
                Console.Write("Верхняя граница опыта работы: "); _Work_experience_max = int.Parse(Console.ReadLine());
            }
            else
                _Work_experience_need = false;
            Console.Write("Предлагаемая зарплата: "); _Salary = int.Parse(Console.ReadLine());
            base.EnterInformation();
        }

        private string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        private corporationClass FromJson(string json)
        {
            return JsonSerializer.Deserialize<corporationClass>(json);
        }

        public override void AddData(int userId)
        {
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string userFolderPath = Path.Combine(executablePath, "UserData");
            string userSpecificFolderPath = Path.Combine(userFolderPath, $"{userId}_ID_User");
            string corporationDbPath = Path.Combine(userSpecificFolderPath, $"{userId}_ID_corporationsdata.db");


            using (var connection = new SqliteConnection($"Data Source={corporationDbPath}"))
            {
                connection.Open();
                string corpJson = this.ToJson();
                string insertQuery = $"INSERT INTO corporationTable (JSON_corporation, UserId) VALUES ('{corpJson}', {userId})";
                using (SqliteCommand insertCmd = new SqliteCommand(insertQuery, connection))
                {
                    insertCmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public override List<string> ReadAllJsonFromDatabase(int userId)
        {
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string userFolderPath = Path.Combine(executablePath, "UserData");
            string userSpecificFolderPath = Path.Combine(userFolderPath, $"{userId}_ID_User");
            string corporationDbPath = Path.Combine(userSpecificFolderPath, $"{userId}_ID_corporationsdata.db");
            string query = "SELECT JSON_corporation FROM corporationTable;";


            List<string> jsonStrings = new List<string>();

            using (var connection = new SqliteConnection($"Data Source={corporationDbPath}"))
            {
                connection.Open();

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string jsonString = reader["JSON_corporation"].ToString();
                            jsonStrings.Add(jsonString);
                        }
                    }
                }

                connection.Close();
            }

            return jsonStrings;
        }

        public void WriteBase(List<string> jsonStrings)
        {
            foreach (var jsonString in jsonStrings)
            {
                corporationClass corp = FromJson(jsonString);
                Console.WriteLine($"Corporation: {corp._CorporationName}");
                Console.WriteLine($"Work_experience_min: {corp._Work_experience_min}");
                Console.WriteLine($"Work_experience_max: {corp._Work_experience_max}");
                Console.WriteLine($"Salary: {corp._Salary}");
                Console.WriteLine($"Post: {corp._Post}");
                Console.WriteLine($"Email: {corp._Email}");
                Console.WriteLine($"City: {corp._City}");
                Console.WriteLine($"Description: {corp._Description}");
                foreach (var personal_quality in corp._Personal_qualities)
                    Console.WriteLine($"{personal_quality}");
                foreach (var skill in corp._Skills)
                    Console.WriteLine($"{skill}");
            }
        }

        public override int GetId(int userId, string corporationJson)
        {
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string userFolderPath = Path.Combine(executablePath, "UserData");
            string userSpecificFolderPath = Path.Combine(userFolderPath, $"{userId}_ID_User");
            string corporationDbPath = Path.Combine(userSpecificFolderPath, $"{userId}_ID_corporationsdata.db");

            using (var connection = new SqliteConnection($"Data Source={corporationDbPath}"))
            {
                connection.Open();
                using (SqliteCommand cmd = new SqliteCommand("SELECT JSON_corporation, Id FROM corporationTable WHERE JSON_corporation=@JSON_corporation", connection))
                {
                    cmd.Parameters.AddWithValue("@JSON_corporation", corporationJson);
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            return reader.GetInt32(reader.GetOrdinal("Id"));
                    }
                    connection.Close();
                }
            }
            return -1;
        }

        public override void RemoveData(int userId, int itemIdToDelete)
        {
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string userFolderPath = Path.Combine(executablePath, "UserData");
            string userSpecificFolderPath = Path.Combine(userFolderPath, $"{userId}_ID_User");
            string corporationDbPath = Path.Combine(userSpecificFolderPath, $"{userId}_ID_corporationsdata.db");

            using (var connection = new SqliteConnection($"Data Source={corporationDbPath}"))
            {
                connection.Open();
                using (SqliteCommand command = new SqliteCommand("DELETE FROM corporationTable WHERE Id = @ItemId", connection))
                {
                    command.Parameters.AddWithValue("@ItemId", itemIdToDelete);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
