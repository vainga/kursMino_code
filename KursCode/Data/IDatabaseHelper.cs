using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Data
{
    interface IDatabaseHelper
    {
        void CreateDatabase(string dbPath, string tableName, string columns);

    }
}
