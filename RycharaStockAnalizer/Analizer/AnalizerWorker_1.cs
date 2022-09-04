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
    public static class AnalizerWorker_1
    {
        public static async Task Worker(List<DataModel> Data_1, List<DataModel> Data_2)
        {
            for (int i = 0; i < Data_1.Count - 2; i++)
            {
                Variables.I = i;
                if (i == 627)
                {
                    Console.WriteLine();
                }
                Variables.Direct = Candel.IsItBull(Data_1[i]) ? Direction.Buy : Direction.Sell;

                double timeCheck = Data_1[i].close_time + ConverterIntToSec.Converting(Variables.ResultTime);
                Variables.OpenTime = UnixTimeHelper.UnixTimeStampToDateTime(Data_1[i].close_time);
                for (int j = Variables.J; j < Data_2.Count; j++)
                {
                    Variables.J = j;
                    if (Data_2[j].open_time >= Data_1[i].close_time && Data_2[j].open_time < Data_1[i+1].close_time)
                    {
                        if (!Variables.OpenPriceSet)
                        {
                            Variables.OpenPrice = Data_2[j].open;
                            Variables.OpenPriceSet = true;
                        }
                        if (TrigerToExit.Triger(Data_2[j]))
                        {
                            if (Variables.Direct == Direction.Buy) Variables.ClosePrice = Data_2[j].high;
                            else Variables.ClosePrice = Data_2[j].low;
                            Variables.CloseTime = UnixTimeHelper.UnixTimeStampToDateTime(Data_2[j].close_time);
                            break;
                        }
                        if (Data_2[j].close_time >= Data_1[i].close_time + ConverterIntToSec.Converting(Variables.ResultTime))
                        {
                            Variables.ClosePrice = Data_2[j].close;
                            Variables.CloseTime = UnixTimeHelper.UnixTimeStampToDateTime(Data_2[j].close_time);
                            break;
                        }

                    }
                    if (Data_2[j].close_time >= Data_1[i+1].close_time || j == Data_2.Count - 10)
                    {
                        break;
                    }
                }
                Variables.OpenPriceSet = false;
                Variables.StatisticModels.Add(CompleteStatistic.CreateStat());
                ShowConsole.Show(Variables.StatisticModels[Variables.StatisticModels.Count - 1]);
            }
            Console.WriteLine(GeneralStat.CalcStat());
        }
    }
}
