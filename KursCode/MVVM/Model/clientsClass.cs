using KursCode.Interfaces;
using KursCode.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Clients
{
    [Serializable]
    public abstract class clientsClass : IClients
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
        [JsonPropertyName("Personal_qualities")]
        public ObservableCollection<string> _Personal_qualities { get; private set; }
        [JsonInclude]
        [JsonPropertyName("Skills")]
        public ObservableCollection<string> _Skills { get; private set; }
        [JsonInclude]
        [JsonPropertyName("Status")]
        public string _Status { get; private set; }
        [JsonInclude]
        [JsonPropertyName("Sitizenship")]
        public string _Citizenship { get; private set; }
        [JsonInclude]
        [JsonPropertyName("Shedule")]
        public string _Shedule { get; private set; }
        [JsonInclude]
        [JsonPropertyName("Empoyment")]
        public string _Empoyment { get; private set; }

        public clientsClass()
        {
            _Post = "";
            _Email = "";
            _City = "";
            _Description = "";
            _Personal_qualities = new ObservableCollection<string>();
            _Skills = new ObservableCollection<string>();
            _Status = "";
            _Citizenship = "";
            _Shedule = "";
            _Empoyment = "";

        }

        public clientsClass(string post, string email, string city, string description, ObservableCollection<string> personal_qualities, ObservableCollection<string> skills,string citizenship, string employment, string shedule, string status)
        {
            _Post = post;
            _Email = email;
            _City = city;
            _Description = description;
            _Personal_qualities = personal_qualities;
            _Skills = skills;
            _Status = status;
            _Citizenship = citizenship;
            _Shedule= shedule;
            _Empoyment= employment;
        }
       
    }
}
