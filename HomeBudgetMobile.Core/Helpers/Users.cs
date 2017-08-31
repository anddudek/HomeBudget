using System;
using System.Collections.Generic;
using System.Text;

namespace HomeBudgetMobile.Helpers
{
    public class Users
    {
        public static User Klaudia = new User("Klaudia", "DBDC7D4B-F935-41FC-80C9-5D94E4463853");
        public static User Andrzej = new User("Andrzej", "CA802E61-947A-48D7-A56B-ED588F025B0C");

        public static string GetUserName(Guid userId)
        {
            List<User> users = new List<User> { Klaudia, Andrzej };
            foreach (var u in users)
            {
                if (u.UGuid.ToUpper().Equals(userId.ToString().ToUpper()))
                {
                    return u.UName;
                }
            }
            return null;
        }
    }
}
