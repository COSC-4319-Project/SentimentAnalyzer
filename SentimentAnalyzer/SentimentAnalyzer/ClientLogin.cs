using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SentimentAnalyzer
{
    class LoginUtility
    {
        public static string SaltedHash(string plainText)
        {
            //Create a salt
            byte[] salt = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(salt);

            //Create Bytes of hash value
            var pbkdf2 = new Rfc2898DeriveBytes(plainText, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            //Combined Hash and Salt
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            //Convert to string
            return Convert.ToBase64String(hashBytes);
        }

        public static string HashFromSalt(string plainText, string strSalt)
        {
            //Convert salt
            byte[] salt = Convert.FromBase64String(strSalt);
            new RNGCryptoServiceProvider().GetBytes(salt);

            //Create Bytes of hash value
            var pbkdf2 = new Rfc2898DeriveBytes(plainText, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            //Combined Hash and Salt
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            //Convert to string
            return Convert.ToBase64String(hashBytes);
        }
    }
}
