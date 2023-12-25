using KursCode.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Clients
{
    [Serializable]
    abstract class clientsClass
    {
        [JsonInclude]
        [JsonPropertyName("Post")]
        public string _Post { get; private set; }
        [JsonInclude]
        [JsonPropertyName("Email")]
        public string _Email { get; private set; }
        [JsonInclude]
        [JsonPropertyName("City")]
        public string _City { get; private set; }
        [JsonInclude]
        [JsonPropertyName("Description")]
        public string _Description { get; private set; }
        [JsonInclude]
        [JsonPropertyName("Distant")]
        public bool _Distant { get; private set; }
        [JsonInclude]
        [JsonPropertyName("Personal_qualities")]
        public List<string> _Personal_qualities { get; private set; }
        [JsonInclude]
        [JsonPropertyName("Skills")]
        public List<string> _Skills { get; private set; }
        [JsonInclude]
        [JsonPropertyName("Status")]
        Dictionary<int, string> _Status = new Dictionary<int, string>
        {
            {1,"В работе" },
            {2,"Назначено собеседование" },
            {3,"Принят" },
            {4,"Отклонен" }
        };
        [JsonInclude]
        [JsonPropertyName("Sitizenship")]
        Dictionary<int, string> _Sitizenship = new Dictionary<int, string>
        {
            {1,"Российская Федерация" },
            {2,"Другое" }
        };
        [JsonInclude]
        [JsonPropertyName("Shedule")]
        Dictionary<int, string> _Shedule = new Dictionary<int, string>
        {
            {1,"Полный день" },
            {2,"Сменный график" },
            {3,"Гибкий график" },
            {4,"Удаленная работа" },
            {5,"Вахтовый метод" }
        };
        [JsonInclude]
        [JsonPropertyName("Empoyment")]
        Dictionary<int, string> _Empoyment = new Dictionary<int, string>
        {
            {1,"Полная" },
            {2,"Частичная" },
            {3,"Стажировка" }
        };


        public clientsClass()
        {
            _Post = "";
            _Email = "";
            _City = "";
            _Description = "";
            _Distant = false;
            _Personal_qualities = new List<string>();
            _Skills = new List<string>();
            _Status = new Dictionary<int, string>();
            _Sitizenship = new Dictionary<int, string>();
            _Shedule = new Dictionary<int, string>();
            _Empoyment = new Dictionary<int, string>();

        }

        public clientsClass(string post, string email, string city, string description, bool distant, List<string> personal_qualities, List<string> skills,Dictionary<int, string> citizenship, Dictionary<int, string> employment, Dictionary<int, string> shedule, Dictionary<int, string> status)
        {
            _Post = post;
            _Email = email;
            _City = city;
            _Description = description;
            _Distant = distant;
            _Personal_qualities = personal_qualities;
            _Skills = skills;
            _Status = status;
            _Sitizenship = citizenship;
            _Shedule= shedule;
            _Empoyment= employment;
        }
       
    }
}
