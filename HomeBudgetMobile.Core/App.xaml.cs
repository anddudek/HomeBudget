using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using HomeBudgetMobile.View.Menu;
using HomeBudgetMobile.View.Pages;

namespace HomeBudgetMobile
{
	public partial class App : Application
	{
        public static NavigationPage NavigationPage { get; private set; }
		public App ()
		{
			InitializeComponent();

            NavigationPage = new NavigationPage(new SummaryPage());
            RootPage rootPage = new RootPage();
            MenuPage menuPage = new MenuPage(rootPage.vm);

            rootPage.Master = menuPage;
            rootPage.Detail = NavigationPage;

			MainPage = rootPage;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
