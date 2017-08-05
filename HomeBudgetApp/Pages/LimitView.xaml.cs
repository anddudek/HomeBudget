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
        }
        
        public int NumberOfDays
        {
            get
            {
                return DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            }
        }
        
        public double DailyLimit
        {
            get
            {
                return SettingOperations.GetDailyLimit();
            } 
        }

        private string _setNewLimit;
        public string SetNewLimit
        {
            get { return _setNewLimit; }
            set
            {
                _setNewLimit = value;
            }
        }

        private bool CanSetNewLimit()
        {
            return true;
        }

        private void SetNewLimitF()
        {
            double lim;
            if (double.TryParse(SetNewLimit, out lim))
            {
                SettingOperations.SetLimit(lim);
                OnPropertyChanged("DailyLimit");
            }
        }

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
