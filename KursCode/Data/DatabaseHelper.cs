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
    }
}
