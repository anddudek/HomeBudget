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
	public partial class RootPage : MasterDetailPage
	{
        public RootPageViewModel vm;
		public RootPage ()
		{
			InitializeComponent ();
            vm = new ViewModel.Menu.RootPageViewModel();
            this.BindingContext = vm;
            MasterBehavior = MasterBehavior.Popover;
		}
	}
}