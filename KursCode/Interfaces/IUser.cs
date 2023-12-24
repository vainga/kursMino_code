using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;


namespace KursCode
{
    internal interface IUser 
    {
        int userId { get;}
        bool Registration(string login, string password);
        bool Enter(string login, string password);
    }
}
