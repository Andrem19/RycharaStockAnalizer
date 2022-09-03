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
        public static double RandomNum()
        {
            int num = GetRandom.GetRandomNumber(1, 10);
            int num2 = GetRandom.GetRandomNumber(1, 5);
            return (double)num / (double)num2;
        }
    }
}
