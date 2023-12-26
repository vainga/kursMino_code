using Clients;
using KursCode.Data;
using KursCode.Interfaces;
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
        public string _Login {  get; private set; }
        [JsonInclude]
        [JsonPropertyName("Password")]
        public string _Password { get; private set; }

        static string databasePath = Path.Combine(GetUserFolderPath(), "userdata.db");
        //DatabaseHelper dbHelper = new DatabaseHelper(databasePath);
        private const string FileName = "users.json";

        private workerClass _worker; 

        public workerClass Worker
        {
            get { return _worker; }
        }

        public event EventHandler<int> AuthorizationCompleted;

        public User()
        {
            userId = -1;
            _Login = "";
            _Password = "";
        }

        public User(string login, string password)
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

        public bool Registration()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_Login))
                {
                    throw new ArgumentException("Логин не может быть пустым.");
                }

                if (_Login.Contains(" "))
                {
                    throw new ArgumentException("Логин не может содержать пробелы.");
                }

                if (string.IsNullOrWhiteSpace(_Password))
                {
                    throw new ArgumentException("Пароль не может быть пустым.");
                }

                if (_Password.Contains(" "))
                {
                    throw new ArgumentException("Пароль не может содержать пробелы.");
                }

                string userFolderPath = GetUserFolderPath();
                string userDataFilePath = Path.Combine(userFolderPath, "usersdata.json");

                DatabaseHelper dbHelper = new DatabaseHelper(userDataFilePath);

                List<User> existingUsers = dbHelper.GetAllEntities<User>(userDataFilePath);

                if (!dbHelper.IsValueUnique<User>(u => u._Login == _Login, existingUsers))
                {
                    throw new ArgumentException("Пользователь с таким логином уже существует.");
                }

                int nextUserId = dbHelper.GetNextEntityId<User>(u => u.userId, existingUsers);

                userId = nextUserId;
                _Password = HashPassword(_Password);
                OnAuthorizationCompleted(userId);
                dbHelper.SaveEntityToFile<User>(this, existingUsers);

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        public bool Enter()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_Login))
                {
                    throw new ArgumentException("Логин не может быть пустым.");
                }

                if (string.IsNullOrWhiteSpace(_Password))
                {
                    throw new ArgumentException("Пароль не может быть пустым.");
                }

                string userFolderPath = GetUserFolderPath();
                string userDataFilePath = Path.Combine(userFolderPath, "usersdata.json");

                DatabaseHelper dbHelper = new DatabaseHelper(userDataFilePath);

                List<User> existingUsers = dbHelper.GetAllEntities<User>(userDataFilePath);

                User user = existingUsers.FirstOrDefault(u => u._Login == _Login);

                if (user != null)
                {
                    if (BCrypt.Net.BCrypt.Verify(_Password, user._Password))
                    {
                        userId = user.userId;
                        OnAuthorizationCompleted(userId);
                        return true;
                    }
                    else
                    {
                        throw new ArgumentException("Пароль введен неправильно.");
                    }
                }
                else
                {
                    throw new ArgumentException("Пользователь не существует.");
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }

        protected virtual void OnAuthorizationCompleted(int userId)
        {
            AuthorizationCompleted?.Invoke(this, userId);
        }
    }
}
