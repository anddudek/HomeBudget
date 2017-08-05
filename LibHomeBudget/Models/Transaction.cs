using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHomeBudget.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public double Cost { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
    }
}
