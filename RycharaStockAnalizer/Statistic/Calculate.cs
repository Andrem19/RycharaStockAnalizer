using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Statistic
{
    public static class Calculate
    {
        public static double CalculateProfit()
        {
            if (Variables.Direct == Direction.Buy)
            {
                double buyAmountCoins = Variables.Funds / Variables.OpenPrice;
                double sellAmountUSD = buyAmountCoins * Variables.ClosePrice;
                double profit = sellAmountUSD - Variables.Funds - ExchangeFee.ExFee(buyAmountCoins, Variables.ClosePrice);
                return profit;
            }
            if (Variables.Direct == Direction.Sell)
            {
                double sellAmountCoins = Variables.Funds / Variables.OpenPrice;
                double buyBackUSD = sellAmountCoins * Variables.ClosePrice;
                double profit = Variables.Funds - buyBackUSD - ExchangeFee.ExFee(sellAmountCoins, Variables.ClosePrice);
                return profit;
            }
            return 0;
        }
    }
}
