using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Data.Sqlite;
using KursCode.Data;
using BCrypt.Net;
using Clients;
using System.Net.Http.Json;
using System.IO;


namespace KursCode
{
    class User : IUser
    {
        private int userId;
        private string _Login { get; set; }
        private string _Password { get; set; }

        public User()
        {
            userId = -1;
            _Login = "";
            _Password = "";
        }

        private User(string login, string password)
        {
            _Login = login;
            _Password = password;
        }

        public void EnterInformation()
        {
            Console.Write("Введите логин: "); _Login = Console.ReadLine();
            Console.Write("Введите пароль: "); _Password = Console.ReadLine();
        }

        private string HashPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(6);
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }

        public bool IsLoginUnique(string login)
        {
            bool isUnique = false;
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string parentPath = Directory.GetParent(executablePath).FullName;
            string dataFolderPath = Path.Combine(parentPath, "Data");
            string userFolderPath = Path.Combine(dataFolderPath, "UserData");
            Directory.CreateDirectory(userFolderPath);

            using (var connection = new SqliteConnection($"Data Source={Path.Combine(userFolderPath, "userdata.db")}"))
            {
                connection.Open();

                using (var checkLoginCommand = new SqliteCommand("SELECT COUNT(*) FROM Users WHERE Login = @Login", connection))
                {
                    checkLoginCommand.Parameters.AddWithValue("@Login", login);

                    int result = Convert.ToInt32(checkLoginCommand.ExecuteScalar());
                    if (result != 0)
                    {
                        return isUnique;
                    }
                    isUnique = (result == 0);
                }

                connection.Close();
            }
            return isUnique;
        }

        public void Registration()
        {
            int userId = 0;
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string parentPath = Directory.GetParent(executablePath).FullName;
            string dataFolderPath = Path.Combine(parentPath, "Data");
            string userFolderPath = Path.Combine(dataFolderPath, "UserData");
            Directory.CreateDirectory(userFolderPath);


            using (var connection = new SqliteConnection($"Data Source={Path.Combine(userFolderPath, "userdata.db")}"))
            {
                connection.Open();

                using (var createTableCommand = new SqliteCommand("CREATE TABLE IF NOT EXISTS Users (Id INTEGER PRIMARY KEY,Login TEXT, Password TEXT)", connection))
                {
                    createTableCommand.ExecuteNonQuery();
                }

                string hashedPassword = HashPassword(_Password);
                if (!IsLoginUnique(_Login))
                {
                    Console.WriteLine("Пользователь с таким логином уже существует.");
                    return; // Выйти из метода, чтобы не продолжать регистрацию
                }
                else
                {
                    using (var insertCommand = new SqliteCommand("INSERT INTO Users (Login, Password) VALUES (@Login, @Password); SELECT last_insert_rowid();", connection))
                    {
                        insertCommand.Parameters.AddWithValue("@Login", _Login);
                        insertCommand.Parameters.AddWithValue("@Password", hashedPassword);

                        userId = Convert.ToInt32(insertCommand.ExecuteScalar());

                    }

                    string userSpecificFolderPath = Path.Combine(userFolderPath, $"{userId}_ID_User");
                    Directory.CreateDirectory(userSpecificFolderPath);

                    string corporationDbPath = Path.Combine(userSpecificFolderPath, $"{userId}_ID_corporationsdata.db");
                    //DatabaseHelper.CreateDatabase(corporationDbPath, "corporationTable", "ID INTEGER PRIMARY KEY, JSON_corporation TEXT,UserId INTEGER,FOREIGN KEY(UserId) REFERENCES Users(Id)");
                    DatabaseHelper.CreateDatabase(corporationDbPath, "corporationTable", "ID INTEGER PRIMARY KEY, JSON_corporation TEXT,UserId INTEGER");

                    string workerDbPath = Path.Combine(userSpecificFolderPath, $"{userId}_ID_workersndata.db");
                    //DatabaseHelper.CreateDatabase(workerDbPath, "workerTable", "ID INTEGER PRIMARY KEY, JSON_worker TEXT,  UserId INTEGER, FOREIGN KEY(UserId) REFERENCES Users(Id)");
                    DatabaseHelper.CreateDatabase(workerDbPath, "workerTable", "ID INTEGER PRIMARY KEY, JSON_worker TEXT,  UserId INTEGER");
                    connection.Close();
                }
            }
        }

        public int Enter()
        {
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string parentPath = Directory.GetParent(executablePath).FullName;
            string dataFolderPath = Path.Combine(parentPath, "Data");
            string userFolderPath = Path.Combine(dataFolderPath, "UserData");
            Directory.CreateDirectory(userFolderPath);

            using (var connection = new SqliteConnection($"Data Source={Path.Combine(userFolderPath, "userdata.db")}"))
            {
                connection.Open();
                using (SqliteCommand cmd = new SqliteCommand("SELECT Id, Password FROM Users WHERE Login=@Login", connection))
                {
                    cmd.Parameters.AddWithValue("@Login", _Login);

                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHashedPassword = reader["Password"] as string;
                            userId = reader.GetInt32(reader.GetOrdinal("Id"));

                            if (BCrypt.Net.BCrypt.Verify(_Password, storedHashedPassword))
                            {
                                Console.WriteLine("Логин и пароль совпадают.");
                                return userId;
                            }
                            else
                            {
                                Console.WriteLine("Пароль не совпадет.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Пользователь не найден.");
                        }
                    }
                }
                connection.Close();
            }

            return -1;
        }
    }
}
