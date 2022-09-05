using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Statistic
{
    public static class GeneralStat
    {
        public static string CalcStat()
        {
            int success = 0;
            int fail = 0;
            double Profit = 0;
            for (int i = 0; i < Variables.StatisticModels.Count; i++)
            {
                Profit += Variables.StatisticModels[i].Profit;
                if (Variables.StatisticModels[i].Profit > 0)
                {
                    success++;
                }
                else fail++;
            }
            double all = success + fail;
            double onePerc = all / 100;
            double percent = Math.Round(success / onePerc, 3);
            return $"Success: {success} Fail: {fail} PercentSC: {percent} Profit: {Math.Round(Profit, 3)}";
        }
    }
}
