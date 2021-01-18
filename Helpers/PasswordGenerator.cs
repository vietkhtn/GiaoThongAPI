using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace HR.Helpers
{
    public class PasswordGenerator
    {
        const string LOWER_CASE = "abcdefghijklmnopqursuvwxyz";
        const string UPPER_CASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string NUMBERS = "1234567890";
        const string SPECIALS = @"!@#$%^&*()";
        public static string RandomPassword(int length)
        {
            const string valid = LOWER_CASE + UPPER_CASE + NUMBERS;
            StringBuilder res = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }

            int lower = 0, upper = 0, numbers = 0;
            foreach (var i in res.ToString())
            {
                if (LOWER_CASE.Contains(i))
                    lower++;
                else if (UPPER_CASE.Contains(i))
                    upper++;
                else
                    numbers++;
            }

            Random random = new Random();
            if (lower == 0)
                res.Append(LOWER_CASE[random.Next(0, 25)]);
            if (upper == 0)
                res.Append(UPPER_CASE[random.Next(0, 25)]);
            if (numbers == 0)
                res.Append(NUMBERS[random.Next(0, 9)]);

            return res.Append(SPECIALS[random.Next(0, 9)]).ToString();
        }
    }
}
