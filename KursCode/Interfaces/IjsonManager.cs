using Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Interfaces
{
    public interface IjsonManager
    {
        string ToJson(object obj);
        corporationClass FromJson(string json);
    }
}
