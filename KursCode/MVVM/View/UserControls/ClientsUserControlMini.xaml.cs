using Clients;
using System;
using System.Collections;
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
using System.Windows.Shapes;
using System.Drawing;
using System;
using System.Drawing.Imaging;


namespace KursCode.MVVM.View.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ClientsUserControlMini.xaml
    /// </summary>
    public partial class ClientsUserControlMini : UserControl
    {
        public ClientsUserControlMini()
        {
            InitializeComponent();
        }

        private Image ConverImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);

            Image image;
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                Image image = Image.FromStream(ms);
            }

            return image;
        }

        public void SetData(workerClass data)
        {
            this.Surname.Text = data._Surname;
            this.Name.Text = data._WorkerName;
            this.Post.Text = data._Post;
        }
    }
}
