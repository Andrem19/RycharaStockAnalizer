using RycharaStockAnalizer.Models;
using RycharaStockAnalizer.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Helpers
{
    public static class TrigerToExit2
    {
        public static bool Triger(DataModel candel)
        {
            if (Variables.Direct == Direction.Buy)
            {
                if (candel.high > Variables.SecCloseLimitP)
                {
                    Variables.ClosePrice = Variables.SecCloseLimitP;
                    if (candel.open > Variables.SecCloseLimitP)
                    {
                        Variables.ClosePrice = candel.open;
                    }
                    return true;
                }
                else if (candel.low < Variables.SecCloseLimitM)
                {
                    Variables.ClosePrice = Variables.SecCloseLimitM;
                    if (candel.open < Variables.SecCloseLimitM)
                    {
                        Variables.ClosePrice = candel.open;
                    }
                    return true;
                }
            }
            else
            {
                if (candel.high > Variables.SecCloseLimitM)
                {
                    Variables.ClosePrice = Variables.SecCloseLimitM;
                    if (candel.open > Variables.SecCloseLimitM)
                    {
                        Variables.ClosePrice = candel.open;
                    }
                    return true;
                }
                else if (candel.low < Variables.SecCloseLimitP)
                {
                    Variables.ClosePrice = Variables.SecCloseLimitP;
                    if (candel.open < Variables.SecCloseLimitP)
                    {
                        Variables.ClosePrice = candel.open;
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
