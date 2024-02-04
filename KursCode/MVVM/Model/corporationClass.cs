using KursCode;
using Microsoft.Data.Sqlite;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using System.IO;
using KursCode.Data;
using KursCode.MVVM.Model;
using System.Collections.ObjectModel;
using KursCode.Interfaces;

namespace Clients
{
    [Serializable]
    public class corporationClass : ICorporation
    {
        [JsonInclude]
        [JsonPropertyName("CorporationID")]
        private int _corporationId;
        public int CorporationId
        {
            get { return _corporationId; }
        }

        [JsonInclude]
        [JsonPropertyName("UserId")]
        private int _userId;
        public int UserId
        {
            get { return _userId; }
        }

        [JsonInclude]
        [JsonPropertyName("CorporationName")]
        private string _corporationName;
        public string CorporationName
        {
            get 
            {
                return _corporationName;
            }
        }

        [JsonInclude]
        [JsonPropertyName("Vacancies")]
        private List<vacancyClass> _vacancies;
        public List<vacancyClass> Vacancies
        {
            get
            {
                return _vacancies;
            }
        }

        public corporationClass(int corporationId, int userId, string corporationName, List<vacancyClass> vacancies)
        {
            _corporationId = corporationId;
            _userId = userId;
            _corporationName = corporationName;
            _vacancies = vacancies;
        }


    }
}
