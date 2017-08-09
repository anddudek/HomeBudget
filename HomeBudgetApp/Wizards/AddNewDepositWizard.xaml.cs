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
using System.Windows.Shapes;
using System.ComponentModel;
using LibHomeBudget.Operations;
using HomeBudgetApp.Helpers;
using System.Globalization;

namespace HomeBudgetApp.Wizards
{
    /// <summary>
    /// Interaction logic for AddNewPaymentWizard.xaml
    /// </summary>
    public partial class AddNewDepositWizard : Window, INotifyPropertyChanged
    {
        public AddNewDepositWizard()
        {
            Error = string.Empty;
            DepositDate = DateTime.Today;
            InitializeComponent();
            DataContext = this;
        }

        private string _error;
        public string Error
        {
            get
            {
                return _error;
            }
            set
            {
                _error = value;
                OnPropertyChanged("Error");
            }
        }

        public string Comment { get; set; }

        public string UserName
        {
            get
            {
                return Properties.Settings.Default.CurrentLoginUser;
            }
        }

        private DateTime _depositDate;
        public DateTime DepositDate
        {
            get
            {
                return _depositDate;
            }
            set
            {
                _depositDate = value;
                OnPropertyChanged("DepositDate");
            }
        }

        private string _amount;
        public string Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
                OnPropertyChanged("Amount");
            }
        }

        private bool CanAddNewDeposit()
        {
            return true;
        }

        private void AddNewDeposit()
        {
            double am;         
            if (Amount == null || !double.TryParse(Amount.Replace(',','.'), NumberStyles.Float, CultureInfo.InvariantCulture, out am))
            {
                Error = "Wprowadź poprawną kwotę";
                return;
            }
            if (DepositDate > DateTime.Today)
            {
                Error = "Wpłata z przyszłą datą";
                return;
            }
            Error = string.Empty;
            TransactionOperations.AddNewTransaction(DepositDate, am, TransactionOperations.GetDepositCatGuid(), UserOperations.GetUserGuid(Properties.Settings.Default.CurrentLoginUser), Comment);
            this.Close();
        }

        public ICommand AddNewDepositCommand { get { return new RelayCommand(AddNewDeposit, CanAddNewDeposit); } }

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
