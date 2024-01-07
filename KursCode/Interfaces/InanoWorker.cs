using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Interfaces
{
    public interface InanoWorker
    {
        int WorkerId { get; set; }
        int UserId { get; set; }
        string _WorkerName { get; }
        string _Surname { get; }
        string _Post { get; }
        string _WorkerPhoto { get; }
    }
}
