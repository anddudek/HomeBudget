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

namespace HomeBudgetApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        public MainWindow()
        {
            CurrentUserMessage = "Zalogowano jako: " + Properties.Settings.Default.CurrentLoginUser;
            MWContainer.MW = this;
            _badgeVisible = false;
            InitializeComponent();
            DataContext = this;            
        }

        public bool IsHamburgerMenuPaneOpen { get; set; }

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

        private void HamburgerMenu_OnItemClick(object sender, ItemClickEventArgs e)
        {
            // instead using binding Content="{Binding RelativeSource={RelativeSource Self}, Mode=OneWay, Path=SelectedItem}"
            // we can do this
            var a = ((MahApps.Metro.Controls.HamburgerMenuGlyphItem)e.ClickedItem).Tag.GetType();
            switch (a.Name)
            {
                case "LimitView":
                    ((MahApps.Metro.Controls.HamburgerMenuGlyphItem)e.ClickedItem).Tag = new HomeBudgetApp.Pages.LimitView();
                    break;
                default:
                    break;
            }
            this.HamburgerMenuControl.Content = e.ClickedItem;

            // close the menu if a item was selected
            if (this.HamburgerMenuControl.IsPaneOpen)
            {
                this.HamburgerMenuControl.IsPaneOpen = false;
            }
        }

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
