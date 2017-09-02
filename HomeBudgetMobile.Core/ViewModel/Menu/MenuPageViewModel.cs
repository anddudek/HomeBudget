using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Windows.Input;
using HomeBudgetMobile.View.Pages;
using HomeBudgetMobile.Data;
using System.Timers;

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
            Items.Add(new Helpers.MenuItem("Podsumowanie", Awesome.FontAwesome.FAPieChart, Color.Black));
            Items.Add(new Helpers.MenuItem("Transakcje", Awesome.FontAwesome.FACreditCard, Color.Black));
            Items.Add(new Helpers.MenuItem("Historia", Awesome.FontAwesome.FABarChartO, Color.Black));
            Items.Add(new Helpers.MenuItem("Logowanie", Awesome.FontAwesome.FAUser, Color.Black));
            Items.Add(new Helpers.MenuItem("Ostatnie", Awesome.FontAwesome.FAHistory, Color.Black));
            Items.Add(new Helpers.MenuItem("Wiadomość", Awesome.FontAwesome.FAComment, Color.Black));

            Timer timer = new Timer(5000);
            timer.Elapsed += HandleTimer;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void HandleTimer(Object source, ElapsedEventArgs e)
        {
            if (Application.Current.Properties.ContainsKey("CurrentUser"))
            {
                if (!SummaryDataOperator.HasUserSeenMessage(Application.Current.Properties["CurrentUser"] as string))
                {
                    if (Items != null)
                    {
                        Items[5].IconColor = Color.Red;
                    }
                }
            }
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
            if (SelectedItem == Items[2])
            {
                var root = App.NavigationPage.Navigation.NavigationStack[0];
                App.NavigationPage.Navigation.InsertPageBefore(new HistoryPage(), root);
                await App.NavigationPage.PopToRootAsync(false);
            }
            if (SelectedItem == Items[3])
            {
                var root = App.NavigationPage.Navigation.NavigationStack[0];
                App.NavigationPage.Navigation.InsertPageBefore(new LoginPage(), root);
                await App.NavigationPage.PopToRootAsync(false);
            }
            if (SelectedItem == Items[4])
            {
                var root = App.NavigationPage.Navigation.NavigationStack[0];
                App.NavigationPage.Navigation.InsertPageBefore(new LastPage(), root);
                await App.NavigationPage.PopToRootAsync(false);
            }
            if (SelectedItem == Items[5])
            {
                var root = App.NavigationPage.Navigation.NavigationStack[0];
                App.NavigationPage.Navigation.InsertPageBefore(new MessagePage(), root);
                await App.NavigationPage.PopToRootAsync(false);
            }
            rootPageVM.IsPresented = false;
        }
    }
}
