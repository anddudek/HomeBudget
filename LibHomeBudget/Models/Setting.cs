using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHomeBudget.Models
{
    public class Setting
    {
        public Guid Id { get; set; }
        public double DailyLimit { get; set; }
        public string Message { get; set; }
        public Guid MessageCreatorId { get; set; }
        public DateTime LimitLastTimeSet { get; set; }
        public double AmountToSpend { get; set; }
    }
}
