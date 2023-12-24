using KursCode.MVVM.View.Windows.Main;
using KursCode.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KursCode.View.Windows.Main
{
    /// <summary>
    /// Логика взаимодействия для EnterWindow.xaml
    /// </summary>
    /// 
public partial class EnterWindow : Window
    {
        bool isRegistration = false;
        private EnterViewModel viewModel;

        public EnterWindow()
        {
            InitializeComponent();
            viewModel = new EnterViewModel();
            viewModel.SuccessfulLogin += ViewModel_SuccessfulLogin;
            DataContext = viewModel;
        }

        private void ViewModel_SuccessfulLogin(object sender, EventArgs e)
        {
            Close();
        }

        private void drugWindow_LeftButtonDrag(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception ex)
            {

            }
        }

        private void closeApp_MauseLeftButtonDrag(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void collapseApp_MauseLeftButtonDrag(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {

            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is EnterViewModel viewModel)
            {
                var passwordBox = sender as PasswordBox;
                viewModel.Password = new NetworkCredential("", passwordBox.SecurePassword).Password;
            }
        }

        public void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is TextBlock textBlock && DataContext is EnterViewModel viewModel)
            {
                viewModel.ExecuteTextBlockClick();
            }
        }
    }
}
