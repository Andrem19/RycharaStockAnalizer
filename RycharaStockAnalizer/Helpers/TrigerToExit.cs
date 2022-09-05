using RycharaStockAnalizer.Models;
using RycharaStockAnalizer.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Helpers
{
    public static class TrigerToExit
    {
        public static bool Triger(DataModel candel)
        {
            if (Variables.Direct == Direction.Buy)
            {
                if (candel.high > Variables.CloseLimitP)
                {
                    Variables.ClosePrice = Variables.CloseLimitP;
                    Variables.ExitByTrigger = true;
                    return true;
                }
                else if (candel.low < Variables.CloseLimitM)
                {
                    Variables.ClosePrice = Variables.CloseLimitM;
                    Variables.ExitByTrigger = true;
                    return true;
                }
            }
            else
            {
                if (candel.high > Variables.CloseLimitM)
                {
                    Variables.ClosePrice = Variables.CloseLimitM;
                    Variables.ExitByTrigger = true;
                    return true;
                }
                else if (candel.low < Variables.CloseLimitP)
                {
                    Variables.ClosePrice = Variables.CloseLimitP;
                    Variables.ExitByTrigger = true;
                    return true;
                }
            }
            return false;
        }
    }
}
