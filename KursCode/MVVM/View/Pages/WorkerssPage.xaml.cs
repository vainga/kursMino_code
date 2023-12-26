using KursCode.MVVM.View.Windows.Dialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KursCode.MVVM.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для WorkersPage.xaml
    /// </summary>
    public partial class WorkersPage : Page
    {
        private int _UserId { get; }
        public WorkersPage(int userId)
        {
            InitializeComponent();
            _UserId = userId;
        }

        private void add_button(object sender, RoutedEventArgs e)
        {
            AddWorker worker = new AddWorker(_UserId);
            worker.ShowDialog();
        }
    }
}
