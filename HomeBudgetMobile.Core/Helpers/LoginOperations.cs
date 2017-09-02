using System;
using System.Collections.Generic;
using System.Text;
using HomeBudgetMobile.Data;

namespace HomeBudgetMobile.Helpers
{
    public static class LoginOperations
    {
        public static bool CheckPassword(string password, string hashedPassword, string salt)
        {
            return (string.Equals(hashedPassword, PasswordOperations.HashPassword(password, salt)));
        }
        public static bool TryLogin(string _login, string _password)
        {
            var userData = SummaryDataOperator.GetLoginInformations(_login);
            return CheckPassword(_password, userData[0], userData[1]);            
        }
    }
}
