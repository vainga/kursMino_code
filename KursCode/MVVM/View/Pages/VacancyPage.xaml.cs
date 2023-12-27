using KursCode.MVVM.View.Windows.Dialog;
using KursCode.MVVM.ViewModel;
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
    /// Логика взаимодействия для VacancyPagexaml.xaml
    /// </summary>
    public partial class VacancyPage : Page
    {
        private int _UserId { get; }

        public VacancyPage(int userId)
        {
            InitializeComponent();
            _UserId = userId;
        }

        private void add_Button(object sender, RoutedEventArgs e)
        {
            AddVacancy vacancy = new AddVacancy(_UserId);
            vacancy.ShowDialog();
            //_viewModel.UpdateMiniWorkers();
        }
    }
}
