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
using LibHomeBudget.Operations;
using HomeBudgetApp.Helpers;

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

        public string SelectedUser { get; set; }

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

        public List<TransactionItemSource> TransactionsList 
        { 
            get 
            {
                return null;
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

        private bool CanSearch()
        {
            return true;
        }

        private void Search()
        {
            SelectedCategory = null;
        }

        public ICommand ClearCategoryCommand { get { return new RelayCommand(ClearCategory, CanClearCategory); } }

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
