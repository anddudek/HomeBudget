using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using GalaSoft.MvvmLight;
using HomeBudgetMobile.Data;
using HomeBudgetMobile.Helpers;
using System.Windows.Input;

namespace HomeBudgetMobile.ViewModel.Pages
{
    public class LimitPageViewModel : ViewModelBase
    {
        private double _amountToSpend;
        public double AmountToSpend
        {
            get { return _amountToSpend; }
            set { Set(() => AmountToSpend, ref _amountToSpend, value); }
        }

        private double _limit;
        public double Limit
        {
            get { return _limit; }
            set { Set(() => Limit, ref _limit, value); }
        }

        public ICommand UpdateAmountToSpend { get; private set; }
        private void UpdateAmountToSpendAction()
        {
            SummaryDataOperator.UpdateAmountToSpend(AmountToSpend);
            MessagingCenter.Send<ViewModel.Pages.LimitPageViewModel>(this, "AmountModified");
        }

        public ICommand UpdateLimit { get; private set; }
        private void UpdateLimitAction()
        {
            Limit = SummaryDataOperator.UpdateDailyLimit(AmountToSpend);
            MessagingCenter.Send<ViewModel.Pages.LimitPageViewModel>(this, "LimitUpdated");
        }

        public LimitPageViewModel()
        {
            Limit = SummaryDataOperator.GetDailyLimit();
            AmountToSpend = SummaryDataOperator.GetAmountToSpend();

            UpdateAmountToSpend = new RelayCommand(UpdateAmountToSpendAction);
            UpdateLimit = new RelayCommand(UpdateLimitAction);
        }
    }
}
