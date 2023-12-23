using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Data
{
    interface IDatabaseHelper : IDisposable
    {
        void CreateDatabase(string dbPath, string tableName, string columns);
        bool IsValueUnique(string tableName, string columnName, string value);
        int InsertData(string tableName, string[] columns, object[] values);
        List<Dictionary<string, object>> SearchData(string tableName, string[] columns, string condition);
        void RemoveData(int itemIdToDelete);
        void Dispose();
    }
}
