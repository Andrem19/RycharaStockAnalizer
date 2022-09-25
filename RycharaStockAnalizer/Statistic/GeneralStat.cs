using Newtonsoft.Json;
using RycharaStockAnalizer.Helpers;
using RycharaStockAnalizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plotly.NET.CSharp;
using static Plotly.NET.StyleParam.LinearAxisId;

namespace RycharaStockAnalizer.Statistic
{
    public static class GeneralStat
    {
        public async static void CalcStat()
        {
            int success = 0;
            int fail = 0;
            int SellSuccess = 0;
            int BuySuccess = 0;
            int SellFail = 0;
            int BuyFail = 0;
            double VolSuccess = 0;
            double VolFail = 0;
            double HighSuccess = 0;
            double HighFail = 0;
            double Profit = 0;
            double BodySuccess = 0;
            double BodyFail = 0;
            int SuccessTrig = 0;
            int FailTrig = 0;
            int SuccessTrig2 = 0;
            int FailTrig2 = 0;
            double AvProfP = 0;
            double AvProfM = 0;
            int Monday = 0;
            int Tuesday = 0;
            int Wednesday = 0;
            int Thursday = 0;
            int Friday = 0;
            int MondayM = 0;
            int TuesdayM = 0;
            int WednesdayM = 0;
            int ThursdayM = 0;
            int FridayM = 0;
            for (int i = 0; i < Variables.StatisticModels.Count; i++)
            {
                Profit += Variables.StatisticModels[i].Profit;
                if (Variables.StatisticModels[i].Profit > 0)
                {
                    switch (Variables.StatisticModels[i].DayOfWeek)
                    {
                        case "Monday":
                            Monday++;
                            break;
                        case "Tuesday":
                            Tuesday++;
                            break;
                        case "Wednesday":
                            Wednesday++;
                            break;
                        case "Thursday":
                            Thursday++;
                            break;
                        case "Friday":
                            Friday++;
                            break;
                    }
                    AvProfP += Variables.StatisticModels[i].Profit;
                    if (Variables.StatisticModels[i].Direct == Direction.Buy.ToString())
                    {
                        BuySuccess++;
                    }
                    else if (Variables.StatisticModels[i].Direct == Direction.Sell.ToString())
                    {
                        SellSuccess++;
                    }
                    VolSuccess += Variables.StatisticModels[i].Data_1_Vol;
                    HighSuccess += Variables.StatisticModels[i].Data_1_high;
                    BodySuccess += Variables.StatisticModels[i].Body;
                    if (Variables.StatisticModels[i].Trig) SuccessTrig++;
                    if (Variables.StatisticModels[i].Trig2) SuccessTrig2++;
                    success++;
                }
                else if (Variables.StatisticModels[i].Profit < 0)
                {
                    switch (Variables.StatisticModels[i].DayOfWeek)
                    {
                        case "Monday":
                            MondayM++;
                            break;
                        case "Tuesday":
                            TuesdayM++;
                            break;
                        case "Wednesday":
                            WednesdayM++;
                            break;
                        case "Thursday":
                            ThursdayM++;
                            break;
                        case "Friday":
                            FridayM++;
                            break;
                    }
                    AvProfM += Variables.StatisticModels[i].Profit;
                    if (Variables.StatisticModels[i].Direct == Direction.Buy.ToString())
                    {
                        BuyFail++;
                    }
                    else if (Variables.StatisticModels[i].Direct == Direction.Sell.ToString())
                    {
                        SellFail++;
                    }
                    VolFail += Variables.StatisticModels[i].Data_1_Vol;
                    HighFail += Variables.StatisticModels[i].Data_1_high;
                    BodyFail += Variables.StatisticModels[i].Body;
                    if (Variables.StatisticModels[i].Trig) FailTrig++;
                    if (Variables.StatisticModels[i].Trig2) FailTrig2++;
                    fail++;
                }
                
            }
            double all = success + fail;
            double onePerc = all / 100;
            double percent = Math.Round(success / onePerc, 3);
            double VSuc = VolSuccess / success;
            double VFail = VolFail / fail;
            double HSuc = HighSuccess / success;
            double HFail = HighFail / fail;
            double BSuc = BodySuccess / success;
            double BFail = BodyFail / fail;
            double AvarageProfP = AvProfP / success;
            double AvarageProfM = AvProfM / fail;
            int MonthSC = 0;
            int MonthFL = 0;
            MonthStatCalc.Calc();
            for (int i = 0; i < Variables.MonthStatistic.Count; i++)
            {
                if (Variables.MonthStatistic[i].January > 0 && Variables.MonthStatistic[i].January != 0) MonthSC += 1;
                else if (Variables.MonthStatistic[i].January != 0) MonthFL += 1;
                if (Variables.MonthStatistic[i].Fabruary > 0 && Variables.MonthStatistic[i].Fabruary != 0) MonthSC += 1;
                else if (Variables.MonthStatistic[i].Fabruary != 0) MonthFL += 1;
                if (Variables.MonthStatistic[i].March > 0 && Variables.MonthStatistic[i].March != 0) MonthSC += 1;
                else if (Variables.MonthStatistic[i].March != 0) MonthFL += 1;
                if (Variables.MonthStatistic[i].April > 0 && Variables.MonthStatistic[i].April != 0) MonthSC += 1;
                else if (Variables.MonthStatistic[i].April != 0) MonthFL += 1;
                if (Variables.MonthStatistic[i].May > 0 && Variables.MonthStatistic[i].May != 0) MonthSC += 1;
                else if (Variables.MonthStatistic[i].May != 0) MonthFL += 1;
                if (Variables.MonthStatistic[i].June > 0 && Variables.MonthStatistic[i].June != 0) MonthSC += 1;
                else if (Variables.MonthStatistic[i].June != 0) MonthFL += 1;
                if (Variables.MonthStatistic[i].July > 0 && Variables.MonthStatistic[i].July != 0) MonthSC += 1;
                else if (Variables.MonthStatistic[i].July != 0) MonthFL += 1;
                if (Variables.MonthStatistic[i].August > 0 && Variables.MonthStatistic[i].August != 0) MonthSC += 1;
                else if (Variables.MonthStatistic[i].August != 0) MonthFL += 1;
                if (Variables.MonthStatistic[i].September > 0 && Variables.MonthStatistic[i].September != 0) MonthSC += 1;
                else if (Variables.MonthStatistic[i].September != 0) MonthFL += 1;
                if (Variables.MonthStatistic[i].October > 0 && Variables.MonthStatistic[i].October != 0) MonthSC += 1;
                else if (Variables.MonthStatistic[i].October != 0) MonthFL += 1;
                if (Variables.MonthStatistic[i].November > 0 && Variables.MonthStatistic[i].November != 0) MonthSC += 1;
                else if (Variables.MonthStatistic[i].November != 0) MonthFL += 1;
                if (Variables.MonthStatistic[i].December > 0 && Variables.MonthStatistic[i].December != 0) MonthSC += 1;
                else if (Variables.MonthStatistic[i].December != 0) MonthFL += 1;

            }
            List<double> line = new List<double>();
            for (int i = 0; i < Variables.MonthStatistic.Count; i++)
            {
                line.Add(Variables.MonthStatistic[i].January);
                line.Add(Variables.MonthStatistic[i].Fabruary);
                line.Add(Variables.MonthStatistic[i].March);
                line.Add(Variables.MonthStatistic[i].April);
                line.Add(Variables.MonthStatistic[i].May);
                line.Add(Variables.MonthStatistic[i].June);
                line.Add(Variables.MonthStatistic[i].July);
                line.Add(Variables.MonthStatistic[i].August);
                line.Add(Variables.MonthStatistic[i].September);
                line.Add(Variables.MonthStatistic[i].October);
                line.Add(Variables.MonthStatistic[i].November);
                line.Add(Variables.MonthStatistic[i].December);
            }
            Variables.LogModel.Profit = Math.Round(Profit, 3);
            Variables.LogModel.PercSC = percent;
            Variables.LogModel.PercentForTriggerM = Variables.PercentForTriggerM;
            Variables.LogModel.PercentForTriggerP = Variables.PercentForTriggerP;
            Variables.LogModel.ResultTime1 = Variables.ResultTime1;
            Variables.LogModel.ResultTime2 = Variables.ResultTime2;
            Variables.LogModel.PercSecExitP = Variables.PercForSecExitP;
            Variables.LogModel.PercSecExitM = Variables.PercForSecExitM;
            Variables.LogModel.Count = Variables.StatisticModels.Count;
            //Variables.LogModel.FactorLong = Variables.FactorLong;
            Variables.LogModel.FactorCandel = Variables.FactorCandel;
            Variables.LogModel.FactorCandelStart = Variables.FactorCandelStart;
            Variables.LogModel.MonthSCFL = MonthSC.ToString() + "/" + MonthFL.ToString();
            Variables.LogModel.AvProfSCFL = AvarageProfP.ToString() + "/" + AvarageProfM.ToString();
            if (Variables.SingleMod)
            {
                Console.WriteLine($"Success: {success} Fail: {fail} ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"PercentSC: {percent} Profit: {Math.Round(Profit, 3)}  SuccessTrig: {SuccessTrig} FailTrig: {FailTrig} SuccessTrig2: {SuccessTrig2} FailTrig2: {FailTrig2} AvProfP: {AvarageProfP} AvProfM: {AvarageProfM} BuySuccess: {BuySuccess} SellSuccess: {SellSuccess} BuyFail: {BuyFail} SellFail: {SellFail}");
                Console.ResetColor();
                Console.WriteLine($" Monday: {Monday} Tuesday: {Tuesday} Wednesday: {Wednesday} Thursday: {Thursday} Friday: {Friday} | MondayM: {MondayM} TuesdayM: {TuesdayM} WednesdayM: {WednesdayM} ThursdayM: {ThursdayM} FridayM: {FridayM} VolSuccess: {VSuc} VolFail: {VFail} HighSuccess: {HSuc} HighFail: {HFail} BodySuccess: {BSuc} BodyFail: {BFail}");
                Console.WriteLine(JsonConvert.SerializeObject(Variables.LogModel));
                string path = Path.Combine(Environment.CurrentDirectory, "Data2");
                Chart.Column<double, double, string>(line).SaveHtml(path, true);
            }
            else
            {
                if (Variables.LastPriceFind < Profit || (Variables.LastPercentFind < percent && Profit > 200))
                {
                    if (Variables.LastPriceFind < Profit) Variables.LastPriceFind = Profit;
                    if (Variables.LastPercentFind < percent) Variables.LastPercentFind = percent;
                    await SaveLog.Logging("Logging", Variables.LogModel);
                }
            }
            if (MonthFL <= 10 && Profit > 210)
            {
                WriteModel<LogModel>.WriteOne(Variables.LogModel);
            }
        }
    }
}
