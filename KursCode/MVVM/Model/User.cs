using KursCode.Data;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace KursCode
{
    class User : IUser
    {
        [JsonInclude]
        [JsonPropertyName("UserId")]
        public int userId { get; private set; }
        [JsonInclude]
        [JsonPropertyName("Login")]
        public string _Login { get; set; }
        [JsonInclude]
        [JsonPropertyName("Password")]
        public string _Password { get; set; }

        static string databasePath = Path.Combine(GetUserFolderPath(), "userdata.db");
        DatabaseHelper dbHelper = new DatabaseHelper(databasePath);

        public User()
        {
            userId = 1;
            _Login = "";
            _Password = "";
        }

        private User(string login, string password)
        {
            _Login = login;
            _Password = password;
        }

        private static string GetUserFolderPath()
        {
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string parentPath = Directory.GetParent(executablePath).FullName;
            string dataFolderPath = Path.Combine(parentPath, "Data");
            string userFolderPath = Path.Combine(dataFolderPath, "UserData");
            Directory.CreateDirectory(userFolderPath);

            return userFolderPath;
        }

        private string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        private string HashPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(6);
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }

        private const string FileName = "users.json";

        public bool Registration(string login, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(login))
                {
                    throw new ArgumentException("Логин не может быть пустым.");
                }

                if (login.Contains(" "))
                {
                    throw new ArgumentException("Логин не может содержать пробелы.");
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    throw new ArgumentException("Пароль не может быть пустым.");
                }

                if (password.Contains(" "))
                {
                    throw new ArgumentException("Пароль не может содержать пробелы.");
                }

                string userFolderPath = GetUserFolderPath();
                string userDataFilePath = Path.Combine(userFolderPath, "usersdata.json");

                List<User> existingUsers = new List<User>();
                int nextUserId = 1; // Default starting userId

                if (File.Exists(userDataFilePath))
                {
                    string existingJsonData = File.ReadAllText(userDataFilePath);
                    existingUsers = JsonSerializer.Deserialize<List<User>>(existingJsonData);

                    if (existingUsers.Any(u => u._Login == login))
                    {
                        throw new ArgumentException("Пользователь с таким логином уже существует.");
                    }

                    nextUserId = existingUsers.Max(u => u.userId) + 1;
                }

                userId = nextUserId;
                _Login = login;
                _Password = HashPassword(password);

                existingUsers.Add(this);

                string updatedJsonData = JsonSerializer.Serialize(existingUsers);

                File.WriteAllText(userDataFilePath, updatedJsonData);

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        public bool Enter(string login, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(login))
                {
                    throw new ArgumentException("Логин не может быть пустым.");
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    throw new ArgumentException("Пароль не может быть пустым.");
                }

                string userFolderPath = GetUserFolderPath();
                string userDataFilePath = Path.Combine(userFolderPath, "usersdata.json");

                if (!File.Exists(userDataFilePath))
                {
                    throw new ArgumentException("Пользователь не найден.");
                }

                string existingJsonData = File.ReadAllText(userDataFilePath);
                List<User> existingUsers = JsonSerializer.Deserialize<List<User>>(existingJsonData);

                User user = existingUsers.FirstOrDefault(u => u._Login == login);

                if (user != null)
                {
                    if (BCrypt.Net.BCrypt.Verify(password, user._Password))
                    {
                        Console.WriteLine("Логин и пароль совпадают.");
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }
    }
}
