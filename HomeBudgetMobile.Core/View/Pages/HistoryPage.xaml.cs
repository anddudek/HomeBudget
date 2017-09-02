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
	public partial class HistoryPage : ContentPage
	{
		public HistoryPage ()
		{
			InitializeComponent ();
            ViewModel.Pages.HistoryPageViewModel vm = new ViewModel.Pages.HistoryPageViewModel();
            this.BindingContext = vm;
        }
	}
}