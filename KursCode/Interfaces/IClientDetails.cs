using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Interfaces
{
    public interface IClientDetails
    {
        string _Description { get; }
        ObservableCollection<string> _Personal_qualities { get; }
        ObservableCollection<string> _Skills { get; }
    }
}
