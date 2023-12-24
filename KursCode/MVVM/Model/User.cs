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
using System.Security;
using System.Configuration;
using System.Runtime.ExceptionServices;

namespace KursCode
{
    class User : IUser
    {
        public int userId { get; private set; }
        private string _Login { get;  set; }
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

                string hashedPassword = HashPassword(password);

                string userFilePath = Path.Combine(GetUserFolderPath(), $"{login}_User.txt");

                if (File.Exists(userFilePath))
                {
                    return false; 
                }

                using (StreamWriter writer = File.CreateText(userFilePath))
                {
                    writer.WriteLine($"Login: {login}");
                    writer.WriteLine($"Password: {hashedPassword}");
                }

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

                string userFilePath = Path.Combine(GetUserFolderPath(), $"{login}_User.txt");

                if (!File.Exists(userFilePath))
                {
                    throw new ArgumentException("Пользователь не найден.");
                }

                string[] userLines = File.ReadAllLines(userFilePath);
                string storedHashedPassword = userLines[1].Substring("Password: ".Length).Trim();

                if (BCrypt.Net.BCrypt.Verify(password, storedHashedPassword))
                {
                    Console.WriteLine("Логин и пароль совпадают.");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message, ex);
            }
        }
    }
}
