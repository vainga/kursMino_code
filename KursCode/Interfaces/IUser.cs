using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;


namespace KursCode
{
    public interface IUser 
    {
        int userId { get;}
        string _Login {  get; }
        string _Password { get; }
        bool Registration();
        bool Enter();
    }
}
