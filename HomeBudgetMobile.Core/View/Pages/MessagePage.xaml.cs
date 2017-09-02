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
	public partial class MessagePage : ContentPage
	{
		public MessagePage ()
		{
			InitializeComponent ();
            ViewModel.Pages.MessagePageViewModel vm = new ViewModel.Pages.MessagePageViewModel();
            this.BindingContext = vm;
        }
	}
}