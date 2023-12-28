using Clients;
using KursCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KursCode.MVVM.Model.Managers
{
    public class jsonManager : IjsonManager
    {
        public string ToJson(object obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        public corporationClass FromJson(string json)
        {
            return JsonSerializer.Deserialize<corporationClass>(json);
        }
    }
}
