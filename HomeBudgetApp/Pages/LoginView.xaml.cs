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
using System.ComponentModel;
using LibHomeBudget.Operations;
using HomeBudgetApp.Helpers;

namespace HomeBudgetApp.Pages
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl, INotifyPropertyChanged
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = this;
        }

        private string _login;
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged("LoginBox");
            }
        }

        private string _loginBox;
        public string LoginBox
        {
            get
            {
                return Login;
            }
            set
            {
                _loginBox = value;
            }
        }

        public List<string> UserLogins
        {
            get
            {
                return UserOperations.GetAllUsersLoginList();
            }
        }

        private bool CanLoginF()
        {
            return true;
        }

        private void LoginF()
        {
            if (UserOperations.TryLogin(Login, _Password.Password))
            {
                MWContainer.MW.CurrentUserMessage = Login;
            }
            else
            {
                MessageBox.Show("Nieprawidłowy login / hasło", "Niepowodzenie");
            }
        }

        public ICommand LoginCommand { get { return new RelayCommand(LoginF, CanLoginF); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
