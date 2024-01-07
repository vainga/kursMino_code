using Clients;
using KursCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.MVVM.Model
{
    public class workerBuilder : IfullWorkerBuilder
    {
        private workerClass worker = new workerClass();
        
        public workerBuilder set_Work_experience(string _Work_experience)
        {
            worker._Work_experience = _Work_experience;
            return this;
        }

        public workerBuilder set_workerId(int workerId)
        {
            worker.WorkerId = workerId;
            return this;
        }

        public workerBuilder set_userId(int userId)
        {
            worker.UserId = userId;
            return this;
        }

        public workerBuilder set_status(string status)
        {
            worker._Status = status;
            return this;
        }

        public workerBuilder set_post(string post)
        {
            worker._Post = post;
            return this;
        }

        public workerBuilder set_email(string email)
        {
            worker._Email = email;
            return this;
        }

        public workerBuilder set_city(string city) 
        {
            worker._City = city;
            return this;
        }

        public workerBuilder set_description(string description)
        {
            worker._Description = description;
            return this;
        }

        public workerBuilder set_personal_qualities(ObservableCollection<string> personal_qualities)
        {
            worker._Personal_qualities = personal_qualities;
            return this;
        }

        public workerBuilder set_skills(ObservableCollection<string> skills)
        {
            worker._Skills = skills;
            return this;
        }

        public workerBuilder set_citizenship(string citizenship)
        {
            worker._Citizenship = citizenship;
            return this;
        }

        public workerBuilder set_shedule(string shedule)
        {
            worker._Shedule = shedule;
            return this;
        }

        public workerBuilder set_employment(string employment)
        {
            worker._Empoyment = employment;
            return this;
        }

        public workerBuilder set_workerName(string workerName)
        {
            worker._WorkerName = workerName;
            return this;
        }

        public workerBuilder set_surname(string  surname)
        {
            worker._Surname = surname;
            return this;
        }
        
        public workerBuilder set_work_experience(string work_experience)
        {
            worker._Work_experience = work_experience;
            return this;
        }

        public workerBuilder set_salary_need(string salary_need) 
        {
            worker._Salary_need = salary_need;
            return this;
        }

        public workerBuilder set_pdf(string[] pdf)
        {
            worker._PdfFiles = pdf;
            return this;
        }

        public workerBuilder set_workerPhoto(string workerPhoto)
        { 
            worker._WorkerPhoto = workerPhoto;
            return this;
        }

        public workerBuilder set_phoneNumber(string phoneNumber)
        { 
            worker._PhoneNumber = phoneNumber;
            return this;
        }

        public workerBuilder set_education(string education)
        {
            worker._Education = education;
            return this;
        }

        public workerBuilder set_age(string age)
        {
            worker._Age = age;
            return this;
        }

        public workerBuilder set_sex(string sex)
        {
            worker._sex = sex;
            return this;
        }

        public workerClass fullWorker()
        {
            return worker;
        }
    }
}
