﻿using RycharaStockAnalizer.Helpers;
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
            for (int i = 0; i < Data_1.Count - 11; i++)
            {
                Variables.I = i;
                //if (i == 4118)
                //{
                //    Console.WriteLine();
                //}
                Variables.DayOfYears = UnixTimeHelper.UnixTimeStampToDateTime(Data_1[i].open_time).DayOfYear;

                Variables.OneDay.Add(Data_1[i]);
                if (UnixTimeHelper.UnixTimeStampToDateTime(Data_1[i+1].open_time).DayOfYear == Variables.DayOfYears)
                {
                    continue;
                }

                if (UnixTimeHelper.UnixTimeStampToDateTime(Data_1[i].close_time).DayOfWeek.ToString() == "Friday")
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
                BuySell res = Candels.IsItBull(Variables.OneDay);
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
                double OpenT = SetTime19_00.SetT();
                Variables.OpenTime = UnixTimeHelper.UnixTimeStampToDateTime(OpenT);

                for (int j = Variables.J; j < Data_2.Count-11; j++)
                {
                    Variables.J = j;
                    if (Data_2[j].open_time >= OpenT)
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
                        if (Data_2[j].close_time >= OpenT + ConverterIntToSec.Converting(Variables.ResultTime))
                        {
                            Variables.ClosePrice = Data_2[j].close;
                            if (Calculate.CalculateProfit() > (Variables.Funds / 100) * 0.5)
                            {
                                Variables.ClosePrice = Data_2[j].close;
                                Variables.CloseTime = UnixTimeHelper.UnixTimeStampToDateTime(Data_2[j].close_time);
                                break;
                            }
                        }
                        if (Data_2[j].close_time >= OpenT + ConverterIntToSec.Converting(Variables.ResultTime) * 3)
                        {
                            Variables.ClosePrice = Data_2[j].close;
                            if (Calculate.CalculateProfit() > 0)
                            {
                                Variables.ClosePrice = Data_2[j].close;
                                Variables.CloseTime = UnixTimeHelper.UnixTimeStampToDateTime(Data_2[j].close_time);
                                break;
                            }
                        }
                        if (Data_2[j].close_time >= OpenT + ConverterIntToSec.Converting(Variables.ResultTime) * 4)
                        {
                            Variables.ClosePrice = Data_2[j].close;
                            Variables.CloseTime = UnixTimeHelper.UnixTimeStampToDateTime(Data_2[j].close_time);
                            break;
                        }
                    }
                }
                if (Variables.OpenPrice != 0 && Variables.ClosePrice != 0)
                {
                    Variables.StatisticModels.Add(CompleteStatistic.CreateStat());
                    //ShowConsole.Show(Variables.StatisticModels[Variables.StatisticModels.Count - 1]);
                    ResetVars.ResetVariables();
                }
            }
            Console.WriteLine(GeneralStat.CalcStat());
            MonthStatCalc.Calc();
            WriteModel<MonthStat>.Write(Variables.MonthStatistic);
        }
    }
}
