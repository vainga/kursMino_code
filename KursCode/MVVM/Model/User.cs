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
        public string _Login { get; private set; }
        [JsonInclude]
        [JsonPropertyName("Password")]
        public string _Password { get; private set; }

        static string databasePath = Path.Combine(GetUserFolderPath(), "userdata.db");
        //DatabaseHelper dbHelper = new DatabaseHelper(databasePath);
        private const string FileName = "users.json";

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

                DatabaseHelper dbHelper = new DatabaseHelper(userDataFilePath);

                List<User> existingUsers = dbHelper.GetAllEntities<User>(userDataFilePath);

                if (!dbHelper.IsValueUnique<User>(u => u._Login == login, existingUsers))
                {
                    throw new ArgumentException("Пользователь с таким логином уже существует.");
                }

                int nextUserId = dbHelper.GetNextEntityId<User>(u => u.userId, existingUsers);

                userId = nextUserId;
                _Login = login;
                _Password = HashPassword(password);

                dbHelper.SaveEntityToFile<User>(this, existingUsers);

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

                DatabaseHelper dbHelper = new DatabaseHelper(userDataFilePath);

                List<User> existingUsers = dbHelper.GetAllEntities<User>(userDataFilePath);

                User user = existingUsers.FirstOrDefault(u => u._Login == login);

                if (user != null)
                {
                    if (BCrypt.Net.BCrypt.Verify(password, user._Password))
                    {
                        return true;
                    }
                    else
                    {
                        throw new ArgumentException("Пароль введен неправильно.");
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
