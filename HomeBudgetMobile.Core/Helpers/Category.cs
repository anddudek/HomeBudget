using System;
using System.Collections.Generic;
using System.Text;

namespace HomeBudgetMobile.Helpers
{
    public class Category
    {
        public string CatName;
        public string CatGuid;

        public Category(string _name, string _guid)
        {
            CatName = _name;
            CatGuid = _guid;
        }
    }
}
