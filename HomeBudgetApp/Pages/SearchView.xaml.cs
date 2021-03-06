﻿using System;
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
using LibHomeBudget.Operations;
using HomeBudgetApp.Helpers;
using LibHomeBudget.Helpers;
using System.Globalization;

namespace HomeBudgetApp.Pages
{
    /// <summary>
    /// Interaction logic for SearchView.xaml
    /// </summary>
    public partial class SearchView : UserControl, INotifyPropertyChanged
    {
        public SearchView()
        {
            Error = string.Empty;
            DateFrom = DateTime.Today;
            DateTo = DateTime.Today;
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

        public List<string> UserList
        {
            get
            {
                return UserOperations.GetAllUsersList();
            }
        }

        private string _selectedUser;
        public string SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }
        

        public List<string> CategoryList
        {
            get
            {
                return TransactionOperations.GetAllCategoriesList();
            }
        }

        private string _selectedCategory;
        public string SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }

        public string AmountFrom { get; set; }

        public string AmountTo { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        private List<TransactionItemSource> _transactionsList;
        public List<TransactionItemSource> TransactionsList 
        { 
            get 
            {
                return _transactionsList;
            }
            set
            {
                _transactionsList = value;
                OnPropertyChanged("TransactionsList");
            }
        }

        private bool CanClearCategory()
        {
            return true;
        }

        private void ClearCategory()
        {
            SelectedCategory = null;
        }

        private bool CanClearName()
        {
            return true;
        }

        private void ClearName()
        {
            SelectedUser = null;
        }

        private bool CanSearch()
        {
            return true;
        }

        private void Search()
        {
            double amFrom;
            double amTo;
            if (AmountFrom == null || !double.TryParse(AmountFrom.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out amFrom))
            {
                Error = "Wprowadź poprawną kwotę od";
                return;
            }
            if (AmountTo == null || !double.TryParse(AmountTo.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out amTo))
            {
                Error = "Wprowadź poprawną kwotę do";
                return;
            }
            if (DateFrom > DateTo)
            {
                Error = "Data do powinna być dalsza";
                return;
            }
            TransactionsList = TransactionOperations.GetTransactionSearchResults(SelectedUser, SelectedCategory, amFrom, amTo, DateFrom, DateTo);
        }

        public ICommand ClearCategoryCommand { get { return new RelayCommand(ClearCategory, CanClearCategory); } }

        public ICommand ClearNameCommand { get { return new RelayCommand(ClearName, CanClearName); } }

        public ICommand SearchCommand { get { return new RelayCommand(Search, CanSearch); } }

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
