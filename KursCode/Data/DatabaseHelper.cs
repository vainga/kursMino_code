using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.IO;

namespace KursCode.Data
{
    public class DatabaseHelper
    {
        private SqliteConnection connection;

        public DatabaseHelper(string connectionString)
        {
            connection = new SqliteConnection(connectionString);
        }

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
