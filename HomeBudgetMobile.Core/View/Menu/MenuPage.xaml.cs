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
			InitializeComponent ();
            ViewModel.Menu.MenuPageViewModel vm = new ViewModel.Menu.MenuPageViewModel(rootPageVM);
            this.BindingContext = vm;
		}
	}
}