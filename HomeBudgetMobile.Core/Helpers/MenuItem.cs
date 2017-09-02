using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;

namespace HomeBudgetMobile.Helpers
{
    public class MenuItem : ViewModelBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { Set(() => Title, ref _title, value); }
        }

        private string _icon;
        public string Icon
        {
            get { return _icon; }
            set { Set(() => Icon, ref _icon, value); }
        }

        private Xamarin.Forms.Color _iconColor;
        public Xamarin.Forms.Color IconColor
        {
            get { return _iconColor; }
            set { Set(() => IconColor, ref _iconColor, value); }
        }

        public MenuItem(string _title, string _icon, Xamarin.Forms.Color _color)
        {
            this.Title = _title;
            this.Icon = _icon;
            this.IconColor = _color;
        }
    }
}
