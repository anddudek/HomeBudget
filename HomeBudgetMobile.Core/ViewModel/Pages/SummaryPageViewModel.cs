using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using HomeBudgetMobile.Data;
using Xamarin.Forms;
using HomeBudgetMobile.Helpers;
using System.Linq;

namespace HomeBudgetMobile.ViewModel.Pages
{
    public class SummaryPageViewModel : ViewModelBase
    {
        private double _monthlyLimit;
        public double MonthlyLimit
        {
            get { return _monthlyLimit; }
            set { Set(() => MonthlyLimit, ref _monthlyLimit, value); }
        }

        private List<UserTransaction> _todaysPayments;
        public List<UserTransaction> TodaysPayments
        {
            get { return _todaysPayments; }
            set { Set(() => TodaysPayments, ref _todaysPayments, value); }
        }

        private double _todayPaymentSum;
        public double TodaysPaymentSum
        {
            get { return _todayPaymentSum; }
            set { Set(() => TodaysPaymentSum, ref _todayPaymentSum, value); }
        }

        private double _monthsPollLeft;
        public double MonthsPollLeft
        {
            get { return _monthsPollLeft; }
            set { Set(() => MonthsPollLeft, ref _monthsPollLeft, value); }
        }

        private double _todayPaymentLeft;
        public double TodayPaymentLeft
        {
            get { return _todayPaymentLeft; }
            set { Set(() => TodayPaymentLeft, ref _todayPaymentLeft, value); }
        }

        public SummaryPageViewModel()
        {
            _monthlyLimit = SummaryDataOperator.GetDailyLimit();
            _todaysPayments = SummaryDataOperator.GetTransactionSum(DateTime.Today);
            _monthsPollLeft = SummaryDataOperator.GetAdditionalPool();
            foreach (var u in _todaysPayments)
            {
                _todayPaymentLeft += u.Sum;
            }
            _todayPaymentLeft = _monthlyLimit - _todayPaymentLeft;            
        }
    }
}
