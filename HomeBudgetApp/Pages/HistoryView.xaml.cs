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
using OxyPlot;
using OxyPlot.Series;
using HomeBudgetApp.Helpers;

namespace HomeBudgetApp.Pages
{
    /// <summary>
    /// Interaction logic for HistoryView.xaml
    /// </summary>
    public partial class HistoryView : UserControl, INotifyPropertyChanged
    {
        public HistoryView()
        {
            UpdateDisplay();            
            InitializeComponent();
            DataContext = this;
        }

        private void UpdateDisplay()
        {
            _monthsPollLeft = 20;
            _lastMonthPaymentSum = 15;
            _columnModel = new PlotModel { Title = "Historia transakcji" };
            ColumnSeries series = new ColumnSeries();
            _columnModel.Series.Add(series);
            for (int i = 0; i < 7; i++)
            {
                series.Items.Add(new ColumnItem(27 + i));
            }
            series.Items.Where(x => x.Value > 30).ToList().ForEach(x => x.Color = OxyColor.FromRgb(255, 0, 0));
            LineSeries lineSeries = new LineSeries();
            _columnModel.Series.Add(lineSeries);
            lineSeries.Points.Add(new DataPoint(0, 30));
            lineSeries.Points.Add(new DataPoint(6, 30));
            MyLinearAxis XAxis = new MyLinearAxis();
            XAxis.Position = OxyPlot.Axes.AxisPosition.Bottom;
            _columnModel.Axes.Add(XAxis);
        }

        private PlotModel _columnModel;
        public PlotModel ColumnModel
        {
            get
            {
                return _columnModel;
            }
            set
            {
                if (value != _columnModel)
                {
                    _columnModel = value;
                    OnPropertyChanged("ColumnModel");
                }
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

        private double _lastMonthPaymentSum;
        public string LastMonthPaymentSum
        {
            get
            {
                return (_lastMonthPaymentSum.ToString("F2") + " zł");
            }
            set
            {
                double.TryParse(value, out _lastMonthPaymentSum);
                OnPropertyChanged("LastMonthPaymentSum");
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
