using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibHomeBudget.Models;

namespace LibHomeBudget.Operations
{
    public class TransactionOperations
    {
        public static void AddNewTransaction(DateTime _date, Double _amount, Guid _id, Guid _userId)
        {
            using(var ctx = new Context.DatabaseContext())
            {
                var trans = new Transaction() { Id = Guid.NewGuid(), Date = _date, CategoryId = _id, Cost = _amount, UserId = _userId };
                ctx.Transactions.Add(trans);
                ctx.SaveChanges();
            }
        }

        public static List<string> GetCategoriesList()
        {
            using (var ctx = new Context.DatabaseContext())
            {
                return ctx.Categories.Select(x => x.Name).ToList();
            }
        }

        public static Guid GetCategoryGuid(string _name)
        {
            using (var ctx = new Context.DatabaseContext())
            {
                return ctx.Categories.Where(x => x.Name.ToUpper().Equals(_name.ToUpper())).First().Id;
            }
        }

        public static double GetUserTodayPayments(string _name)
        {
            using (var ctx = new Context.DatabaseContext())
            {
                Guid uId = UserOperations.GetUserGuid(_name);
                var q = ctx.Transactions.Where(x => (x.UserId == uId)).ToList();
                var q1 = q.Where(x => x.Date.Date == DateTime.Today.Date).ToList();
                return q1.Sum(x => x.Cost);
            }
        }

        public static Guid GetDepositCatGuid()
        {
            return new Guid("C041805D-5CEA-4043-B349-554ABB638EA4");
        }

        public static double GetMonthlyPollLeft()
        {
            using (var ctx = new Context.DatabaseContext())
            {
                var td = DateTime.Now.Day;
                Guid dep = GetDepositCatGuid();
                var cost = ctx.Transactions.Where(x => (x.CategoryId != dep && x.Date.Month == DateTime.Now.Month && x.Date.Year == DateTime.Now.Year)).Select(x => x.Cost).DefaultIfEmpty(0).Sum();
                var depo = ctx.Transactions.Where(x => (x.CategoryId == dep && x.Date.Month == DateTime.Now.Month && x.Date.Year == DateTime.Now.Year)).Select(x => x.Cost).DefaultIfEmpty(0).Sum();
                return DateTime.Now.Day * SettingOperations.GetDailyLimit() - cost + depo;
            }
        }

        //public static double 
    }
}
