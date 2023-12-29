using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Interfaces
{
    public interface IClientContactInfo
    {
        string _Post { get; }
        string _Email { get; }
        string _City { get; }
    }
}
