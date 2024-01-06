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
using MaterialDesignThemes.Wpf;

namespace KursCode.MVVM.View.Windows.Main
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _UserId { get; }

        public MainWindow(int userId)
        {
            InitializeComponent();
            _UserId = userId;
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
            SetIconColor(workerIcon, Colors.DeepSkyBlue);
            if (!(mainFrame.Content is WorkersPage))
            {
                currentPage = new WorkersPage(_UserId);
                mainFrame.Navigate(currentPage);
            }
        }

        private void corp_ButtonClick(object sender, RoutedEventArgs e)
        {
            SetIconColor(corpIcon, Colors.DeepSkyBlue);
            if (!(mainFrame.Content is VacancyPage))
            {
                currentPage = new VacancyPage(_UserId);
                mainFrame.Navigate(currentPage);

            }
        }

        private void SetIconColor(PackIcon icon, Color color)
        {
            icon.Foreground = new SolidColorBrush(color);

            ResetIconColors(icon);
        }

        private void ResetIconColors(PackIcon currentIcon)
        {
            if (currentIcon != workerIcon)
                workerIcon.Foreground = new SolidColorBrush(Colors.DarkBlue);

            if (currentIcon != corpIcon)
                corpIcon.Foreground = new SolidColorBrush(Colors.DarkBlue);

        }

        private void inter_Button_Click(object sender, RoutedEventArgs e)
        {
            SetIconColor(calendarIcon, Colors.DeepSkyBlue);
            if (!(mainFrame.Content is InterviewPage))
            {
                currentPage = new InterviewPage(_UserId);
                mainFrame.Navigate(currentPage);
            }
        }
    }
}
