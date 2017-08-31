using System;
using System.Collections.Generic;
using System.Text;

namespace HomeBudgetMobile.Helpers
{
    public class UserTransaction
    {
        public string Name { get; set; }
        public double Sum { get; set; }

        public UserTransaction(string _name, double _sum)
        {
            Name = _name;
            Sum = _sum;
        }
    }
}
