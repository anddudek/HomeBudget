using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HomeBudgetMobile.Helpers;

namespace HomeBudgetMobile.ViewModel.Pages
{
    public class TransactionPageViewModel : ViewModelBase
    {
        private double _cost;
        public double Cost
        {
            get { return _cost; }
            set { Set(() => Cost, ref _cost, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { Set(() => Description, ref _description, value); }
        }

        private List<string> _categoryList;
        public List<string> CategoryList
        {
            get { return _categoryList; }
            set { Set(() => CategoryList, ref _categoryList, value); }
        }

        private string _selectedCategory;
        public string SelectedCategory
        {
            get { return _selectedCategory; }
            set { Set(() => SelectedCategory, ref _selectedCategory, value); }
        }

        public GalaSoft.MvvmLight.Command.RelayCommand AddTransaction { get; private set; }
        private bool CanAddTransaction()
        {
            return true;
        }
        private void AddTransactionAction()
        {
            Description = "AA";
        }

        public TransactionPageViewModel()
        {
            _categoryList = new List<string> { Categories.Kosmetyki.CatName,  Categories.Lunch.CatName, Categories.NieplanowaneWydatki.CatName, Categories.Rozrywka.CatName, Categories.Ubrania.CatName, Categories.Wplata.CatName, Categories.ZakupyDoDomu.CatName};

            AddTransaction = new GalaSoft.MvvmLight.Command.RelayCommand(AddTransactionAction, CanAddTransaction);
        }
    }
}
