using KursCode.WindowServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KursCode.MVVM.ViewModel
{
    public class ViewModelBase
    {
        protected readonly IWindowService windowService;

        public ViewModelBase(IWindowService windowService)
        {
            this.windowService = windowService;
        }
    }
}
