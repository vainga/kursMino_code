using KursCode;
using Microsoft.Data.Sqlite;
using System.Text.Json;

namespace Clients
{
    class workerClass: clientsClass
    {
        private string _WorkerName { get; set; }
        private string _Surname { get; set; }
        private int _Work_experience { get; set; }
        private int _Salary_need { get; set; }

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

        private object FromJson(string json)
        {
            return JsonSerializer.Deserialize<corporationClass>(json);
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
    }
}
