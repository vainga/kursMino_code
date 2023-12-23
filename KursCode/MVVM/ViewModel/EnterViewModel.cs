using KursCode.MVVM.View.Windows.Main;
using KursCode.View;
using KursCode.WindowServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace KursCode.MVVM.ViewModel
{
    public class EnterViewModel: INotifyPropertyChanged
    {
        private User user;

        private string _password;
        public string Password
        {
            get { return _password; } 
            set {
                    if (_password != value)
                    {
                        _password = value;
                        OnPropertyChanged(nameof(Password));
                    }
                }
        }

        private string _login;
        public string Login {  get { return _login; }
            set {
                    if (_login != value)
                    {
                        _login = value;
                        OnPropertyChanged(nameof(Login));
                    }
                } 
        }

        public ICommand RegisterCommand { get; }
        public ICommand EnterCommand { get; }

        public EnterViewModel()
        {
            user = new User();
            RegisterCommand = new RelayCommand(ExecuteRegister, CanExecuteRegister);
            EnterCommand = new RelayCommand(ExecuteLogin, CanExecuteLogin);
        }

        private void ExecuteRegister()
        {
            bool registerResult = user.Registration(Login, Password);
            
        }

        private bool CanExecuteRegister()
        {
            return !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password);
        }

        private void ExecuteLogin()
        {
            bool EnterResult = user.Enter(Login, Password);
            if(EnterResult)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
        }
        public void CloseCurrentWindow()
        {
            var activeWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            activeWindow?.Close();
        }
        private bool CanExecuteLogin()
        {
            return !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
