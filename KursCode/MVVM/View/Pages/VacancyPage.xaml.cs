using KursCode.MVVM.View.UserControls;
using KursCode.MVVM.View.Windows.Dialog;
using KursCode.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    public partial class VacancyPage : Page
    {
        //    private int _UserId { get; }
        //    private VacansyPageViewModel _viewModel;
        //    private ClientsUserControlMax clientsUserControlMax;

        //    public VacancyPage(int userId)
        //    {
        //        InitializeComponent();
        //        _UserId = userId;
        //        _viewModel = new VacansyPageViewModel();
        //        _viewModel.UserId = userId;
        //        _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        //        LoadDataAndMiniWorkers();
        //        LoadMiniWorkers();
        //        maxWorker.Visibility = Visibility.Collapsed;
        //        clientsUserControlMax = new ClientsUserControlMax(userId);
        //    }

        //    private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //    {
        //        if (e.PropertyName == nameof(_viewModel.MiniWorkers))
        //        {
        //            LoadMiniWorkers();
        //        }
        //    }

        //    private void LoadDataAndMiniWorkers()
        //    {
        //        _viewModel.LoadDataFromJson();
        //        LoadMiniWorkers();
        //    }

        //    private void LoadMiniWorkers()
        //    {
        //        miniWorkers.Children.Clear();

        //        foreach (var userControlMini in _viewModel.MiniWorkers)
        //        {
        //            if (userControlMini.Parent != null)
        //            {
        //                var parentPanel = (Panel)userControlMini.Parent;
        //                parentPanel.Children.Remove(userControlMini);
        //            }
        //            userControlMini.MouseDown += (sender, e) => ShowMaxWorkerControl(userControlMini);
        //            miniWorkers.Children.Add(userControlMini);
        //        }
        //    }

        //    private void ShowMaxWorkerControl(ClientsUserControlMini selectedMiniWorker)
        //    {
        //        var userControlMax = _viewModel._ClientsUserControlMax;
        //        maxWorker.Visibility = Visibility.Visible;

        //        var currentParent = (Panel)userControlMax.Parent;
        //        if (currentParent != null)
        //            currentParent.Children.Remove(userControlMax);

        //        maxWorker.Children.Clear();
        //        maxWorker.Children.Add(userControlMax);
        //    }

        //    private void add_Button(object sender, RoutedEventArgs e)
        //    {
        //        AddVacancy vacancy = new AddVacancy(_UserId);
        //        vacancy.ShowDialog();
        //        _viewModel.UpdateMiniWorkers();
        //    }
    }
}
