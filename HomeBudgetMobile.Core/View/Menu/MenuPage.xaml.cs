using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HomeBudgetMobile.ViewModel.Menu;

namespace HomeBudgetMobile.View.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
		public MenuPage (RootPageViewModel rootPageVM)
		{
            MessagingCenter.Subscribe<ViewModel.Pages.TransactionPageViewModel>(this, "InvalidCost", (sender) =>
            {
                DisplayAlert("Niewłaściwe dane", "Wpisano nieprawidłowy koszt", "OK");
            });
            MessagingCenter.Subscribe<ViewModel.Pages.TransactionPageViewModel>(this, "InvalidCategory", (sender) =>
            {
                DisplayAlert("Niewłaściwe dane", "Nie wybrano kategorii", "OK");
            });
            MessagingCenter.Subscribe<ViewModel.Pages.TransactionPageViewModel>(this, "InvalidUser", (sender) =>
            {
                DisplayAlert("Niewłaściwe dane", "Aby dodać transakcję musisz się zalogować", "OK");
            });
            MessagingCenter.Subscribe<ViewModel.Pages.TransactionPageViewModel>(this, "TransactionAdded", (sender) =>
            {
                DisplayAlert("", "Transakcja dodana", "OK");
            });

            Application.Current.Properties["CurrentUser"] = "Andrzej";

            InitializeComponent ();
            ViewModel.Menu.MenuPageViewModel vm = new ViewModel.Menu.MenuPageViewModel(rootPageVM);
            this.BindingContext = vm;
		}
	}
}