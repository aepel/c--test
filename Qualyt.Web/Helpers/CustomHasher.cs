using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualyt.Web.Helpers
{
    public class CustomHasher<TUser> : PasswordHasher<TUser> where TUser : class
    {
        public static string md5(string sPassword)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(sPassword);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
                s.Append(b.ToString("x2").ToLower());
            return s.ToString();
        }

        public override string HashPassword(TUser user, string password)
        {
            return md5(password);
        }

        public override PasswordVerificationResult VerifyHashedPassword(TUser user, string hashedPassword, string providedPassword)
        {
            var testHash = md5(providedPassword).ToUpper();
            return hashedPassword.ToUpper().Equals(testHash) || hashedPassword.Equals(providedPassword) ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
        }
    }
}
