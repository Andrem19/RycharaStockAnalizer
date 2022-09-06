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
            Model.I = Variables.I;
            Model.OpenTime = Variables.OpenTime;
            Model.CloseTime = Variables.CloseTime;
            Model.OpenPrice = Variables.OpenPrice;
            Model.ClosePrice = Variables.ClosePrice;
            Model.Direct = Variables.Direct.ToString();
            Model.Profit = Calculate.CalculateProfit();
            Model.DayOfWeek = Variables.OpenTime.DayOfWeek.ToString();
            Model.Data_1_Vol = Variables.Data_1[Variables.I].volume;
            Model.Data_1_high = Variables.Data_1[Variables.I].high - Variables.Data_1[Variables.I].low;
            if (Model.Direct == Direction.Buy.ToString())
            {
                Model.Body = Variables.Data_1[Variables.I].close - Variables.Data_1[Variables.I].open;
            }
            else
            {
                Model.Body = Variables.Data_1[Variables.I].open - Variables.Data_1[Variables.I].close;
            }
            Model.Trig = Variables.ExitByTrigger;
            Model.Pair = Variables.Symbol_Data_1 + "-" + Variables.Symbol_Data_2;
            return Model;
        }
    }
}
