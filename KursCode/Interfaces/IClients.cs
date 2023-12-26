using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Interfaces
{
    public interface IClients
    {
        string _Post { get; }
        string _Email { get; }
        string _City { get; }
        string _Description { get; }
        ObservableCollection<string> _Personal_qualities { get; }
        ObservableCollection<string> _Skills { get; }
        Dictionary<int, string> _Status { get; }
        Dictionary<int, string> _Citizenship { get; }
        public Dictionary<int, string> _Shedule { get; }
        public Dictionary<int, string> _Empoyment { get; }
    }
}
