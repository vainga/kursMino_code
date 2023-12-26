using KursCode.MVVM.ViewModel;
using MaterialDesignThemes.Wpf;
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

namespace KursCode.MVVM.View.UserControls
{
    public partial class ClientSkiil : UserControl
    {
        public ClientSkiil()
        {
            InitializeComponent();
        }

        public ClientSkiil(ClientSkillViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        public string GetText()
        {
            return itemText.Text;
        }
    }
}
