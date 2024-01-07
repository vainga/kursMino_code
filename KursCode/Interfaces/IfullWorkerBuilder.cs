using Clients;
using KursCode.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Interfaces
{
    public interface IfullWorkerBuilder
    {
        workerBuilder set_Work_experience(string _Work_experience);
        workerBuilder set_workerId(int workerId);
        workerBuilder set_userId(int userId);
        workerBuilder set_status(string status);
        workerBuilder set_post(string post);
        workerBuilder set_email(string email);
        workerBuilder set_city(string city);
        workerBuilder set_description(string description);
        workerBuilder set_personal_qualities(ObservableCollection<string> personal_qualities);
        workerBuilder set_skills(ObservableCollection<string> skills);
        workerBuilder set_citizenship(string citizenship);
        workerBuilder set_shedule(string shedule);
        workerBuilder set_employment(string employment);
        workerBuilder set_workerName(string workerName);
        workerBuilder set_surname(string surname);
        workerBuilder set_work_experience(string work_experience);
        workerBuilder set_salary_need(string salary_need);
        workerBuilder set_pdf(string[] pdf);
        workerBuilder set_workerPhoto(string workerPhoto);
        workerBuilder set_phoneNumber(string phoneNumber);
        workerBuilder set_education(string education);
        workerBuilder set_age(string age);
        workerBuilder set_sex(string sex);
        workerClass fullWorker();
    }
}
