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
using System.Windows.Shapes;
using KursCode.MVVM.View.Pages;

namespace KursCode.MVVM.View.Windows.Main
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Page currentPage;

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

        private void fullScreen_MauseLeftButtonDrag(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if(this.WindowState != WindowState.Maximized)
                {
                    this.WindowState = WindowState.Maximized;
                }
                else
                {
                    this.WindowState = WindowState.Normal;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void worker_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (!(mainFrame.Content is WorkersPage))
            {
                currentPage = new WorkersPage();
                mainFrame.Navigate(currentPage);
            }
        }

        private void corp_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (!(mainFrame.Content is VacancyPage))
            {
                currentPage = new VacancyPage();
                mainFrame.Navigate(currentPage);
            }
        }
    }
}
