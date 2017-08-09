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
    public partial class AddNewPaymentWizard : Window, INotifyPropertyChanged
    {
        public AddNewPaymentWizard()
        {
            Error = string.Empty;
            TransactionDate = DateTime.Today;
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

        private DateTime _transactionDate;
        public DateTime TransactionDate
        {
            get
            {
                return _transactionDate;
            }
            set
            {
                _transactionDate = value;
                OnPropertyChanged("TransactionDate");
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

        public List<string> CategoriesList
        {
            get
            {
                return TransactionOperations.GetCategoriesList();
            }
        }

        private string _selectedCategory;
        public string SelectedCategory
        {
            get
            {
                return _selectedCategory;
            }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }

        private bool CanAddNewTransaction()
        {
            return true;
        }

        private void AddNewTransaction()
        {

            double am;
            if (String.IsNullOrEmpty(SelectedCategory)) 
            {
                Error = "Wybierz kategorię";
                return;
            }            
            if (!double.TryParse(Amount.Replace(',','.'), NumberStyles.Float, CultureInfo.InvariantCulture, out am))
            {
                Error = "Wprowadź poprawną kwotę";
                return;
            }
            if (TransactionDate > DateTime.Today)
            {
                Error = "Transakcja z przyszłą datą";
                return;
            }
            Error = string.Empty;
            TransactionOperations.AddNewTransaction(TransactionDate, am, TransactionOperations.GetCategoryGuid(SelectedCategory), UserOperations.GetUserGuid(Properties.Settings.Default.CurrentLoginUser), Comment);
            this.Close();
        }

        public ICommand AddNewTransactionCommand { get { return new RelayCommand(AddNewTransaction, CanAddNewTransaction); } }

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
