using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot.Axes;

namespace HomeBudgetApp.Helpers
{
    public class MyLinearAxis : CategoryAxis
    {
        protected override string FormatValueOverride(double x)
        {
            switch ((int)x)
            {
                case 0:
                    DateTime myDate = DateTime.Now.AddDays(-6);
                    return myDate.ToString("dddd");
                case 1:
                    DateTime myDate1 = DateTime.Now.AddDays(-5);
                    return myDate1.ToString("dddd");
                case 2:
                    DateTime myDate2 = DateTime.Now.AddDays(-4);
                    return myDate2.ToString("dddd");
                case 3:
                    DateTime myDate3 = DateTime.Now.AddDays(-3);
                    return myDate3.ToString("dddd");
                case 4:
                    DateTime myDate4 = DateTime.Now.AddDays(-2);
                    return myDate4.ToString("dddd");
                case 5:
                    DateTime myDate5 = DateTime.Now.AddDays(-1);
                    return myDate5.ToString("dddd");
                case 6:
                    return System.DateTime.Now.ToString("dddd");
                default:
                    return string.Empty;
            }
        }
    }
}
