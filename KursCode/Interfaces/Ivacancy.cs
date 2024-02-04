using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Interfaces
{
    public interface Ivacancy
    {
        string Post {  get; }
        string Email { get; }
        string City { get; }
        string Description { get; }
        ObservableCollection<string> Personal_qualities { get; }
        ObservableCollection<string> Skills {  get; }
        string Citizenship {  get; }
        string Shedule { get; }
        string Empoyment { get; }
        int Work_experience { get; }
        int Salary_min {  get; }
        int Salary_max { get; }
        string Phone_number { get; }
        string Education { get; }
        int Age { get; }
        string[] PDF { get; }
        string Sex { get; }
    }
}
