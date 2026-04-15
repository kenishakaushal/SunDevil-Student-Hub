using System;
using System.Security.Cryptography;
using System.Text;

namespace Group19Project.SecurityLib
{
    public class SecurityUtils
    {
        public static string HashPassword(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "";

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < hash.Length; i++)
                {
                    builder.Append(hash[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
