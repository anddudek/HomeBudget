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

namespace HomeBudgetApp.Pages
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class SummaryView : UserControl, INotifyPropertyChanged
    {
        public SummaryView()
        {
            _percentageValue = 50;
            _monthsPollLeft = 11;
            _todayPaymentLeft = 12;
            _todayPaymentSum = 13;
            InitializeComponent();
            this.DataContext = this;
        }

        private double _percentageValue;
        public double PercentageValue
        {
            get
            {
                return _percentageValue;
            }
            set
            {
                if (value != _percentageValue)
                {
                    _percentageValue = value;
                    OnPropertyChanged("PercentageValue");
                }
            }
        }

        private double _monthlyLimit;
        public string MonthlyLimit
        {
            get
            {
                return (_monthlyLimit.ToString("F2") + " zł");
            }
            set
            {
                double.TryParse(value, out _monthlyLimit);
                OnPropertyChanged("MonthlyLimit");
            }
        }

        private double _monthsPollLeft;
        public string MonthsPollLeft
        {
            get
            {
                return (_monthsPollLeft.ToString("F2") + " zł");
            }
            set
            {
                double.TryParse(value, out _monthsPollLeft);
                OnPropertyChanged("MonthsPollLeft");
            }
        }

        private double _todayPaymentLeft;
        public string TodayPaymentLeft
        {
            get
            {
                return (_todayPaymentLeft.ToString("F2") + " zł");
            }
            set
            {
                double.TryParse(value, out _todayPaymentLeft);
                OnPropertyChanged("TodayPaymentLeft");
            }
        }

        private double _todayPaymentSum;
        public string TodayPaymentSum
        {
            get
            {
                return (_todayPaymentSum.ToString("F2") + " zł");
            }
            set
            {
                double.TryParse(value, out _todayPaymentSum);
                OnPropertyChanged("TodayPaymentSum");
            }
        }

        public string ProgressText
        {
            get
            {
                return (_percentageValue.ToString("F0") + "%");
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
}
