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
using LibHomeBudget.Helpers;

namespace HomeBudgetApp.Pages
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class SummaryView : UserControl, INotifyPropertyChanged
    {
        public SummaryView()
        {
            UpdateDisplay();
            InitializeComponent();
            this.DataContext = this;
        }

        private void UpdateDisplay()
        {
            // query db
            double lim = SettingOperations.GetDailyLimit();
            double poll = TransactionOperations.GetMonthlyPollLeft();
            List<UserPayment> users = TransactionOperations.GetAllUsersPayments();
            double todayPayments = users.Sum(x => x.Payments);
            PercentageValue = (todayPayments / lim ) * 100;
            MonthlyLimit = lim.ToString() + " zł";
            MonthsPollLeft = poll.ToString() + " zł";
            TodayPaymentLeft = (lim - todayPayments).ToString() + " zł";
            TodayPaymentSum = todayPayments.ToString() + " zł";
            TodaysPayments = users;
            ProgressText = (lim - todayPayments).ToString() + " zł";
        }

        public bool LoadingState { get; set; }

        private double _percentageValue;
        public double PercentageValue
        {
            get
            {
                return _percentageValue;  
            }
            set
            {
                _percentageValue = value;
                OnPropertyChanged("PercentageValue");
            }
        }

        private string _monthlyLimit;
        public string MonthlyLimit
        {
            get
            {
                return _monthlyLimit;
            }
            set
            {
                _monthlyLimit = value;
                OnPropertyChanged("MonthlyLimit");
            }
        }

        private string _monthsPollLeft;
        public string MonthsPollLeft
        {
            get
            {
                return _monthsPollLeft;
            }
            set
            {
                _monthsPollLeft = value;
                OnPropertyChanged("MonthsPollLeft");
            }
        }

        private string _todayPaymentLeft;
        public string TodayPaymentLeft
        {
            get
            {
                return _todayPaymentLeft;
            }
            set
            {
                _todayPaymentLeft = value;
                OnPropertyChanged("TodayPaymentLeft");
            }
        }

        private string _todayPaymentSum;
        public string TodayPaymentSum
        {
            get
            {
                return _todayPaymentSum;
            }
            set
            {
                _todayPaymentSum = value;
                OnPropertyChanged("TodayPaymentSum");
            }
        }

        private List<UserPayment> todaysPayments;
        public List<UserPayment> TodaysPayments
        {
            get
            {
                return todaysPayments;
            }
            set
            {
                todaysPayments = value;
                OnPropertyChanged("TodaysPayments");
            }
        }

        private string _progressText;
        public string ProgressText
        {
            get
            {
                return _progressText;
            }
            set
            {
                _progressText = value;
                OnPropertyChanged("ProgressText");
            }
        }

        private bool CanRefresh()
        {
            return true;
        }

        private void Refresh()
        {
            var t = Task.Run(() => UpdateDisplay());
            t.ContinueWith((r) => StopLoading());
        }

        private void StopLoading()
        {
            LoadingState = false;
        }

        public ICommand RefreshCommand { get { return new RelayCommand(Refresh, CanRefresh); } }

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
