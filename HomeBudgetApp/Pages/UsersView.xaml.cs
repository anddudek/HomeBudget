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
using HomeBudgetApp.Helpers;
using LibHomeBudget.Operations;
using HomeBudgetApp.Wizards;

namespace HomeBudgetApp.Pages
{
    /// <summary>
    /// Interaction logic for UsersView.xaml
    /// </summary>
    public partial class UsersView : UserControl, INotifyPropertyChanged
    {
        public UsersView()
        {
            InitializeComponent();
            DataContext = this;
            MWContainer.UsP = this;
        }

        public string SelectedName { get; set; }

        public List<string> UsersList
        {
            get
            {
                return UserOperations.GetAllUsersList();
            }
        }

        public void UpdateCommands()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        public bool CanCreateNewUser()
        {
            return Properties.Settings.Default.CurrentLoginUser != "LoggedOut"; ;
        }

        public void CreateNewUser()
        {
            CreateNewUserWizard cnu = new CreateNewUserWizard();
            cnu.Show();
        }

        public bool CanChangePassword()
        {
            return Properties.Settings.Default.CurrentLoginUser != "LoggedOut"; ;
        }

        public void ChangePassword()
        {
            if (String.IsNullOrWhiteSpace(SelectedName))
            {
                return;
            }
            ChangePasswordWizard cp = new ChangePasswordWizard();
            cp.UserName = SelectedName;
            cp.Show();
        }

        public ICommand CreateNewUserCommand { get { return new RelayCommand(CreateNewUser, CanCreateNewUser); } }

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
