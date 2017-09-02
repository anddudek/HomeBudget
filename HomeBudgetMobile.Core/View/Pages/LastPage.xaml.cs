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
	public partial class LastPage : ContentPage
	{
		public LastPage ()
		{
			InitializeComponent ();
            ViewModel.Pages.LastPageViewModel vm = new ViewModel.Pages.LastPageViewModel();
            this.BindingContext = vm;
        }
	}
}