using KursCode;
using Microsoft.Data.Sqlite;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Clients
{
    [Serializable]
    class workerClass: clientsClass
    {
        [JsonInclude]
        [JsonPropertyName("_WorkerName")]
        public string _WorkerName { get; private set; }
        [JsonInclude]
        [JsonPropertyName("_Surname")]
        public string _Surname { get; private set; }
        [JsonInclude]
        [JsonPropertyName("_Work_experience")]
        public int _Work_experience { get;  private set; }
        [JsonInclude]
        [JsonPropertyName("_Salary_need")]
        public int _Salary_need { get;  private set; }

        public workerClass() : base("", "", "", "", false, new List<string>(), new List<string>())
        {
            _WorkerName = "";
            _Surname = "";
            _Work_experience = 0;
            _Salary_need = 0;
        }

        private workerClass(string workerName,string surname, string post, string email, string city, string description,bool distant, List<string> personal_qualities, List<string> skills, int work_experience, int salary, int salary_need) 
            : base(post, email, city, description, distant, personal_qualities, skills)
        {
            _WorkerName = workerName;
            _Surname = surname;
            _Work_experience = work_experience;
            _Salary_need = salary_need;
        }

        public void EnterInformation()
        {
            Console.WriteLine("Введите информацию о соискателе: ");
            Console.Write("Имя: ");                 _WorkerName = Console.ReadLine();
            Console.Write("Фамлия: ");              _Surname = Console.ReadLine();
            Console.Write("Опыт работы: ");         _Work_experience = int.Parse(Console.ReadLine());
            Console.Write("Желаемая зарплата: ");   _Salary_need = int.Parse(Console.ReadLine());
            base.EnterInformation();
        }

        private string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        private workerClass FromJson(string json)
        {
            return JsonSerializer.Deserialize<workerClass>(json);
        }

        public override void AddData(int userId)
        {
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string userFolderPath = Path.Combine(executablePath, "UserData");
            string userSpecificFolderPath = Path.Combine(userFolderPath, $"{userId}_ID_User");
            string workerDbPath = Path.Combine(userSpecificFolderPath, $"{userId}_ID_workersndata.db");

            using (var connection = new SqliteConnection($"Data Source={workerDbPath}"))
            {
                connection.Open();
                string entityJson = this.ToJson();
                string insertQuery = $"INSERT INTO workerTable (JSON_worker, UserId) VALUES ('{entityJson}', {userId})";
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
            string workerDbPath = Path.Combine(userSpecificFolderPath, $"{userId}_ID_workersndata.db");
            string query = "SELECT JSON_worker FROM workerTable;";


            List<string> jsonStrings = new List<string>();

            using (var connection = new SqliteConnection($"Data Source={workerDbPath}"))
            {
                connection.Open();

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string jsonString = reader["JSON_worker"].ToString();
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
                workerClass worker = FromJson(jsonString);
                Console.WriteLine($"Name: {worker._WorkerName} {worker._Surname}");
                Console.WriteLine($"Work_experience: {worker._Work_experience}");
                Console.WriteLine($"Salary need: {worker._Salary_need}");
                Console.WriteLine($"Post: {worker._Post}");
                Console.WriteLine($"Email: {worker._Email}");
                Console.WriteLine($"City: {worker._City}");
                Console.WriteLine($"Description: {worker._Description}");
                foreach (var personal_quality in worker._Personal_qualities)
                    Console.WriteLine($"{personal_quality}");
                foreach (var skill in worker._Skills)
                    Console.WriteLine($"{skill}");
            }
        }
    }
}
