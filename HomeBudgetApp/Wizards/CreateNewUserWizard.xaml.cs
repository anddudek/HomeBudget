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
using System.ComponentModel;
using LibHomeBudget.Operations;
using HomeBudgetApp.Helpers;

namespace HomeBudgetApp.Wizards
{
    /// <summary>
    /// Interaction logic for CreateNewUserWizard.xaml
    /// </summary>
    public partial class CreateNewUserWizard : Window, INotifyPropertyChanged
    {
        public CreateNewUserWizard()
        {
            InitializeComponent();
            DataContext = this;
        }

        private string _UserName;
        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
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
            }
        }
        
        public string Password
        {
            get
            {
                return PasswordBox.Password;
            }
        }
        
        public string PasswordCheck
        {
            get
            {
                return PasswordCheckBox.Password;
            }
        }

        private bool CanCreateUser()
        {
            return true;
        }

        private void CreateUser()
        {
            if (String.IsNullOrWhiteSpace(Login) && String.IsNullOrWhiteSpace(UserName) && String.IsNullOrWhiteSpace(Password) && String.IsNullOrWhiteSpace(PasswordCheck) && String.Equals(Password, PasswordCheck))
            {
                return;
            }
            foreach (string log in UserOperations.GetAllUsersList())
            {
                if (log.ToUpper().Equals(Login.ToUpper()))
                {
                   return;
                }
            }
            UserOperations.CreateNewUser(Login, UserName, Password);
            this.Close();
        }

        private bool CanCancel()
        {
            return true;
        }

        private void Cancel()
        {
            this.Close();
        }

        public ICommand CancelCommand { get { return new RelayCommand(Cancel, CanCancel); } }

        public ICommand CreateUserCommand { get { return new RelayCommand(CreateUser, CanCreateUser); } }

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
