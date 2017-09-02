using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using HomeBudgetMobile.Data;
using HomeBudgetMobile.Helpers;
using Xamarin.Forms;

namespace HomeBudgetMobile.ViewModel.Pages
{
    public class MessagePageViewModel : ViewModelBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { Set(() => Message, ref _message, value); }
        }

        private string _messageCreator;
        public string MessageCreator
        {
            get { return _messageCreator; }
            set { Set(() => MessageCreator, ref _messageCreator, value); }
        }

        public ICommand UpdateMessage { get; private set; }
        private void UpdateMessageAction()
        {
            if (!Application.Current.Properties.ContainsKey("CurrentUser"))
            {
                MessagingCenter.Send<ViewModel.Pages.MessagePageViewModel>(this, "NotLogged");
                return;
            }
            SummaryDataOperator.UpdateMessage(Application.Current.Properties["CurrentUser"] as string, Message);
            MessageCreator = Application.Current.Properties["CurrentUser"] as string;
            MessagingCenter.Send<ViewModel.Pages.MessagePageViewModel>(this, "MessageChanged");
        }

        public MessagePageViewModel()
        {
            var msg = SummaryDataOperator.GetMessageData();
            Message = msg.Message;
            MessageCreator = msg.Creator;
            UpdateMessage = new RelayCommand(UpdateMessageAction);
            
            if (Application.Current.Properties.ContainsKey("CurrentUser"))
            {
                SummaryDataOperator.MarkMessageAsRead(Application.Current.Properties["CurrentUser"] as string);
            }
        }
    }
}
