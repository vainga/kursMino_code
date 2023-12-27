using Clients;
using KursCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using KursCode.MVVM.Model.Managers;

namespace KursCode.MVVM.ViewModel
{
    public class clientsViewModel : baseViewModel
    {  
        private Dictionary<int, string> _Citizenship = new Dictionary<int, string>
        {
            {1,"Российская Федерация" },
            {2,"Другое" }
        };

        public Dictionary<int, string> Citizenship
        {
            get { return _Citizenship; }
        }

        private Dictionary<int, string> _Shedule = new Dictionary<int, string>
        {
            {1,"Полный день" },
            {2,"Сменный график" },
            {3,"Гибкий график" },
            {4,"Удаленная работа" },
            {5,"Вахтовый метод" }
        };

        public Dictionary<int, string> Shedule
        {
            get { return _Shedule; }
        }

        Dictionary<int, string> _Empoyment = new Dictionary<int, string>
        {
            {1,"Полная" },
            {2,"Частичная" },
            {3,"Стажировка" }
        };
        public Dictionary<int, string> Empoyment
        {
            get { return _Empoyment; }
        }

        private ObservableCollection<string> _skills;
        public ObservableCollection<string> Skills
        {
            get { return _skills; }
            set
            {
                if (_skills != value)
                {
                    _skills = value;
                    OnPropertyChanged(nameof(Skills));
                }
            }
        }

        private ObservableCollection<string> _qualities;
        public ObservableCollection<string> Qualities
        {
            get { return _qualities; }
            set
            {
                if (_qualities != value)
                {
                    _qualities = value;
                    OnPropertyChanged(nameof(Qualities));
                }
            }
        }

        private ObservableCollection<TextBox> textBoxListQualities;
        public ObservableCollection<TextBox> TextBoxListQualities
        {
            get { return textBoxListQualities; }
            set
            {
                if (textBoxListQualities != value)
                {
                    textBoxListQualities = value;
                    OnPropertyChanged(nameof(TextBoxListQualities));
                }
            }
        }

        private ObservableCollection<TextBox> textBoxListSkills;
        public ObservableCollection<TextBox> TextBoxListSkills
        {
            get { return textBoxListSkills; }
            set
            {
                if (textBoxListSkills != value)
                {
                    textBoxListSkills = value;
                    OnPropertyChanged(nameof(TextBoxListSkills));
                }
            }
        }

        private string _post;
        public string Post
        {
            get { return _post; }
            set
            {
                if (_post != value)
                {
                    _post = value;
                    OnPropertyChanged(nameof(Post));
                }
            }
        }

        private string _location;
        public string Location
        {
            get { return _location; }
            set
            {
                if (_location != value)
                {
                    _location = value;
                    OnPropertyChanged(nameof(Location));
                }
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }


        private string _cityzenship;
        public string SelectedCitizenship
        {
            get { return _cityzenship; }
            set
            {
                if (_cityzenship != value)
                {
                    _cityzenship = value;
                    OnPropertyChanged(nameof(SelectedCitizenship));
                }
            }
        }

        private string _shedule;
        public string SelectedShedule
        {
            get { return _shedule; }
            set
            {
                if (_shedule != value)
                {
                    _shedule = value;
                    OnPropertyChanged(nameof(SelectedShedule));
                }
            }
        }

        private string _emplyment;
        public string SelectedEmpoyment
        {
            get { return _emplyment; }
            set
            {
                if (_emplyment != value)
                {
                    _emplyment=value;
                    OnPropertyChanged(nameof(SelectedEmpoyment));
                }
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }
    }
}
