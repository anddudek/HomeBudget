using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using LibHomeBudget.Models;
using System.Configuration;

namespace LibHomeBudget.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("ConnectionString") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
