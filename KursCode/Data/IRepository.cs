using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Data
{
    public interface IRepository
    {
        void Add(string tableName, string[] columnNames, object[] values); 
        void Delete<T>(string tableName, int id);
        public int SearchtoId(string tableName, string columnName, object searchValue);
        object SearchbyId(string tableName, int id, string columnName);
        void Change<T>(string tableName, int id, string columnName, object newValue);
        int GetLastId(string tableName);
    }
}
