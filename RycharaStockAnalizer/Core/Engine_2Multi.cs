using RycharaStockAnalizer.Analizer;
using RycharaStockAnalizer.DataDownloader;
using RycharaStockAnalizer.Helpers;
using RycharaStockAnalizer.Models;
using RycharaStockAnalizer.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Core
{
    public static class Engine_2Multi
    {
        public async static Task EngineRun()
        {
            Variables.Data_1_TimeInterval = "1h";
            Variables.Data_1 = await ReadCSV.ReadData(Variables.Symbol_Data_1, Variables.Data_1_TimeInterval, false);
            Variables.Data_2 = await ReadCSV.ReadData(Variables.Symbol_Data_2, Variables.Data_2_TimeInterval, false);
            Variables.TimeLoop = DateTimeOffset.Now.ToUnixTimeSeconds();
            int border = 6000;
            while (true)
            {
                double rand3 = GetRandom.GetRandomNumber(1, 24);
                int limit = 24 - (int)rand3;
                double rand4 = rand3 + GetRandom.GetRandomNumber(1, limit);
                double kofP = (double)GetRandom.GetRandomNumber(100, 3000) /1000;
                double kof2 = (double)GetRandom.GetRandomNumber(100, border)/1000;
                double digit = kof2 * 1000;
                double kof3 = (double)GetRandom.GetRandomNumber(100, (int)digit)/1000;
                double kofM = (double)GetRandom.GetRandomNumber(100, 2500) / 1000;
                if (kofM>kofP) kofM = kofP;
                Variables.FactorCandel = GetRandom.GetRandomNumber(1, 6);
                //%2==0? 4 : 1;
                //Variables.FactorLong = GetRandom.GetRandomNumber(4, 10);
                int digit2 = 6 - (int)Variables.FactorCandel;
                if (digit2 > Variables.FactorCandel) digit2 = (int)Variables.FactorCandel;
                Variables.FactorCandelStart = GetRandom.GetRandomNumber(0, digit2);
                Variables.PercForSecExitP = kofP;
                Variables.PercForSecExitM = kofM;
                Variables.PercentForTriggerP = kof2;
                Variables.PercentForTriggerM = kof3;
                Variables.ResultTime1 = rand3.ToString() + "h";
                Variables.ResultTime2 = rand4.ToString() + "h";
                await AnalizerWorker_2.Worker(Variables.Data_1, Variables.Data_2);
                ResetGlobalVars.Reset();
                if (Variables.TimeLoop < DateTimeOffset.Now.ToUnixTimeSeconds() - 600)
                {
                    Variables.TimeLoop = DateTimeOffset.Now.ToUnixTimeSeconds();
                    Variables.LastPriceFind = 100;
                    Variables.LastPercentFind = 40;
                    LogModel space = new();
                    border = border == 5000 ? 6000 : 5000;
                    await SaveLog.Logging("Logging", space);
                }
            }
        }
    }
}
