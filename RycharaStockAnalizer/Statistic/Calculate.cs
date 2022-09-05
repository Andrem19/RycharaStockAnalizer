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
                //if (Variables.ExitByTrigger && profit > 0)
                //{
                //    profit = Variables.Funds / 100 * Variables.PercentForTriggerP - ExchangeFee.ExFee(buyAmountCoins, Variables.ClosePrice);
                //    Variables.ExitByTrigger = false;
                //}
                //if (Variables.ExitByTrigger && profit < 0)
                //{
                //    profit = Variables.Funds / 100 * Variables.PercentForTriggerM + ExchangeFee.ExFee(buyAmountCoins, Variables.ClosePrice);
                //    profit *= -1;
                //    Variables.ExitByTrigger = false;
                //}
                //if (profit > Variables.Funds / 100 * Variables.PercentForTriggerP)
                //{
                //    profit = Variables.Funds / 100 * Variables.PercentForTriggerP - ExchangeFee.ExFee(buyAmountCoins, Variables.ClosePrice);
                //}
                //if (profit < (Variables.Funds / 100 * Variables.PercentForTriggerM + ExchangeFee.ExFee(buyAmountCoins, Variables.ClosePrice)) * -1)
                //{
                //    profit = Variables.Funds / 100 * Variables.PercentForTriggerM + ExchangeFee.ExFee(buyAmountCoins, Variables.ClosePrice);
                //    profit *= -1;
                //}
                return profit;
            }
            if (Variables.Direct == Direction.Sell)
            {
                double sellAmountCoins = Variables.Funds / Variables.OpenPrice;
                double buyBackUSD = sellAmountCoins * Variables.ClosePrice;
                double profit = Variables.Funds - buyBackUSD - ExchangeFee.ExFee(sellAmountCoins, Variables.ClosePrice);
                //if (Variables.ExitByTrigger && profit > 0)
                //{
                //    profit = Variables.Funds / 100 * Variables.PercentForTriggerP - ExchangeFee.ExFee(sellAmountCoins, Variables.ClosePrice);
                //    Variables.ExitByTrigger = false;
                //}
                //if (Variables.ExitByTrigger && profit < 0)
                //{
                //    profit = Variables.Funds / 100 * Variables.PercentForTriggerM + ExchangeFee.ExFee(sellAmountCoins, Variables.ClosePrice);
                //    profit *= -1;
                //    Variables.ExitByTrigger = false;
                //}
                //if (profit > Variables.Funds / 100 * Variables.PercentForTriggerP)
                //{
                //    profit = Variables.Funds / 100 * Variables.PercentForTriggerP - ExchangeFee.ExFee(sellAmountCoins, Variables.ClosePrice);
                //}
                //if (profit < (Variables.Funds / 100 * Variables.PercentForTriggerM + ExchangeFee.ExFee(sellAmountCoins, Variables.ClosePrice)) * -1)
                //{
                //    profit = Variables.Funds / 100 * Variables.PercentForTriggerM + ExchangeFee.ExFee(sellAmountCoins, Variables.ClosePrice);
                //    profit *= -1;
                //}
                return profit;
            }
            return 0;
        }
    }
}
