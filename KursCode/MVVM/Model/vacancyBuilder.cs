using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.MVVM.Model
{
    public class vacancyBuilder
    {
        private vacancyClass _vacancyClass = new vacancyClass();

        public vacancyBuilder SetPost(string post)
        {
            _vacancyClass.Post = post;
            return this;
        }

        public vacancyBuilder SetEmail(string email)
        {
            _vacancyClass.Email = email;
            return this;
        }

        public vacancyBuilder SetCity(string city)
        {
            _vacancyClass.City = city;
            return this;
        }

        public vacancyBuilder SetDescription(string description)
        {
            _vacancyClass.Description = description;
            return this;
        }

        public vacancyBuilder SetPersonal_qualities(ObservableCollection<string> personal_qulities)
        {
            _vacancyClass.Personal_qualities = personal_qulities;
            return this;
        }

        public vacancyBuilder SetSkills(ObservableCollection<string> skills)
        {
            _vacancyClass.Skills = skills;
            return this;
        }

        public vacancyBuilder SetCitizenship(string citizenship)
        {
            _vacancyClass.Citizenship = citizenship;
            return this;
        }

        public vacancyBuilder SetShedule(string shedule)
        {
            _vacancyClass.Shedule = shedule;
            return this;
        }

        public vacancyBuilder SetEmpoyment(string empoyment)
        {
            _vacancyClass.Empoyment = empoyment;
            return this;
        }

        public vacancyBuilder SetWork_experience(int work_experience)
        {
            _vacancyClass.Work_experience = work_experience;
            return this;
        }

        public vacancyBuilder SetSalary_min(int salary_min)
        {
            _vacancyClass.Salary_min = salary_min;
            return this;
        }

        public vacancyBuilder SetSalary_max(int salary_max)
        {
            _vacancyClass.Salary_max = salary_max;
            return this;
        }

        public vacancyBuilder SetPhone_number(string phone_number)
        {
            _vacancyClass.Phone_number = phone_number;
            return this;
        }

        public vacancyBuilder SetEducation(string education)
        {
            _vacancyClass.Education = education;
            return this;
        }

        public vacancyBuilder SetAge(int age)
        {
            _vacancyClass.Age = age;
            return this;
        }

        public vacancyBuilder SetPDF(string[] pdf)
        {
            _vacancyClass.PDF = pdf;
            return this;
        }

        public vacancyBuilder SetSex(string sex)
        {
            _vacancyClass.Sex = sex;
            return this;
        }

    }
}
