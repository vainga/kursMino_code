﻿using System;
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
        public int userId { get; private set; }
        private string _Login { get; set; }
        private string _Password { get; set; }

        static string databasePath = Path.Combine(GetUserFolderPath(), "userdata.db");
        DatabaseHelper dbHelper = new DatabaseHelper(databasePath);

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

        private string HashPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(6);
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }

        public int Registration()
        {
            int userId = 0;
            using(dbHelper)
            {
                dbHelper.CreateDatabase(databasePath, "Users", "Id INTEGER PRIMARY KEY, Login TEXT, Password TEXT");
                string hashedPassword = HashPassword(_Password);
                if (!dbHelper.IsValueUnique("Users","Login",_Login))
                {
                    Console.WriteLine("Пользователь с таким логином уже существует.");
                    return -1;
                }
                else
                {
                    userId = dbHelper.InsertData("Users", new[] { "Login", "Password" }, new object[] { _Login, hashedPassword });

                    string userSpecificFolderPath = Path.Combine(GetUserFolderPath(), $"{userId}_ID_User");
                    Directory.CreateDirectory(userSpecificFolderPath);

                    //string corporationDbPath = Path.Combine(userSpecificFolderPath, $"{userId}_ID_corporationsdata.db");
                    //dbHelper.CreateDatabase(corporationDbPath, "corporationTable", "ID INTEGER PRIMARY KEY, JSON_corporation TEXT, UserId INTEGER");

                    //string workerDbPath = Path.Combine(userSpecificFolderPath, $"{userId}_ID_workersndata.db");
                    //dbHelper.CreateDatabase(workerDbPath, "workerTable", "ID INTEGER PRIMARY KEY, JSON_worker TEXT, UserId INTEGER");

                    return userId;
                }
            }
        }

        public int Enter()
        {
            using (dbHelper)
            {
                List<Dictionary<string, object>> searchResults = dbHelper.SearchData("Users", new[] { "Id", "Password" }, $"Login = '{_Login}'");

                if (searchResults.Count > 0)
                {
                    string storedHashedPassword = searchResults[0]["Password"] as string;
                    userId = Convert.ToInt32(searchResults[0]["Id"]);

                    if (BCrypt.Net.BCrypt.Verify(_Password, storedHashedPassword))
                    {
                        Console.WriteLine("Логин и пароль совпадают.");
                        return userId;
                    }
                    else
                    {
                        Console.WriteLine("Пароль не совпадает.");
                    }
                }
                else
                {
                    Console.WriteLine("Пользователь не найден.");
                }
            }

            return -1;
        }
    }
}
