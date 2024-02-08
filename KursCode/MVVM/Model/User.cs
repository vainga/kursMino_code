using Clients;
using KursCode.Data;
using KursCode.Interfaces;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace KursCode
{
    public class User : IUser
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

        private UserData dataManager = new UserData();

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
                
                userId = dataManager.GetLastId()+1;
                _Password = HashPassword(_Password);
                dataManager.Add(this);

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

                var userId = dataManager.SearchId(this);

                if (userId != null)
                {
                    this.userId = userId;
                    var password = dataManager.SearchPassword(this);
                    if (BCrypt.Net.BCrypt.Verify(_Password, password))
                    {
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
    }
}
