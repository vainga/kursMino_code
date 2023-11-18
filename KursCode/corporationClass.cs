using KursCode;
using Microsoft.Data.Sqlite;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;


namespace Clients
{
    internal class corporationClass: clientsClass
    {
        private string _CorporationName { get; set; }
        private int _Work_experience_min { get; set; }
        private int _Work_experience_max { get; set; }
        private bool _Work_experience_need { get; set; }
        private int _Salary { get; set; }

        public corporationClass() : base("", "", "", "", false, new List<string>(), new List<string>())
        {
            _CorporationName = "";
            _Work_experience_min = 0;
            _Work_experience_max = 0;
            _Work_experience_need = false;
            _Salary = 0;
        }

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

        private object FromJson(string json)
        {
            return JsonSerializer.Deserialize<workerClass>(json);
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
    }
}
