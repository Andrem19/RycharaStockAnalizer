using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Helpers
{
    public static class GetRandom
    {
        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }
        public static double RandomNum(int min1, int max1, int min2, int max2)
        {
            int num = GetRandom.GetRandomNumber(min1, max1);
            int num2 = GetRandom.GetRandomNumber(min2, max2);
            return (double)num / (double)num2;
        }
    }
}
