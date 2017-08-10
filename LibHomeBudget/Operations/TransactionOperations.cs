using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibHomeBudget.Models;
using LibHomeBudget.Helpers;

namespace LibHomeBudget.Operations
{
    public class TransactionOperations
    {
        public static void AddNewTransaction(DateTime _date, Double _amount, Guid _catId, Guid _userId, string _desc)
        {
            using(var ctx = new Context.DatabaseContext())
            {
                var trans = new Transaction() { Id = Guid.NewGuid(), Date = _date, CategoryId = _catId, Cost = _amount, UserId = _userId, Description = _desc };
                ctx.Transactions.Add(trans);
                ctx.SaveChanges();
            }
        }

        public static List<string> GetCategoriesList()
        {
            using (var ctx = new Context.DatabaseContext())
            {
                Guid depo = GetDepositCatGuid();
                return ctx.Categories.Where(x => x.Id != depo).Select(x => x.Name).ToList();
            }
        }

        public static List<string> GetAllCategoriesList()
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
                Guid depoId = GetDepositCatGuid();
                Guid uId = UserOperations.GetUserGuid(_name);
                var q = ctx.Transactions.Where(x => (x.UserId == uId)).Where(x => x.CategoryId != depoId).ToList();
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

        public static List<TransactionItemSource> GetTransactionSearchResults(string _name, string _category, double _amountFrom, double _amountFor, DateTime _dateFrom, DateTime _dateFor)
        {
            using (var ctx = new Context.DatabaseContext())
            {
                List<TransactionItemSource> retList = new List<TransactionItemSource>();
                var q = ctx.Transactions.Where(x => x.Cost >= _amountFrom && x.Cost <= _amountFor && x.Date >= _dateFrom && x.Date <= _dateFrom).ToList();
                    //.Join(ctx.Users, t => t.UserId, u => u.Id, (t, u) => new { t, u })
                    //.Join(ctx.Categories, tt => tt.t.CategoryId, c => c.Id, (tt, c) => new { tt, c });
                    //.Where(ttt => ttt.tt.u.Name.ToUpper().Equals(_name.ToUpper()) && ttt.c.Name.ToUpper().Equals(_category.ToUpper()))
                    //.ToList();
                if (_name != null)
                {
                    //q = q.Where(ttt => ttt.tt.u.Name.ToUpper().Equals(_name.ToUpper()));
                }
                if (_category != null)
                {
                   // q = q.Where(ttt => ttt.c.Name.ToUpper().Equals(_category.ToUpper()));
                }
                var qq = q.ToList();
                foreach (var i in qq)
                {
                    //retList.Add(new TransactionItemSource() { Name = i.tt.u.Name, Amount = i.tt.t.Cost.ToString() + " zł", Category = i.c.Name, Comment = i.tt.t.Description, Date = i.tt.t.Date.Date.ToString() });
                }
                return retList;
            }
        }
    }
}
