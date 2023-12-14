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
        void EnterInformation();
        int Registration();
        int Enter();
    }
}
