using RycharaStockAnalizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Statistic
{
    public static class CompleteStatistic
    {
        public static StatModel CreateStat()
        {
            StatModel Model = new();
            Model.Iter = Variables.I;
            Model.OpenTime = Variables.OpenTime;
            Model.CloseTime = Variables.CloseTime;
            Model.Direct = Variables.Direct;
            Model.Profit = Calculate.CalculateProfit();
            Model.Pair = Variables.Symbol_Data_1 + "-" + Variables.Symbol_Data_2;
            return Model;
        }
    }
}
