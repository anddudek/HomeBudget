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
                    return System.DateTime.Now.AddDays(-7).ToString("dddd");
                case 1:
                    return System.DateTime.Now.AddDays(-6).ToString("dddd");
                case 2:
                    return System.DateTime.Now.AddDays(-5).ToString("dddd");
                case 3:
                    return System.DateTime.Now.AddDays(-4).ToString("dddd");
                case 4:
                    return System.DateTime.Now.AddDays(-3).ToString("dddd");
                case 5:
                    return System.DateTime.Now.AddDays(-2).ToString("dddd");
                case 6:
                    return System.DateTime.Now.AddDays(-1).ToString("dddd");
                default:
                    return string.Empty;
            }
        }
    }
}
