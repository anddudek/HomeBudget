using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibHomeBudget.Models;

namespace LibHomeBudget.Operations
{
    public class SettingOperations
    {
        public static void SetLimit(double _limit)
        {
            using (var ctx = new Context.DatabaseContext())
            {
                if (ctx.Settings.ToList().Count == 0)
                {
                    Setting set = new Setting()
                    {
                        Id = Guid.NewGuid(),
                        DailyLimit = _limit,
                        Message = string.Empty,
                        MessageCreatorId = Guid.Empty
                    };
                    ctx.Settings.Add(set);
                }
                else
                {
                    ctx.Settings.First().DailyLimit = _limit;
                }
                ctx.SaveChanges();
            }
        }
        public static void ChangeMessage(string _msg, string _login)
        {
            using (var ctx = new Context.DatabaseContext())
            {
                if (ctx.Settings.ToList().Count == 0)
                {
                    Guid logId = ctx.Users.Where(x => x.Login.ToUpper().Equals(_login.ToUpper())).First().Id;
                    Setting set = new Setting()
                    {
                        Id = Guid.NewGuid(),
                        DailyLimit = 0,
                        Message = _msg,
                        MessageCreatorId = logId
                    };
                    ctx.Settings.Add(set);
                }
                else
                {
                    Guid logId = ctx.Users.Where(x => x.Login.ToUpper().Equals(_login.ToUpper())).First().Id;
                    ctx.Settings.First().Message = _msg;
                    ctx.Settings.First().MessageCreatorId = logId;
                }
                ctx.Users.ToList().ForEach(x => x.HasSeenMessage = false);
                ctx.SaveChanges();
            }
        }
        public static double GetDailyLimit()
        {
            using (var ctx = new Context.DatabaseContext())
            {
                if (ctx.Settings.ToList().Count == 0)
                {
                    return 0;
                }
                return ctx.Settings.First().DailyLimit;
            }
        }

        public static string GetMessage()
        {
            using (var ctx = new Context.DatabaseContext())
            {
                return ctx.Settings.First().Message;
            }
        }        

        public static void EnterAmountToSpend(double amount)
        {
            using (var ctx = new Context.DatabaseContext())
            {
                ctx.Settings.First().AmountToSpend = amount;
                ctx.SaveChanges();
            }
        }
    }
}
