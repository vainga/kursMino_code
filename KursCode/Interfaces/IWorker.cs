using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Interfaces
{
    public interface IWorker : IClients
    {
        string _WorkerName { get; }
        string _Surname { get; }
        string _Work_experience { get; }
        int _Salary_need { get; }
        int _UserId { get; } 
    }
}
