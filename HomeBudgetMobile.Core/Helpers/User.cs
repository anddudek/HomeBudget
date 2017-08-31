using System;
using System.Collections.Generic;
using System.Text;

namespace HomeBudgetMobile.Helpers
{
    public class User
    {
        public string UName;
        public string UGuid;

        public User(string _name, string _guid)
        {
            UName = _name;
            UGuid = _guid;
        }
    }
}
