using Clients;
using KursCode.Data;
using KursCode.MVVM.View.UserControls;
using KursCode.MVVM.View.Windows.Dialog;
using System;
using System.Collections.Generic;
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

        public WorkersPage(int userId)
        {
            InitializeComponent();
            _UserId = userId;
            dbHelper = new DatabaseHelper(GetWorkerDBPath(userId));
            LoadDataFromJson();
        }

        private static string GetWorkerDBPath(int userid)
        {
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string parentPath = Directory.GetParent(executablePath).FullName;
            string dataFolderPath = Path.Combine(parentPath, "Data");
            string userFolderPath = Path.Combine(dataFolderPath, "UserData");
            string workerDbPath = Path.Combine(userFolderPath, $"{userid}_ID_User");
            Directory.CreateDirectory(workerDbPath);
            return workerDbPath;
        }


        private void add_button(object sender, RoutedEventArgs e)
        {
            AddWorker worker = new AddWorker(_UserId);
            worker.Closed += WorkerClosed;
            worker.ShowDialog();
        }

        private void LoadDataFromJson()
        {
            string workerFolderPath = GetWorkerDBPath(_UserId);
            string workerDataFilePath = Path.Combine(workerFolderPath, "worker.json");
            List<workerClass> dataList = dbHelper.GetAllEntities<workerClass>(workerDataFilePath);

            foreach (var data in dataList)
            {
                ClientsUserControlMini userControlMini = new ClientsUserControlMini();
                userControlMini.SetData(data);

                userControlMini.VerticalAlignment = VerticalAlignment.Top;
                Thickness margin = new Thickness(10, 0, 10, 15);
                userControlMini.Margin = margin;

                userControlMini.MouseEnter += DynamicUserControl_MouseEnter;
                userControlMini.MouseLeave += DynamicUserControl_MouseLeave;
                userControlMini.MouseDown += DynamicUserControl_MouseDown;

                miniWorkers.Children.Add(userControlMini);
            }
        }

        private void DynamicUserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ClientsUserControlMini clickedControl = (ClientsUserControlMini)sender;

            if (currentSelectedControl != null && currentSelectedControl != clickedControl)
            {
                currentSelectedControl.mainBorder.BorderBrush = Brushes.Black;
            }

            currentSelectedControl = clickedControl;
            currentSelectedControl.mainBorder.BorderBrush = Brushes.Blue;
        }

        private void DynamicUserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            ((ClientsUserControlMini)sender).SetDarkBackground();
        }

        private void DynamicUserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            ((ClientsUserControlMini)sender).RestoreBackground();
        }

        private void WorkerClosed(object sender, EventArgs e)
        {
        }

    }
}
