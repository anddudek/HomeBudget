using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Windows.Input;
using HomeBudgetMobile.View.Pages;

namespace HomeBudgetMobile.ViewModel.Menu
{
    public class MenuPageViewModel : ViewModelBase
    {
        private ObservableCollection<Helpers.MenuItem> _items = new ObservableCollection<Helpers.MenuItem>();
        public ObservableCollection<Helpers.MenuItem> Items
        {
            get { return _items; }
            set { Set(() => Items, ref _items, value); }
        }

        private Helpers.MenuItem _selectedItem;
        public Helpers.MenuItem SelectedItem
        {
            get { return _selectedItem; }
            set { Set(() => SelectedItem, ref _selectedItem, value); }
        }

        public ICommand ItemSelectedCommand { get; set; }

        private RootPageViewModel rootPageVM;

        public MenuPageViewModel(RootPageViewModel rootPageViewModel)
        {
            this.rootPageVM = rootPageViewModel;
            ItemSelectedCommand = new HomeBudgetMobile.Helpers.RelayCommand(ItemSelectedMethod);
            Items.Add(new Helpers.MenuItem("Podsumowanie", Awesome.FontAwesome.FAAnchor));
            Items.Add(new Helpers.MenuItem("Transakcje", Awesome.FontAwesome.FAAndroid));
        }

        private async void ItemSelectedMethod()
        {
            if (SelectedItem == Items[0])
            {
                var root = App.NavigationPage.Navigation.NavigationStack[0];
                App.NavigationPage.Navigation.InsertPageBefore(new SummaryPage(), root);
                await App.NavigationPage.PopToRootAsync(false);
            }
            if (SelectedItem == Items[1])
            {
                var root = App.NavigationPage.Navigation.NavigationStack[0];
                App.NavigationPage.Navigation.InsertPageBefore(new TransactionPage(), root);
                await App.NavigationPage.PopToRootAsync(false);
            }
            rootPageVM.IsPresented = false;
        }
    }
}
