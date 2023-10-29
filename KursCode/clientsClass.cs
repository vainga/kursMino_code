using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients
{
    abstract class clientsClass
    {
        private string Name;
        private string Post;
        private string Email;
        private string City;
        private bool Distant;

        public clientsClass(string name, string post, string email, string city, bool distant)
        {
            Name = name;
            Post = post;
            Email = email;
            City = city;
            Distant = distant;
        }

        

    }
}
