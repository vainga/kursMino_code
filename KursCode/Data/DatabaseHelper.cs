using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;


namespace KursCode.Data
{
    public class DatabaseHelper
    {
        private SqliteConnection connection;

        public DatabaseHelper(string connectionString)
        {
            connection = new SqliteConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        public SqliteDataReader ExecuteReader(string query)
        {
            SqliteCommand cmd = new SqliteCommand(query);
            return cmd.ExecuteReader();
        }

       //using (var createTableCommand = new SqliteCommand("CREATE TABLE IF NOT EXISTS Corporations (Id INTEGER PRIMARY KEY, Name TEXT, UserId INTEGER, FOREIGN KEY(UserId) REFERENCES Users(Id))"

        public static void CreateDatabase(string dbPath, string tableName, string columns)
        {
            if (!File.Exists(dbPath))
            {
                using (SqliteConnection connection = new SqliteConnection($"Data Source={dbPath};"))
                {
                    connection.Open();

                    string createTableQuery = $"CREATE TABLE {tableName} ({columns});";
                    using (SqliteCommand command = new SqliteCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                Console.WriteLine($"База данных по пути {dbPath} уже существует.");
            }

        }
    }
}
