using RycharaStockAnalizer.Helpers;
using RycharaStockAnalizer.Helpers.Factors;
using RycharaStockAnalizer.Models;
using RycharaStockAnalizer.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Analizer
{
    public static class AnalizerWorker_2
    {
        public static async Task Worker(List<DataModel> Data_1, List<DataModel> Data_2)
        {
            for (int i = 2; i < Data_1.Count - 11; i++)
            {
                if (Variables.DayOfYears == UnixTimeHelper.UnixTimeStampToDateTime(Data_1[i].open_time).DayOfYear)
                {
                    continue;
                }
                //if (i == 1885)
                //{
                //    Console.WriteLine();
                //}
                Variables.I = i;
                Variables.Direct = Candels.IsItBull(Variables.IsItBullCount) ? Direction.Buy : Direction.Sell;
                Variables.OpenTime = UnixTimeHelper.UnixTimeStampToDateTime(Data_1[i+ Variables.IsItBullCount-1].close_time);
                Variables.DayOfYears = Variables.OpenTime.DayOfYear;

                for (int j = Variables.J; j < Data_2.Count-11; j++)
                {
                    Variables.J = j;
                    if (Data_2[j].open_time >= Data_1[i + Variables.IsItBullCount - 1].close_time)
                    {
                        if (!Variables.OpenPriceSet)
                        {
                            Variables.OpenPrice = Data_2[j].open;
                            SetCloseLimit.SetClose();
                            Variables.OpenPriceSet = true;
                        }
                        if (TrigerToExit.Triger(Data_2[j]))
                        {
                            Variables.ExitByTrigger = true;
                            Variables.CloseTime = UnixTimeHelper.UnixTimeStampToDateTime(Data_2[j].close_time);
                            break;
                        }
                        if (Data_2[j].close_time >= Data_1[i + Variables.IsItBullCount - 1].close_time + ConverterIntToSec.Converting(Variables.ResultTime))
                        {
                            Variables.ClosePrice = Data_2[j].close;
                            Variables.CloseTime = UnixTimeHelper.UnixTimeStampToDateTime(Data_2[j].close_time);
                            break;
                        }
                    }
                    if (Data_2[j].close_time >= Data_1[i + 9].close_time || j == Data_2.Count - 10)
                    {
                        break;
                    }
                }
                if (Variables.OpenPrice != 0 && Variables.ClosePrice != 0)
                {
                    Variables.StatisticModels.Add(CompleteStatistic.CreateStat());
                    ShowConsole.Show(Variables.StatisticModels[Variables.StatisticModels.Count - 1]);
                    ResetVars.ResetVariables();
                }
            }
            Console.WriteLine(GeneralStat.CalcStat());
            MonthStatCalc.Calc();
            WriteModel<MonthStat>.Write(Variables.MonthStatistic);
        }
    }
}
