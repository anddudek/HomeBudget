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
	public partial class LimitPage : ContentPage
	{
		public LimitPage ()
		{
			InitializeComponent ();
            ViewModel.Pages.LimitPageViewModel vm = new ViewModel.Pages.LimitPageViewModel();
            this.BindingContext = vm;
        }
	}
}