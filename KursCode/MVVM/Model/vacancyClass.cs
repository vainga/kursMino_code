using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KursCode.MVVM.Model
{
    public class vacancyClass
    {
        [JsonInclude]
        [JsonPropertyName("Post")]
        private string _post;
        public string Post
        {
            get { return _post; }
            set { _post = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Email")]
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        [JsonInclude]
        [JsonPropertyName("City")]
        private string _city;
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Description")]
        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Personal_qualities")]
        private ObservableCollection<string> _personal_qualities;
        public ObservableCollection<string> Personal_qualities
        {
            get { return _personal_qualities; }
            set { _personal_qualities = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Skills")]
        private ObservableCollection<string> _skills;
        public ObservableCollection<string> Skills
        {
            get { return _skills; }
            set { _skills = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Citizenship")]
        private string _citizenship;
        public string Citizenship
        {
            get { return _citizenship; }
            set { _citizenship = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Shedule")]
        private string _shedule;
        public string Shedule
        {
            get { return _shedule; }
            set { _shedule = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Empoyment")]
        private string _employment;
        public string Empoyment
        {
            get { return _employment; }
            set { _employment = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Work_experience")]
        private int _work_experience;
        public int Work_experience
        {
            get { return _work_experience; }
            set { 
                    if(_work_experience >= 0)
                        _work_experience = value;
                    throw new ArgumentException("work_experience cannot be less than zero");
            }
        }

        [JsonInclude]
        [JsonPropertyName("Salary_min")]
        private int _salary_min;
        public int Salary_min
        {
            get { return _salary_min; }
            set {
                    if (_salary_min >= 0)
                        _salary_min = value;
                    throw new ArgumentException("salary_min cannot be less than zero");
            }
        }

        [JsonInclude]
        [JsonPropertyName("Salary_max")]
        private int _salary_max;
        public int Salary_max
        {
            get { return _salary_max; }
            set {
                    if (_salary_max >= 0)
                        _salary_max = value;
                    throw new ArgumentException("salary_max cannot be less than zero");
                }
        }

        [JsonInclude]
        [JsonPropertyName("Phone_number")]
        private string _phone_number;
        public string Phone_number
        {
            get {return _phone_number; }
            set { _phone_number = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Education")]
        private string _education;
        public string Education
        {
            get { return _education; }
            set { _education = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Age")]
        private int _age;
        public int Age
        {
            get { return _age; }
            set {
                    if (_age >= 0)
                        _age = value;
                    throw new ArgumentException("age cannot be less than zero");
                }
        }

        [JsonInclude]
        [JsonPropertyName("PDF")]
        private string[] _pdf;
        public string[] PDF
        {
            get { return _pdf; }
            set { _pdf = value; }
        }

        [JsonInclude]
        [JsonPropertyName("Sex")]
        private string _sex;
        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }
    }
}
