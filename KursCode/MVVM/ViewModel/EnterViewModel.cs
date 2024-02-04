using Clients;
using KursCode.MVVM.View.Windows.Main;
using KursCode.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace KursCode.MVVM.ViewModel
{
    public class EnterViewModel : INotifyPropertyChanged
    {
        private string _buttonContent = "Войти";
        private string _textBlockContent = "Зарегистрироваться";
        private Visibility _secondTextBlockVisibility = Visibility.Visible;

        private string _errorMessageContent = "Ошибка регистрации!";
        private Visibility _errorMessageVisibility = Visibility.Collapsed;

        public event EventHandler SuccessfulLogin;

        private IUser _user;
        public IUser Users
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        private int defaultFontSize = 24;
        public int ButtonContentFontSize
        {
            get { return ButtonContent == "Зарегистрироваться" ? 20 : defaultFontSize; }
            set
            {
                if (defaultFontSize != value)
                {
                    defaultFontSize = value;
                    OnPropertyChanged(nameof(ButtonContentFontSize));
                }
            }
        }

        public string Password
        {
            get { return Users._Password; }
            set
            {
                if (Users._Password != value)
                {
                    Users = new User(Users._Login, value);
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public string Login
        {
            get { return Users._Login; }
            set
            {
                if (Users._Login != value)
                {
                    Users = new User(value, Users._Password);
                    OnPropertyChanged(nameof(Login));
                }
            }
        }

        public string ButtonContent
        {
            get { return _buttonContent; }
            set
            {
                if (_buttonContent != value)
                {
                    _buttonContent = value;
                    OnPropertyChanged(nameof(ButtonContent));
                    OnPropertyChanged(nameof(SecondTextBlockVisibility));
                    OnPropertyChanged(nameof(ButtonContentFontSize));
                }
            }
        }

        public string TextBlockContent
        {
            get { return _textBlockContent; }
            set
            {
                if (_textBlockContent != value)
                {
                    _textBlockContent = value;
                    OnPropertyChanged(nameof(TextBlockContent));
                }
            }
        }

        public string ErrorMessageContent
        {
            get { return _errorMessageContent; }
            set
            {
                if (_errorMessageContent != value)
                {
                    _errorMessageContent = value;
                    OnPropertyChanged(nameof(ErrorMessageContent));
                }
            }
        }

        public Visibility ErrorMessageVisibility
        {
            get { return _errorMessageVisibility; }
            set
            {
                if (_errorMessageVisibility != value)
                {
                    _errorMessageVisibility = value;
                    OnPropertyChanged(nameof(ErrorMessageVisibility));
                }
            }
        }

        public Visibility SecondTextBlockVisibility
        {
            get { return ButtonContent == "Зарегистрироваться" ? Visibility.Collapsed : _secondTextBlockVisibility; }
            set
            {
                if (_secondTextBlockVisibility != value)
                {
                    _secondTextBlockVisibility = value;
                    OnPropertyChanged(nameof(SecondTextBlockVisibility));
                }
            }
        }

        private void OnSuccessfulLogin()
        {
            SuccessfulLogin?.Invoke(this, EventArgs.Empty);
        }

        private ICommand _buttonCommand;
        public ICommand RegisterCommand { get; }
        public ICommand EnterCommand { get; }
        public ICommand ButtonCommand
        {
            get
            {
                if (_buttonCommand == null)
                {
                    _buttonCommand = new RelayCommand(ExecuteButtonCommand);
                }
                return _buttonCommand;
            }
        }

        private void ExecuteButtonCommand()
        {
            if (ButtonContent == "Войти")
            {
                ExecuteLogin();
            }
            else if (ButtonContent == "Зарегистрироваться")
            {
                ExecuteRegister();
            }
        }

        public EnterViewModel()
        {
            Users = new User("", "");
            RegisterCommand = new RelayCommand(ExecuteRegister, CanExecuteRegister);
            EnterCommand = new RelayCommand(ExecuteLogin, CanExecuteLogin);
        }

        private void ExecuteRegister()
        {
            try
            {
                bool registerResult = Users.Registration();
                if (registerResult)
                {
                    OnSuccessfulLogin();
                }
                else
                {
                    _errorMessageVisibility = Visibility.Visible;

                    OnPropertyChanged(nameof(ErrorMessageContent));
                    OnPropertyChanged(nameof(ErrorMessageVisibility));
                }
            }
            catch (ArgumentException ex)
            {
                _errorMessageContent = ex.Message;
                _errorMessageVisibility = Visibility.Visible;

                OnPropertyChanged(nameof(ErrorMessageContent));
                OnPropertyChanged(nameof(ErrorMessageVisibility));
            }
        }

        private bool CanExecuteRegister()
        {
            return !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password);
        }

        private void ExecuteLogin()
        {
            try
            {
                bool EnterResult = Users.Enter();
                if (EnterResult)
                {
                    OnSuccessfulLogin();
                }
                else
                {
                    _errorMessageVisibility = Visibility.Visible;

                    OnPropertyChanged(nameof(ErrorMessageContent));
                    OnPropertyChanged(nameof(ErrorMessageVisibility));
                }
            }
            catch (ArgumentException ex)
            {
                _errorMessageContent = ex.Message;
                _errorMessageVisibility = Visibility.Visible;

                OnPropertyChanged(nameof(ErrorMessageContent));
                OnPropertyChanged(nameof(ErrorMessageVisibility));
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

        public void ExecuteTextBlockClick()
        {
            if (TextBlockContent == "Зарегистрироваться")
            {
                TextBlockContent = "Войти";
                ButtonContent = "Зарегистрироваться";
            }
            else if (TextBlockContent == "Войти")
            {
                ButtonContent = "Войти";
                TextBlockContent = "Зарегистрироваться";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
