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
        [JsonPropertyName("_Post")]
        public string _Post { get; private set; }
        [JsonInclude]
        [JsonPropertyName("_Email")]
        public string _Email { get; private set; }
        [JsonInclude]
        [JsonPropertyName("_City")]
        public string _City { get; private set; }
        [JsonInclude]
        [JsonPropertyName("_Description")]
        public string _Description { get; private set; }
        [JsonInclude]
        [JsonPropertyName("_Distant")]
        public bool _Distant { get; private set; }
        [JsonInclude]
        [JsonPropertyName("_Personal_qualities")]
        public List<string> _Personal_qualities { get; private set; }
        [JsonInclude]
        [JsonPropertyName("_Skills")]
        public List<string> _Skills { get; private set; }
        [JsonInclude]
        [JsonPropertyName("_Citizenship")]
        public ClientCitizenship _Citizenship { get; private set; }
        [JsonInclude]
        [JsonPropertyName("_Empoyment")]
        public ClientEmployment _Employment { get; private set; }
        [JsonInclude]
        [JsonPropertyName("_Shedule")]
        public ClientShedule _Shedule { get; private set; }
        [JsonInclude]
        [JsonPropertyName("_Shedule")]
        public ClientStatus _Status { get; private set; }

        public clientsClass()
        {
            _Post = "";
            _Email = "";
            _City = "";
            _Description = "";
            _Distant = false;
            _Personal_qualities = new List<string>();
            _Skills = new List<string>();
            _Citizenship = new ClientCitizenship();
            _Employment = new ClientEmployment();
            _Status = new ClientStatus();
            _Shedule = new ClientShedule();
        }

        public clientsClass(string post, string email, string city, string description, bool distant, List<string> personal_qualities, List<string> skills, ClientCitizenship citizenship, ClientEmployment employment, ClientShedule shedule, ClientStatus status)
        {
            _Post = post;
            _Email = email;
            _City = city;
            _Description = description;
            _Distant = distant;
            _Personal_qualities = personal_qualities;
            _Skills = skills;
            _Citizenship = citizenship;
            _Employment = employment;
            _Status = status;
            _Shedule = shedule;
        }
       
    }
}
