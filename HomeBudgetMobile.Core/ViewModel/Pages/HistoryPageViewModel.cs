using System;
using System.Collections.Generic;
using System.Text;
using HomeBudgetMobile.Helpers;
using GalaSoft.MvvmLight;
using HomeBudgetMobile.Data;
using OxyPlot;
using OxyPlot.Series;

namespace HomeBudgetMobile.ViewModel.Pages
{
    public class HistoryPageViewModel : ViewModelBase
    {
        private double _monthAdditionalPoll;
        public double MonthAdditionalPoll
        {
            get { return _monthAdditionalPoll; }
            set { Set(() => MonthAdditionalPoll, ref _monthAdditionalPoll, value); }
        }

        private double _lastMonthSpendings;
        public double LastMonthSpendings
        {
            get { return _lastMonthSpendings; }
            set { Set(() => LastMonthSpendings, ref _lastMonthSpendings, value); }
        }

        private PlotModel _columnModel;
        public PlotModel ColumnModel
        {
            get { return _columnModel; }
            set { Set(() => ColumnModel, ref _columnModel, value); }
        }

        public HistoryPageViewModel()
        {
            RefreshPage();
        }

        private void RefreshPage()
        {
            _monthAdditionalPoll = SummaryDataOperator.GetAdditionalPool();
            _lastMonthSpendings = SummaryDataOperator.GetLastMonthSpendings();

            _columnModel = new PlotModel { Title = "Historia transakcji" };
            ColumnSeries series = new ColumnSeries();
            _columnModel.Series.Add(series);
            var sumArray = SummaryDataOperator.GetLastWeekTransactionsSum();
            for (int i = 0; i < sumArray.Length; i++)
            {
                series.Items.Add(new ColumnItem(sumArray[i]));
            }
            MyLinearAxis XAxis = new MyLinearAxis();
            XAxis.Position = OxyPlot.Axes.AxisPosition.Bottom;
            _columnModel.Axes.Add(XAxis);
        }
    }
}
