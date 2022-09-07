using RycharaStockAnalizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Helpers.Factors
{
    public enum BuySell
    {
        Buy,
        Sell,
        Non
    }
    public static class Candels
    {
        public static BuySell IsItBull(List<DataModel> OneDay)
        {
            double high = 0;
            for (int i = 0; i < OneDay.Count; i++)
            {
                high += OneDay[i].high - OneDay[i].low;
            }
            high /= OneDay.Count;
            if (OneDay[0].open > OneDay[OneDay.Count - 1].close)
            {
                return BuySell.Sell;
            }
            else if (OneDay[0].open < OneDay[OneDay.Count -1].close)
            {
                return BuySell.Buy;

            }
            return BuySell.Non;
        }
    }
}
