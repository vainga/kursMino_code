using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients
{
    abstract class clientsClass
    {
        private string _Post { get; set; }
        private string _Email { get; set; }
        private string _City { get; set; }
        private string _Description { get; set; }
        private bool _Distant { get; set; }
        private List<string> _Personal_qualities { get; set; }
        private List<string> _Skills { get; set; }

        public clientsClass() 
        {
            _Post = "";
            _Email = "";
            _City = "";
            _Description = "";
            _Distant = false;
            _Personal_qualities = new List<string>();
            _Skills = new List<string>();

        }

        public clientsClass(string post, string email, string city, string description, bool distant, List<string> personal_qualities, List<string> skills)
        {
            _Post = post;
            _Email = email;
            _City = city;
            _Description = description;
            _Distant = distant;
            _Personal_qualities = personal_qualities;
            _Skills = skills;
        }

        public void EnterInformation()
        {
            int x=0;
            Console.Write("Должность: ");   _Post = Console.ReadLine();
            Console.Write("Email: ");       _Email = Console.ReadLine();
            Console.Write("Город: ");       _City = Console.ReadLine();
            Console.Write("Описание: ");    _Description = Console.ReadLine();
            Console.WriteLine("Согласен ли он на дистанционную работу: ");
            x=int.Parse(Console.ReadLine());
            if(x==1)
                _Distant = true;
            else
                 _Distant = false;
            Console.Write("Введите количество личных качеств: ");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите личные качества: ");
            for(int i=0; i<x; i++) 
            {
                _Personal_qualities.Add(Console.ReadLine());
            }
            Console.Write("Введите количество навыков: ");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите навыки: ");
            for (int i = 0; i < x; i++)
            {
                _Skills.Add(Console.ReadLine());
            }
        }

        

    }
}
