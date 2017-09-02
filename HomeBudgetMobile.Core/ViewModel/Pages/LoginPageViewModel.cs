using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using HomeBudgetMobile.Helpers;
using System.Windows.Input;
using Xamarin.Forms;

namespace HomeBudgetMobile.ViewModel.Pages
{
    public class LoginPageViewModel : ViewModelBase
    {
        private string _login;
        public string Login
        {
            get { return _login; }
            set { Set(() => Login, ref _login, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { Set(() => Password, ref _password, value); }
        }

        private string _currentUser;
        public string CurrentUser
        {
            get { return _currentUser; }
            set { Set(() => CurrentUser, ref _currentUser, value); }
        }

        public ICommand LogOutCommand { get; private set; }

        private void LogOutAction()
        {
            if (CurrentUser != "Wylogowano")
            {
                CurrentUser = "Wylogowano";
                Application.Current.Properties["CurrentUser"] = CurrentUser;
                MessagingCenter.Send<ViewModel.Pages.LoginPageViewModel>(this, "LoggedOut");
            }
        }

        public ICommand LoginCommand { get; private set; }

        private void LoginAction()
        {
            if (Password == null || Login == null)
            {
                MessagingCenter.Send<ViewModel.Pages.LoginPageViewModel>(this, "LoggingError");
            }
            if (LoginOperations.TryLogin(Login, Password))
            {
                CurrentUser = Login;
                Application.Current.Properties["CurrentUser"] = CurrentUser;
                Login = string.Empty;
                Password = string.Empty;
                MessagingCenter.Send<ViewModel.Pages.LoginPageViewModel>(this, "LoggedIn");
            }
            else
            {
                MessagingCenter.Send<ViewModel.Pages.LoginPageViewModel>(this, "LoggingError");
            }
        }

        public LoginPageViewModel()
        {
            if (Application.Current.Properties.ContainsKey("CurrentUser"))
            {
                CurrentUser = Application.Current.Properties["CurrentUser"] as string;
            }
            else
            {
                CurrentUser = "Wylogowano";
            }
            LogOutCommand = new RelayCommand(LogOutAction);
            LoginCommand = new RelayCommand(LoginAction);            
        }
    }
}
