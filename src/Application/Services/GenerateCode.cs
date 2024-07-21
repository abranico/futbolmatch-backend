using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Security.Cryptography;

namespace Application.Services
{
    

    public static class CodeGenerator
    {
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public static string GenerateRandomCode(int length)
        {
            byte[] data = new byte[length];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(data);
            }

            StringBuilder sb = new StringBuilder(length);
            foreach (byte b in data)
            {
                sb.Append(Chars[b % (Chars.Length)]);
            }

            return sb.ToString();
        }
    }
}
