using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class KeyGenerator
    {
        private const string AllowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const int KeyLength = 16;

        public static string GenerateKey()
        {
            char[] key = new char[KeyLength];
            byte[] randomBytes = new byte[KeyLength];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            for (int i = 0; i < KeyLength; i++)
            {
                key[i] = AllowedChars[randomBytes[i] % AllowedChars.Length];
            }

            return new string(key);
        }
    }
}
