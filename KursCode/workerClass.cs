using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Clients
{
    class workerClass: clientsClass
    {
        private int _Work_experience { get; set; }
        private bool _Salary_need { get; set; }

        public workerClass(string name, string post, string email, string city, string description,bool distant, List<string> personal_qualities, List<string> skills, int work_experience, int salary, bool salary_need) 
            : base(name, post, email, city, description, distant, personal_qualities, skills)
        {
            _Work_experience = work_experience;
            _Salary_need = salary_need;
        }
    }
}
