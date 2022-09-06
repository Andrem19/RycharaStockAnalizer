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
            return $"Success: {success} Fail: {fail} PercentSC: {percent} Profit: {Math.Round(Profit, 3)} Monday: {Monday} Tuesday: {Tuesday} Wednesday: {Wednesday} Thursday: {Thursday} Friday: {Friday} | MondayM: {MondayM} TuesdayM: {TuesdayM} WednesdayM: {WednesdayM} ThursdayM: {ThursdayM} FridayM: {FridayM} SuccessTrig: {SuccessTrig} FailTrig: {FailTrig} AvProfP: {AvarageProfP} AvProfM: {AvarageProfM}";
            //BuySuccess: {BuySuccess} SellSuccess: {SellSuccess} BuyFail: {BuyFail} SellFail: {SellFail} VolSuccess: {VSuc} VolFail: {VFail} HighSuccess: {HSuc} HighFail: {HFail} BodySuccess: {BSuc} BodyFail: {BFail}
            //SuccessTrig: {SuccessTrig} FailTrig: {FailTrig} AvProfP: {AvarageProfP} AvProfM: {AvarageProfM}
        }
    }
}
