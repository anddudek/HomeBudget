using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using HomeBudgetMobile.Helpers;

namespace HomeBudgetMobile.ViewModel.Menu
{
    public class RootPageViewModel : ViewModelBase
    {
        private bool _isPresented;
        public bool IsPresented
        {
            get { return _isPresented; }
            set { Set(() => IsPresented, ref _isPresented, value); }
        }

        public RootPageViewModel()
        {

        }
    }
}
