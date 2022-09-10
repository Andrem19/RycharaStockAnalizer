using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Helpers
{
    public static class SetCloseLimit2
    {
        public static void SetClose()
        {
            double perc1 = Variables.OpenPrice / 100;
            double rateP = perc1 * Variables.PercForSecExitP;
            double rateM = perc1 * Variables.PercForSecExitM;
            if (Variables.Direct == Direction.Buy)
            {
                Variables.SecCloseLimitP = Variables.OpenPrice + rateP;
                Variables.SecCloseLimitM = Variables.OpenPrice - rateM;
            }
            else
            {
                Variables.SecCloseLimitP = Variables.OpenPrice - rateP;
                Variables.SecCloseLimitM = Variables.OpenPrice + rateM;
            }
        }
    }
}
