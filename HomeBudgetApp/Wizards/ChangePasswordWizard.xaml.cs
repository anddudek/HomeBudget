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
    /// Interaction logic for ChangePasswordWizard.xaml
    /// </summary>
    public partial class ChangePasswordWizard : Window, INotifyPropertyChanged
    {
        public ChangePasswordWizard()
        {
            InitializeComponent();
            DataContext = this;
        }
        
        public string WindowName
        {
            get
            {
                return "Zmiana hasła: " + UserName;
            }
        }

        public string UserName { get; set; }

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

        private bool CanChangePassword()
        {
            return true;
        }

        private void ChangePassword()
        {
            if (String.IsNullOrWhiteSpace(Password) && String.IsNullOrWhiteSpace(PasswordCheck) && String.Equals(Password, PasswordCheck))
            {
                return;
            }
            UserOperations.ChangePassword(UserName, Password);
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

        public ICommand ChangePasswordCommand { get { return new RelayCommand(ChangePassword, CanChangePassword); } }

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
