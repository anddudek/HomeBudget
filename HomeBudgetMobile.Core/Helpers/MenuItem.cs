using System;
using System.Collections.Generic;
using System.Text;

namespace HomeBudgetMobile.Helpers
{
    public class MenuItem
    {
        public string Title { get; set; }
        public string Icon { get; set; }

        public MenuItem(string _title, string _icon)
        {
            this.Title = _title;
            this.Icon = _icon;
        }
    }
}
