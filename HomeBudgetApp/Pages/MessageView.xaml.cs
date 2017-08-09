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
    /// Interaction logic for MessageView.xaml
    /// </summary>
    public partial class MessageView : UserControl, INotifyPropertyChanged
    {
        public MessageView()
        {
            Message = SettingOperations.GetMessage();
            if (CanUpdateMessage() && MWContainer.MW.Initialized)
            {
                UserOperations.UserReadMessage(Properties.Settings.Default.CurrentLoginUser);
                MWContainer.MW.BadgeVisible = false;
            }
            InitializeComponent();
            DataContext = this;
        }

        public string Message { get; set; }

        public string LastMessageCreatorID
        {
            get
            {
                return UserOperations.GetLastMessageCreatorLogin();
            }
        }

        private bool CanUpdateMessage()
        {
            return Properties.Settings.Default.CurrentLoginUser != "LoggedOut";
        }        

        private void UpdateMessage()
        {
            SettingOperations.ChangeMessage(Message, Properties.Settings.Default.CurrentLoginUser);
            OnPropertyChanged("LastMessageCreatorID");            
        }

        public ICommand UpdateMessageCommand { get { return new RelayCommand(UpdateMessage, CanUpdateMessage); } }

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
