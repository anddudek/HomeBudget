using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHomeBudget.Models
{
    public class Settings
    {
        public double DailyLimit { get; set; }
        public string Message { get; set; }
        public Guid MessageCreatorId { get; set; }
    }
}
