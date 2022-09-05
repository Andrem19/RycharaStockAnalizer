using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Helpers
{
    public static class SetCloseLimit
    {
        public static void SetClose()
        {
            double perc1 = Variables.OpenPrice / 100;
            double rateP = perc1 * Variables.PercentForTriggerP;
            double rateM = perc1 * Variables.PercentForTriggerM;
            if (Variables.Direct == Direction.Buy)
            {
                Variables.CloseLimitP = Variables.OpenPrice + rateP;
                Variables.CloseLimitM = Variables.OpenPrice - rateM;
            }
            else
            {
                Variables.CloseLimitP = Variables.OpenPrice - rateP;
                Variables.CloseLimitM = Variables.OpenPrice + rateM;
            }
        }
    }
}
