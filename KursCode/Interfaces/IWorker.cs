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
        int Work_experience { get; }
        int Salary_need { get; }
        string Email { get; }
        string City { get; }
        string Description { get; }
        ObservableCollection<string> Personal_qualities { get; }
        string Status { get; }
        string Citizenship { get; }
        string Shedule { get; }
        string Empoyment { get; }
        string[] PdfFiles { get; }
        string PhoneNumber { get; }
        string Education { get; }
        int Age { get; }
        string Sex { get; }
    }
}
