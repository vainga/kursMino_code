using KursCode.MVVM.View;
using KursCode.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KursCode.WindowServices
{
    public class WindowService : IWindowService
    {
        public void ShowWindow<T>() where T : Window
        {
            var window = Activator.CreateInstance<T>();
            window.Show();
        }

        public void CloseWindow<T>() where T : Window
        {
            var window = Application.Current.Windows.OfType<T>().FirstOrDefault();
            window?.Close();
        }
    }
}
