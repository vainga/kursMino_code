using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Interfaces
{
    public interface IClients : IClientStatusInfo, IClientDetails, IClientContactInfo
    {
        //string _Post { get; }
        //string _Email { get; }
        //string _City { get; }
        //string _Description { get; }
        //ObservableCollection<string> _Personal_qualities { get; }
        //ObservableCollection<string> _Skills { get; }
        //public string _Status { get; }
        //public string _Citizenship { get; }
        //public string _Shedule { get; }
        //public string _Empoyment { get; }
    }
}
