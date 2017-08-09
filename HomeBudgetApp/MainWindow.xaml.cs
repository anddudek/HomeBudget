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
using MahApps.Metro.Controls;
using HomeBudgetApp.Helpers;
using System.ComponentModel;
using LibHomeBudget.Operations;

namespace HomeBudgetApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        public MainWindow()
        {
            Initialized = false;
            CurrentUserMessage = "Zalogowano jako: " + Properties.Settings.Default.CurrentLoginUser;
            MWContainer.MW = this;
            var msgLog = UserOperations.GetLastMessageCreatorLogin();
            var curLogMsg = UserOperations.DidUserReadMessage(Properties.Settings.Default.CurrentLoginUser);
            if (!msgLog.Equals(Properties.Settings.Default.CurrentLoginUser) && !curLogMsg)
            {
                BadgeVisible = true;
            }
            else
            {
                BadgeVisible = false;
            }

            InitializeComponent();
            DataContext = this;
            Initialized = true;    
        }

        public bool Initialized { get; set; } 

        private bool _isHamburgerMenuPaneOpen;
        public bool IsHamburgerMenuPaneOpen
        {
            get
            {
                return _isHamburgerMenuPaneOpen;
            }
            set
            {
                _isHamburgerMenuPaneOpen = value;
                OnPropertyChanged("IsHamburgerMenuPaneOpen");
            }
        }

        public MahApps.Metro.Controls.HamburgerMenuGlyphItem HMenuContent { get; set; }

        private string _CurrentUserMessage;
        public string CurrentUserMessage
        {
            get
            {
                return _CurrentUserMessage;
            }
            set
            {
                _CurrentUserMessage = value;
                OnPropertyChanged(CurrentUserMessage);
            }
        }

        private bool CanClickHMenu()
        {
            return true;
        }

        public void ClickHMenu(object param)
        {
            //Options clicked
            if (param.ToString().Equals("Options"))
            {
                HMenuContent.Tag = new HomeBudgetApp.Pages.MessageView();
                IsHamburgerMenuPaneOpen = false;
                return;
            }
            // Else menuItem clicked
            var a = ((param as MahApps.Metro.Controls.HamburgerMenuGlyphItem).Glyph);
            switch (a)
            {
                case "pieChart":
                    HMenuContent.Tag = new HomeBudgetApp.Pages.SummaryView();
                    break;
                case "user":
                    HMenuContent.Tag = new HomeBudgetApp.Pages.LoginView();
                    break;
                case "areaChart":
                    HMenuContent.Tag = new HomeBudgetApp.Pages.HistoryView();
                    break;
                case "search":
                    HMenuContent.Tag = new HomeBudgetApp.Pages.SearchView();
                    break;
                case "creditCard":
                    HMenuContent.Tag = new HomeBudgetApp.Pages.LimitView();
                    break;
                case "users":
                    HMenuContent.Tag = new HomeBudgetApp.Pages.UsersView();
                    break;
                case "plusSquare":
                    HMenuContent.Tag = new HomeBudgetApp.Pages.TransactionView();
                    break;
                default:
                    break;
            }            
            IsHamburgerMenuPaneOpen = false;
        }

        public ICommand HMenuClick { get { return new RelayCommandP(p => ClickHMenu(p), CanClickHMenu); } }

        private bool _badgeVisible;
        public bool BadgeVisible
        {
            get { return _badgeVisible; }
            set
            {
                if (_badgeVisible != value)
                {
                    _badgeVisible = value;
                    OnPropertyChanged("BadgeVisible");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public class BindingProxy : Freezable
    {
        // Using a DependencyProperty as the backing store for Data. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataProperty = DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));

        public object Data
        {
            get { return (object)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy();
        }
    }
}
