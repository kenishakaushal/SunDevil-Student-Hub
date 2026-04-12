using System;
using System.Security.Cryptography;
using System.Text;

namespace SunDevilStudentHub.SecurityLib
{
    /// <summary>
    /// Local DLL class library for password hashing, encryption, and decryption.
    /// Developed by: Ishita Bansal
    /// Used by: Member registration, Member login, Staff login, TryIt testing
    /// </summary>
    public static class SecurityHelper
    {
        /// <summary>
        /// Hashes a plaintext password using SHA256.
        /// </summary>
        public static string HashPassword(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        /// <summary>
        /// Simple Base64 encryption for non-password fields.
        /// </summary>
        public static string EncryptText(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Decrypts Base64-encoded text.
        /// </summary>
        public static string DecryptText(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;
            byte[] bytes = Convert.FromBase64String(input);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
