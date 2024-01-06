using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Data
{
    public interface IDatabaseHelper
    {
        string DBName { get; set; }
        void createDataBase();
        void createTable(string tableName, string[] columns);
        void OpenConnection();
        void CloseConnection();
        MySqlCommand CreateCommand();
    }
}
