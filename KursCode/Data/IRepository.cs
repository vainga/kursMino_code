using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Data
{
    public interface IRepository
    {
        void Add<T>(string tableName, params object[] values);
        void Delete<T>(string tableName, int id);
        T Search<T>(string tableName, int id);
        void Change<T>(string tableName, int id, string columnName, object newValue);
    }
}
