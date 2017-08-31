using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeBudgetMobile.View.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TransactionPage : ContentPage
	{
		public TransactionPage ()
		{
			InitializeComponent ();
            ViewModel.Pages.TransactionPageViewModel vm = new ViewModel.Pages.TransactionPageViewModel();
            this.BindingContext = vm;
		}
	}
}