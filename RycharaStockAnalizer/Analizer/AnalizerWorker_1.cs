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
            for (int i = 2; i < Data_1.Count - 2; i++)
            {
                if (UnixTimeHelper.UnixTimeStampToDateTime(Data_1[i].close_time).DayOfWeek.ToString() == "Thursday")
                {
                    Variables.Funds = 200;
                }
                else if (UnixTimeHelper.UnixTimeStampToDateTime(Data_1[i].close_time).DayOfWeek.ToString() == "Monday")
                {
                    continue;
                }
                else
                {
                    Variables.Funds = 100;
                }
                Variables.I = i;
                BuySell res = Candel.IsItBull(Data_1[i]);
                if (res == BuySell.Buy)
                {
                    Variables.Direct = Direction.Buy;
                }
                else if (res == BuySell.Sell)
                {
                    Variables.Direct = Direction.Sell;
                }
                else
                {
                    continue;
                }

                double timeCheck = Data_1[i].close_time + ConverterIntToSec.Converting(Variables.ResultTime1);
                Variables.OpenTime = UnixTimeHelper.UnixTimeStampToDateTime(Data_1[i].close_time);
                for (int j = Variables.J; j < Data_2.Count; j++)
                {
                    Variables.J = j;
                    if (Data_2[j].open_time >= Data_1[i].close_time && Data_2[j].open_time < Data_1[i+1].close_time)
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
                        if (Data_2[j].close_time >= Data_1[i].close_time + ConverterIntToSec.Converting(Variables.ResultTime1))
                        {
                            Variables.ClosePrice = Data_2[j].close;
                            if (Calculate.CalculateProfit() > (Variables.Funds /100) * 0.5)
                            {
                                Variables.ClosePrice = Data_2[j].close;
                                Variables.CloseTime = UnixTimeHelper.UnixTimeStampToDateTime(Data_2[j].close_time);
                                break;
                            }
                        }
                        if (Data_2[j].close_time >= Data_1[i].close_time + ConverterIntToSec.Converting(Variables.ResultTime1) * 2)
                        {
                            Variables.ClosePrice = Data_2[j].close;
                            if (Calculate.CalculateProfit() > 0)
                            {
                                Variables.ClosePrice = Data_2[j].close;
                                Variables.CloseTime = UnixTimeHelper.UnixTimeStampToDateTime(Data_2[j].close_time);
                                break;
                            }
                        }
                        if (Data_2[j].close_time >= Data_1[i].close_time + ConverterIntToSec.Converting(Variables.ResultTime1) * 3)
                        {
                            Variables.ClosePrice = Data_2[j].close;
                            Variables.CloseTime = UnixTimeHelper.UnixTimeStampToDateTime(Data_2[j].close_time);
                            break;
                        }
                    }
                }
                if (Variables.OpenPrice != 0 || Variables.ClosePrice != 0)
                {
                    Variables.StatisticModels.Add(CompleteStatistic.CreateStat());
                    ShowConsole.Show(Variables.StatisticModels[Variables.StatisticModels.Count - 1]);
                    ResetVars.ResetVariables();
                }
            }
            GeneralStat.CalcStat();
            MonthStatCalc.Calc();
            WriteModel<MonthStat>.WriteList(Variables.MonthStatistic);
        }
    }
}
