using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chaty.Repo
{
    public static class RandomCodeGenerator
    {
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static DateTime GetOfferTime(int OfferNumber)
        {
            if (OfferNumber == 1)
            {
                return DateTime.Now.AddDays(10);
            }
            else if (OfferNumber == 2)
            {
                return DateTime.Now.AddDays(20);
            }
            else
            {
                return DateTime.Now.AddDays(30);
            }
        }
    }
}
