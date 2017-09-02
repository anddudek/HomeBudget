using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using HomeBudgetMobile.Helpers;
using System.Windows.Input;
using HomeBudgetMobile.Data;
using Xamarin.Forms;

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

        public ICommand AddTransaction { get; private set; }
        private void AddTransactionAction()
        {
           
            if (SelectedCategory == null)
            {
                MessagingCenter.Send<ViewModel.Pages.TransactionPageViewModel> (this, "InvalidCategory");
                return;
            }
            if (Cost <= 0)
            {
                MessagingCenter.Send<ViewModel.Pages.TransactionPageViewModel>(this, "InvalidCost");
                return;
            }
            if (!Application.Current.Properties.ContainsKey("CurrentUser"))
            {
                MessagingCenter.Send<ViewModel.Pages.TransactionPageViewModel>(this, "InvalidUser");
                return;
            }
            SummaryDataOperator.AddNewTransaction(Cost, Categories.GetCategoryGuid(SelectedCategory).ToString(), Users.GetUserGuid(Application.Current.Properties["CurrentUser"] as string).ToString(), Description);
            MessagingCenter.Send<ViewModel.Pages.TransactionPageViewModel>(this, "TransactionAdded");
        }

        public TransactionPageViewModel()
        {
            _categoryList = new List<string>();
            _categoryList.Add(Categories.Kosmetyki.CatName);
            _categoryList.Add(Categories.Lunch.CatName);
            _categoryList.Add(Categories.NieplanowaneWydatki.CatName);
            _categoryList.Add(Categories.Rozrywka.CatName);
            _categoryList.Add(Categories.Ubrania.CatName);
            _categoryList.Add(Categories.Wplata.CatName);
            _categoryList.Add(Categories.ZakupyDoDomu.CatName);

            AddTransaction = new Helpers.RelayCommand(AddTransactionAction);
        }
    }
}
