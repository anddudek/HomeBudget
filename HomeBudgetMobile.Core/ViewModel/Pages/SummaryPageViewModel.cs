using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using HomeBudgetMobile.Data;
using Xamarin.Forms;
using HomeBudgetMobile.Helpers;
using OxyPlot;
using OxyPlot.Series;
using System.Linq;

namespace HomeBudgetMobile.ViewModel.Pages
{
    public class SummaryPageViewModel : ViewModelBase
    {
        private double _monthlyLimit;
        public double MonthlyLimit
        {
            get { return Math.Round(_monthlyLimit, 2); }
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
            get { return Math.Round(_todayPaymentSum, 2); }
            set { Set(() => TodaysPaymentSum, ref _todayPaymentSum, value); }
        }

        private double _monthsPollLeft;
        public double MonthsPollLeft
        {
            get { return Math.Round(_monthsPollLeft, 2); }
            set { Set(() => MonthsPollLeft, ref _monthsPollLeft, value); }
        }

        private double _todayPaymentLeft;
        public double TodayPaymentLeft
        {
            get { return Math.Round(_todayPaymentLeft,2); }
            set { Set(() => TodayPaymentLeft, ref _todayPaymentLeft, value); }
        }

        public PlotModel _donutChart;
        public PlotModel DonutChart
        {
            get { return _donutChart; }
            set { Set(() => DonutChart, ref _donutChart, value); }
        }

        public SummaryPageViewModel()
        {
            RefreshPage();
        }

        private void RefreshPage()
        {
            _monthlyLimit = SummaryDataOperator.GetDailyLimit();
            _todaysPayments = SummaryDataOperator.GetTransactionSum(DateTime.Today);
            _monthsPollLeft = SummaryDataOperator.GetAdditionalPool();
            double todaySum = 0;
            foreach (var u in _todaysPayments)
            {
                todaySum += u.Sum;
            }
            _todayPaymentLeft = _monthlyLimit - todaySum;

            var data = SummaryDataOperator.GetLastWeekTransactionsSum();
            _donutChart = new PlotModel();
            var seriesP1 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.5, AngleSpan = 360, StartAngle = 0, InnerDiameter = 0.8, OutsideLabelFormat = "", TickHorizontalLength = 0, TickRadialLength = 0 };
            seriesP1.Slices.Add(new PieSlice("", _monthlyLimit) { IsExploded = false, Fill = OxyColors.Transparent });
            seriesP1.Slices.Add(new PieSlice("", todaySum) { IsExploded = false, Fill = OxyColors.Green });
            _donutChart.Series.Add(seriesP1);
            
        }
    }
}
