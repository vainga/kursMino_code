namespace Clients
{
    internal class corporationClass: clientsClass
    {
        private int _Work_experience_min { get; set; }
        private int _Work_experience_max { get; set; }
        private bool _Work_experience_need { get; set; }
        private int _Salary { get; set; }

        public corporationClass(string name, string post, string email, string city, string description, bool distant, List<string> personal_qualities, List<string> skills, int work_experience_min, int work_experience_max, 
            bool work_experience_need, int salary)
            : base(name, post, email, city, description, distant, personal_qualities, skills)
        {
            _Work_experience_max = work_experience_max;
            _Work_experience_min = work_experience_min;
            _Work_experience_need = work_experience_need;
            _Salary = salary;
        }

    }
}
