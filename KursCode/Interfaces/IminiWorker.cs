using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.Interfaces
{
    public interface IminiWorker : InanoWorker
    {
        ObservableCollection<string> _Skills { get; }
    }
}
