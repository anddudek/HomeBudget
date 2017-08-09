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
using HomeBudgetApp.Wizards;
using HomeBudgetApp.Helpers;

namespace HomeBudgetApp.Pages
{
    /// <summary>
    /// Interaction logic for TransactionView.xaml
    /// </summary>
    public partial class TransactionView : UserControl, INotifyPropertyChanged
    {
        public TransactionView()
        {
            InitializeComponent();
            DataContext = this;
        }

        private bool CanAddNewTransaction()
        {
            return Properties.Settings.Default.CurrentLoginUser != "LoggedOut";
        }

        private void AddNewTransaction()
        {
            AddNewPaymentWizard anpw = new AddNewPaymentWizard();
            anpw.Show();
        }

        private void AddNewDeposit()
        {
            AddNewDepositWizard andw = new AddNewDepositWizard();
            andw.Show();
        }

        public ICommand AddNewDepositCommand { get { return new RelayCommand(AddNewDeposit, CanAddNewTransaction); } }

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
