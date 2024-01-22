using Clients;
using KursCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KursCode.MVVM.Model
{
    public class workerBuilder : IfullWorkerBuilder
    {
        private workerClass _worker = new workerClass();
        
        public workerBuilder set_Work_experience(int _Work_experience)
        {
            _worker.Work_experience = _Work_experience;
            return this;
        }

        public workerBuilder set_workerId(int workerId)
        {
            _worker.WorkerId = workerId;
            return this;
        }

        public workerBuilder set_userId(int userId)
        {
            _worker.UserId = userId;
            return this;
        }

        public workerBuilder set_status(string status)
        {
            _worker.Status = status;
            return this;
        }

        public workerBuilder set_post(string post)
        {
            _worker.Post = post;
            return this;
        }

        public workerBuilder set_email(string email)
        {
            _worker.Email = email;
            return this;
        }

        public workerBuilder set_city(string city) 
        {
            _worker.City = city;
            return this;
        }

        public workerBuilder set_description(string description)
        {
            _worker.Description = description;
            return this;
        }

        public workerBuilder set_personal_qualities(ObservableCollection<string> personal_qualities)
        {
            _worker.Personal_qualities = personal_qualities;
            return this;
        }

        public workerBuilder set_skills(ObservableCollection<string> skills)
        {
            _worker.Skills = skills;
            return this;
        }

        public workerBuilder set_citizenship(string citizenship)
        {
            _worker.Citizenship = citizenship;
            return this;
        }

        public workerBuilder set_shedule(string shedule)
        {
            _worker.Shedule = shedule;
            return this;
        }

        public workerBuilder set_employment(string employment)
        {
            _worker.Empoyment = employment;
            return this;
        }

        public workerBuilder set_workerName(string workerName)
        {
            _worker.WorkerName = workerName;
            return this;
        }

        public workerBuilder set_surname(string  surname)
        {
            _worker.Surname = surname;
            return this;
        }
        
        public workerBuilder set_work_experience(int work_experience)
        {
            _worker.Work_experience = work_experience;
            return this;
        }

        public workerBuilder set_salary_need(int salary_need) 
        {
            _worker.Salary_need = salary_need;
            return this;
        }

        public workerBuilder set_pdf(string[] pdf)
        {
            _worker.PdfFiles = pdf;
            return this;
        }

        public workerBuilder set_workerPhoto(string workerPhoto)
        {
            _worker.WorkerPhoto = workerPhoto;
            return this;
        }

        public workerBuilder set_phoneNumber(string phoneNumber)
        {
            _worker.PhoneNumber = phoneNumber;
            return this;
        }

        public workerBuilder set_education(string education)
        {
            _worker.Education = education;
            return this;
        }

        public workerBuilder set_age(int age)
        {
            _worker.Age = age;
            return this;
        }

        public workerBuilder set_sex(string sex)
        {
            _worker.Sex = sex;
            return this;
        }

        public workerClass fullWorker()
        {
            return _worker;
        }
    }
}
