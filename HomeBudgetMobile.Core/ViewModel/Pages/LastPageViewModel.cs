using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using HomeBudgetMobile.Helpers;
using HomeBudgetMobile.Data;

namespace HomeBudgetMobile.ViewModel.Pages
{
    public class LastPageViewModel : ViewModelBase
    {
        private List<TransactionRecord> _transactionList;
        public List<TransactionRecord> TransactionList
        {
            get { return _transactionList; }
            set { Set(() => TransactionList, ref _transactionList, value); }
        }

        public LastPageViewModel()
        {
            TransactionList = SummaryDataOperator.GetTransactionsHistory();
        }
    }
}
