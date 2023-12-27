using Clients;
using KursCode.Data;
using KursCode.MVVM.View.UserControls;
using KursCode.MVVM.View.Windows.Dialog;
using KursCode.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

namespace KursCode.MVVM.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для WorkersPage.xaml
    /// </summary>
    public partial class WorkersPage : Page
    {

        private ClientsUserControlMini currentSelectedControl;
        private int _UserId { get; }
        private DatabaseHelper dbHelper;
        private WorkersPage workersPage;
        private WorkersPageViewModel _viewModel;

        public WorkersPage(int userId)
        {
            InitializeComponent();
            _UserId = userId;
            _viewModel = new WorkersPageViewModel();
            _viewModel.UserId = userId;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged; // Подписка на событие изменения свойства
            LoadDataAndMiniWorkers();
            LoadMiniWorkers();
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.MiniWorkers))
            {
                LoadMiniWorkers();
            }
        }

        private void LoadDataAndMiniWorkers()
        {
            _viewModel.LoadDataFromJson();
            LoadMiniWorkers();
        }

        private void add_button(object sender, RoutedEventArgs e)
        {
            AddWorker worker = new AddWorker(_UserId);
            worker.ShowDialog();
            _viewModel.UpdateMiniWorkers();
        }
        private void LoadMiniWorkers()
        {
            miniWorkers.Children.Clear();

            foreach (var userControlMini in _viewModel.MiniWorkers)
            {
                if (userControlMini.Parent != null)
                {
                    var parentPanel = (Panel)userControlMini.Parent;
                    parentPanel.Children.Remove(userControlMini);
                }

                miniWorkers.Children.Add(userControlMini);
            }
        }
    }
}
