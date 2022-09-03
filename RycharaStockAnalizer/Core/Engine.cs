using RycharaStockAnalizer.Analizer;
using RycharaStockAnalizer.DataDownloader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Core
{
    public static class Engine
    {
        public async static void EngineRun()
        {
            Variables.Data_1 = await ReadCSV.ReadData(Variables.Symbol_Data_1, Variables.Data_1_TimeInterval, true);
            Variables.Data_2 = await ReadCSV.ReadData(Variables.Symbol_Data_2, Variables.Data_2_TimeInterval, false);
            while (true)
            {
                await AnalizerWorker.Worker(Variables.Data_1, Variables.Data_2);
            }
        }
    }
}
