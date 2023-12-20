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
    public class DatabaseHelper : IDisposable
    {
        private string connectionString;
        private bool disposed = false;

        public DatabaseHelper(string databasePath)
        {
            connectionString = $"Data Source={databasePath}";
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }

                disposed = true;
            }
        }

        public void CreateDatabase(string dbPath, string tableName, string columns)
        {
            try
            {
                using (SqliteConnection connection = new SqliteConnection($"Data Source={dbPath}"))
                {
                    connection.Open();

                    //string columnsString = string.Join(", ", columns);
                    string query = $"CREATE TABLE IF NOT EXISTS {tableName} ({columns})";

                    using (SqliteCommand createTableCommand = new SqliteCommand(query, connection))
                    {
                        createTableCommand.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
            catch(SqliteException sqlex)
            {

            }
            catch(Exception ex)
            {

            }
        }

        public bool IsValueUnique(string tableName, string columnName, string value)
        {
            bool isUnique = false;

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT COUNT(*) FROM {tableName} WHERE {columnName} = @Value";

                using (SqliteCommand checkValueCommand = new SqliteCommand(query, connection))
                {
                    checkValueCommand.Parameters.AddWithValue("@Value", value);

                    int result = Convert.ToInt32(checkValueCommand.ExecuteScalar());
                    isUnique = (result == 0);
                }

                connection.Close();
            }

            return isUnique;
        }

        public int InsertData(string tableName, string[] columns, object[] values)
        {
            int insertedId = 0;

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string columnsString = string.Join(", ", columns);
                string valuesString = string.Join(", ", columns.Select(c => $"@{c}"));

                string query = $"INSERT INTO {tableName} ({columnsString}) VALUES ({valuesString}); SELECT last_insert_rowid();";

                using (SqliteCommand insertCommand = new SqliteCommand(query, connection))
                {
                    for (int i = 0; i < columns.Length; i++)
                    {
                        insertCommand.Parameters.AddWithValue($"@{columns[i]}", values[i]);
                    }

                    insertedId = Convert.ToInt32(insertCommand.ExecuteScalar());
                }

                connection.Close();
            }

            return insertedId;
        }

        public List<Dictionary<string, object>> SearchData(string tableName, string[] columns, string condition)
        {
            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string columnsString = string.Join(", ", columns);
                string query = $"SELECT {columnsString} FROM {tableName} WHERE {condition}";

                using (SqliteCommand searchCommand = new SqliteCommand(query, connection))
                {
                    using (SqliteDataReader reader = searchCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Dictionary<string, object> row = new Dictionary<string, object>();

                            foreach (string column in columns)
                            {
                                row[column] = reader[column];
                            }

                            results.Add(row);
                        }
                    }
                }

                connection.Close();
            }
            return results;
        }

        public void RemoveData(int itemIdToDelete)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (SqliteCommand command = new SqliteCommand("DELETE FROM corporationTable WHERE Id = @ItemId", connection))
                {
                    command.Parameters.AddWithValue("@ItemId", itemIdToDelete);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }


    }
}
