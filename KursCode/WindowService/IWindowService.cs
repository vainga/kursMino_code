using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using KursCode.MVVM.ViewModel;

namespace KursCode.WindowServices
{
    public interface IWindowService
    {
        void ShowWindow<T>() where T : Window;
        void CloseWindow<T>() where T : Window;
    }
}
