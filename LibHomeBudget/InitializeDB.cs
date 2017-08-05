using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibHomeBudget.Context;
using LibHomeBudget.Models;

namespace LibHomeBudget
{
    public class InitializeDB
    {
        public static void InitializeCategories()
        {
            using (var ctx = new DatabaseContext())
            {
                string[] categories = new string[] { "Lunch", "Zakupy do domu", "Ubrania", "Kosmetyki", "Rozrywka", "Nieplanowane wydatki", "Wpłata"};
                foreach (var cat in categories)
                {
                    if (!ctx.Categories.Any(x => string.Equals(x.Name, cat)))
                    {
                        Category categ = new Category { Id = Guid.NewGuid(), Name = cat };
                        ctx.Categories.Add(categ);
                    }
                }
                ctx.SaveChanges();
            }
        }
        public static void InitializeSettings(double _limit, string _msg, string _login)
        {
            using (var ctx = new DatabaseContext())
            {
                if (ctx.Settings.ToList().Count == 0)
                {
                    Guid logId = ctx.Users.Where(x => x.Login.ToUpper().Equals(_login.ToUpper())).First().Id;
                    Setting set = new Setting()
                    {
                        Id = Guid.NewGuid(),
                        DailyLimit = _limit,
                        Message = _msg,
                        MessageCreatorId = logId
                    };
                    ctx.Settings.Add(set);
                    ctx.SaveChanges();
                }
            }
        }
    }
}
