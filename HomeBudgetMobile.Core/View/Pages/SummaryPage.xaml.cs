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
	public partial class SummaryPage : ContentPage
	{
		public SummaryPage ()
		{
			InitializeComponent ();
            ViewModel.Pages.SummaryPageViewModel vm = new ViewModel.Pages.SummaryPageViewModel();
            this.BindingContext = vm;
		}
	}
}