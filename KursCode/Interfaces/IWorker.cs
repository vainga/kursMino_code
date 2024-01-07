using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Interfaces
{
    public interface IWorker : IminiWorker
    {
        string _Work_experience { get; }
        string _Salary_need { get; }
        string _Email { get; }
        string _City { get; }
        string _Description { get; }
        ObservableCollection<string> _Personal_qualities { get; }
        string _Status { get; }
        string _Citizenship { get; }
        string _Shedule { get; }
        string _Empoyment { get; }
        string[] _PdfFiles { get; }
        string _PhoneNumber { get; }
        string _Education { get; }
        string _Age { get; }
        string _sex { get; }
    }
}
