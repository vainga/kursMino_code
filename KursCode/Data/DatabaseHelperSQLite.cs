using Microsoft.Data.Sqlite;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Data
{
    public class DatabaseHelperSQLite : IDatabaseHelper
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
        private readonly SqliteConnection _dbConnection;
        public DatabaseHelperSQLite(string connectionString)
        {
            _connectionString = connectionString;
            _dbConnection = new SqliteConnection(_connectionString);
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
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                using (SqliteCommand cmd = new SqliteCommand())
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
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                using (SqliteCommand cmd = new SqliteCommand())
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
