using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Helpers
{
    public static class ConverterIntToSec
    {
        public static double Converting(string interval)
        {
            string letter = interval.Substring(interval.Length - 1);
            double inter = Convert.ToDouble(interval.Substring(0, interval.Length - 1));
            int mult = 0;
            if (letter == "m")
            {
                mult = 60;
            }
            else if (letter == "h")
            {
                mult = 3600;
            }
            else if (letter == "d")
            {
                mult = 86400;
            }
            return inter * mult;
        }
    }
}
