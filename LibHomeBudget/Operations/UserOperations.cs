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
        public static bool ChangePassword(string _login, string _password)
        {
            using (var ctx = new Context.DatabaseContext())
            {
                if (ctx.Users.Where(x => string.Equals(_login.ToUpper(), x.Login.ToUpper())).ToList().Count == 0)
                {
                    return false;
                }
                string salt = PasswordOperations.GenerateSalt();
                ctx.Users.Where(x => string.Equals(_login.ToUpper(), x.Login.ToUpper())).First().Hash = salt;
                User a = ctx.Users.Where(x => string.Equals(_login.ToUpper(), x.Login.ToUpper())).First();
                ctx.Users.Where(x => string.Equals(_login.ToUpper(), x.Login.ToUpper())).First().Password = PasswordOperations.HashPassword(_password, salt);
                return true;
            }
        }

        public static List<string> GetAllUsersList()
        {
            using (var ctx = new Context.DatabaseContext())
            {
                return ctx.Users.Select(x => x.Name).ToList();
            }
        }

        public static List<string> GetAllUsersLoginList()
        {
            using (var ctx = new Context.DatabaseContext())
            {
                return ctx.Users.Select(x => x.Login).ToList();
            }
        }

        public static Guid GetUserGuid(string _login)
        {
            using (var ctx = new Context.DatabaseContext())
            {
                return ctx.Users.Where(x => x.Login.ToUpper().Equals(_login.ToUpper())).First().Id;
            }
        }

        public static string GetUserLogin(Guid _id)
        {
            using (var ctx = new Context.DatabaseContext())
            {
                return ctx.Users.Where(x => x.Id == _id).First().Login;
            }
        }

        public static bool DidUserReadMessage(string _login)
        {
            using (var ctx = new Context.DatabaseContext())
            {
                var q = ctx.Users.Where(x => x.Login.ToUpper().Equals(_login.ToUpper()));
                if (q.ToList().Count > 0)
                {
                    return q.First().HasSeenMessage;
                }
                return true; //user not found -> no new message
            }
        }

        public static void UserReadMessage(string _login)
        {
            using (var ctx = new Context.DatabaseContext())
            {
                ctx.Users.Where(x => x.Login.ToUpper().Equals(_login.ToUpper())).First().HasSeenMessage = true;
                ctx.SaveChanges();
            }
        }

        public static string GetLastMessageCreatorLogin()
        {
            using (var ctx = new Context.DatabaseContext())
            {
                Guid uId = ctx.Settings.First().MessageCreatorId;
                return GetUserLogin(uId);
            }
        }
    }

}
