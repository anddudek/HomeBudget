using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace HomeBudgetMobile.Helpers
{
    public class PasswordOperations
    {
        public static string GenerateSalt()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[20];
                rng.GetBytes(salt);
                return Encoding.UTF8.GetString(salt, 0, salt.Length);
            }
        }
        public static string HashPassword(string password, string salt)
        {
            var bytes = new UTF8Encoding().GetBytes(password + salt);
            byte[] hashBytes;
            using (var algorithm = new SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            return Encoding.UTF8.GetString(hashBytes, 0, hashBytes.Length);
        }

    }
}
