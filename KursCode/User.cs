using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Data.Sqlite;

namespace KursCode
{
    class User : IUser
    {
        private string _Login { get; set; }
        private string _Password { get; set; }

        public User() 
        { 
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
        
        public string SerializeToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public User DeserializeFromJson(string json)
        {
            return JsonSerializer.Deserialize<User>(json);
        }

        public void Registration()
        {
            string dbPath = "user.db";
            if(!File.Exists(dbPath))
            {
               
            }
        }
    }
}
