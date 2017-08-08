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
    /// Interaction logic for LimitView.xaml
    /// </summary>
    public partial class LimitView : UserControl, INotifyPropertyChanged
    {
        public LimitView()
        {
            DataContext = this;
            InitializeComponent();
            MWContainer.LW = this;
        }
        
        public int NumberOfDays
        {
            get
            {
                return DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            }
        }
        
        public string DailyLimit
        {
            get
            {
                return (SettingOperations.GetDailyLimit() + " zł");
            } 
        }

        public void UpdateCommands()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        private string _setNewLimit;
        public string SetNewLimit
        {
            get { return _setNewLimit; }
            set
            {
                _setNewLimit = value;
                OnPropertyChanged("SetNewLimit");
            }
        }

        private string _amountToSpent;
        public string AmountToSpent
        {
            get { return _amountToSpent; }
            set
            {
                _amountToSpent = value;
                OnPropertyChanged("AmountToSpent");
            }
        }

        private bool CanSetNewLimit()
        {
            return Properties.Settings.Default.CurrentLoginUser != "LoggedOut";
        }

        private void SetNewLimitF()
        {
            double lim;
            if (double.TryParse(SetNewLimit, out lim))
            {
                MessageBoxResult result = MessageBox.Show(String.Format("Czy chcesz zmienić limit z {0} na {1} ?", DailyLimit, SetNewLimit), "Zmiana limitu", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    SettingOperations.SetLimit(lim);
                    OnPropertyChanged("DailyLimit");
                }
            }
        }

        private bool CanCalculateNewLimit()
        {
            return Properties.Settings.Default.CurrentLoginUser != "LoggedOut";
        }

        private double _newLimit;
        private void CalculateNewLimit()
        {
            double _amount;
            if (double.TryParse(AmountToSpent, out _amount))
            {
                _newLimit = Math.Floor(_amount / NumberOfDays);
                MessageBoxResult result = MessageBox.Show(String.Format("Czy chcesz zmienić limit z {0} na {1} ?", DailyLimit, _newLimit), "Zmiana limitu", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    SettingOperations.SetLimit(_newLimit);
                    OnPropertyChanged("DailyLimit");
                }
            }
        }

        public ICommand CalculateNewLimitCommand { get { return new RelayCommand(CalculateNewLimit, CanCalculateNewLimit); } }

        public ICommand SetLimitCommand { get { return new RelayCommand(SetNewLimitF, CanSetNewLimit); } }

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
