using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Interfaces
{
    public interface IClientStatusInfo
    {
        string _Status { get; }
        string _Citizenship { get; }
        string _Shedule { get; }
        string _Empoyment { get; }
    }
}
