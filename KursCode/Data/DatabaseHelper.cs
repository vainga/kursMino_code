using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.IO;
using System.Xml;
using System.Text.Json;
using System.Text.Json.Nodes;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System.Data;

namespace KursCode.Data
{
    public class DatabaseHelper : IDatabaseHelper
    {
        private string dbName;
        public string DBName
        {
            get
            {
                return dbName;
            }
            set
            {
                dbName = value;
            }
        }

        private string _connectionString;
        private readonly MySqlConnection _dbConnection;
        public DatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
            _dbConnection = new MySqlConnection(_connectionString);
        }

        public void OpenConnection()
        {
            _dbConnection.Open();
        }

        public void CloseConnection()
        {
            _dbConnection.Close();
        }

        public IDbCommand CreateCommand()
        {
            return _dbConnection.CreateCommand();
        }

        public void createDataBase()
        {
           using (MySqlConnection conn = new MySqlConnection(_connectionString)) 
            { 
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $"CREATE DATABASE IF NOT EXISTS {DBName};";
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public void createTable(string tableName, string[] columns)
        {
            createDataBase();
            _connectionString += $"Database={DBName};";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $"CREATE TABLE IF NOT EXISTS {tableName} ({string.Join(", ", columns)});";
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}
