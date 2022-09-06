using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Helpers.Factors
{
    public static class Candels
    {
        public static bool IsItBull(int count)
        {
            if (Variables.Data_1[Variables.I].open > Variables.Data_1[Variables.I + count - 1].close)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
