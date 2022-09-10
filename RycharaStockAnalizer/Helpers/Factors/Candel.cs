using RycharaStockAnalizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Helpers.Factors
{
    public static class Candel
    {
        public static BuySell IsItBull(DataModel model)
        {
            if (Variables.Data_1[Variables.I].open >= Variables.Data_1[Variables.I].close)
            {
                return BuySell.Sell;
            }
            return BuySell.Buy;
        }
    }
}
