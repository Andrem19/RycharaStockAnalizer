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
            double vol = 0;
            double body = 0;
            for (int i = 0; i < OneDay.Count; i++)
            {
                high += OneDay[i].high - OneDay[i].low;
                vol += OneDay[i].volume;
                if (OneDay[i].open> OneDay[i].close)
                {
                    body += OneDay[i].open - OneDay[i].close;
                }
                body += OneDay[i].close - OneDay[i].open;
            }
            body /= OneDay.Count;
            high /= OneDay.Count;
            vol /= OneDay.Count;
            Variables.Body = body;
            Variables.High = high;
            Variables.Vol = vol;
            if (OneDay.Count < (int)Variables.FactorCandel)
            {
                return BuySell.Non;
            }
            if (OneDay[Variables.FactorCandelStart].open > OneDay[OneDay.Count - (int)Variables.FactorCandel].close)
            {
                return BuySell.Sell;
            }
            else if (OneDay[Variables.FactorCandelStart].open < OneDay[OneDay.Count - (int)Variables.FactorCandel].close)
            {
                return BuySell.Buy;

            }
            return BuySell.Non;
        }
    }
}
