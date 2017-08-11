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

namespace HomeBudgetApp.Pages
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class SummaryView : UserControl, INotifyPropertyChanged
    {
        public SummaryView()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void UpdateDisplay()
        {
            double lim = SettingOperations.GetDailyLimit();
            double poll = TransactionOperations.GetMonthlyPollLeft();
        }

        public bool LoadingState { get; set; }

        public double PercentageValue
        {
            get
            {
                double lim = SettingOperations.GetDailyLimit();
                double sum = 0;
                var users = UserOperations.GetAllUsersList();
                foreach (var u in users)
                {
                    sum += TransactionOperations.GetUserTodayPayments(u);
                }
                return (sum / lim) * 100;       
            }
        }

        public string MonthlyLimit
        {
            get
            {
                return SettingOperations.GetDailyLimit().ToString() + " zł";
            }
        }

        public string MonthsPollLeft
        {
            get
            {
                return TransactionOperations.GetMonthlyPollLeft().ToString() + " zł";
            }
        }

        public string TodayPaymentLeft
        {
            get
            {
                double lim = SettingOperations.GetDailyLimit();
                double sum = 0;
                var users = UserOperations.GetAllUsersList();
                foreach (var u in users)
                {
                    sum += TransactionOperations.GetUserTodayPayments(u);
                }
                LoadingState = false;
                return (lim - sum).ToString() + " zł";
            }
        }

        public string TodayPaymentSum
        {
            get
            {
                double sum = 0;
                var users = UserOperations.GetAllUsersList();
                foreach (var u in users)
                {
                    sum += TransactionOperations.GetUserTodayPayments(u);
                }
                return sum.ToString() + " zł";
            }
        }

        public List<UserItemSource> TodaysPayments
        {
            get
            {
                List<UserItemSource> uList = new List<UserItemSource>();
                var users = UserOperations.GetAllUsersList();
                foreach (var u in users)
                {
                    var uis = new UserItemSource();
                    uis.Amount = TransactionOperations.GetUserTodayPayments(u).ToString() + " zł";
                    uis.Name = u;
                    uList.Add(uis);
                }
                return uList;
            }
        }

        public string ProgressText
        {
            get
            {
                double lim = SettingOperations.GetDailyLimit();
                double sum = 0;
                var users = UserOperations.GetAllUsersList();
                foreach (var u in users)
                {
                    sum += TransactionOperations.GetUserTodayPayments(u);
                }
                return (lim - sum).ToString() + " zł";
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
