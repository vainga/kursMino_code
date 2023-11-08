using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients
{
    abstract class clientsClass
    {
        private string _Name { get; set; }
        private string _Post { get; set; }
        private string _Email { get; set; }
        private string _City { get; set; }
        private string _Description { get; set; }
        private bool _Distant { get; set; }
        private List<string> _Personal_qualities { get; set; }
        private List<string> _Skills { get; set; }


        public clientsClass(string name, string post, string email, string city, string description, bool distant, List<string> personal_qualities, List<string> skills)
        {
            _Name = name;
            _Post = post;
            _Email = email;
            _City = city;
            _Description = description;
            _Distant = distant;
            _Personal_qualities = personal_qualities;
            _Skills = skills;
        }

        

    }
}
