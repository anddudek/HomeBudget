using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibHomeBudget.Models;

namespace LibHomeBudget.Operations
{
    public class UserOperations
    {
        public static void CreateNewUser(string login, string name, string password)
        {           
            using (var ctx = new Context.DatabaseContext())
            {
                string salt = PasswordOperations.GenerateSalt();
                User u = new User()
                { Id = Guid.NewGuid(),
                    Login = login,
                    Name = name,
                    Password = PasswordOperations.HashPassword(password, salt),
                    Hash = salt,
                    HasSeenMessage = false
                };
                ctx.Users.Add(u);
                ctx.SaveChanges();
            }
        }
        public static bool CheckPassword(string password, string hashedPassword, string salt)
        {
            return (string.Equals(hashedPassword, PasswordOperations.HashPassword(password, salt)));
        }
        public static bool TryLogin(string _login, string _password)
        {
            using (var ctx = new Context.DatabaseContext())
            {
                var q = ctx.Users.Where(x => string.Equals(_login.ToUpper(), x.Login.ToUpper())).ToList();
                if (q.Count == 0)
                {
                    return false;
                }
                return CheckPassword(_password, q.FirstOrDefault().Password, q.FirstOrDefault().Hash);
            }
        }
    }

}
