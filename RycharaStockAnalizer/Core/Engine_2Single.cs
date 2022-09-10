using RycharaStockAnalizer.Analizer;
using RycharaStockAnalizer.DataDownloader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Core
{
    public static class Engine_2Single
    {
        public async static Task EngineRun()
        {
            Variables.Data_1_TimeInterval = "1h";
            Variables.Data_1 = await ReadCSV.ReadData(Variables.Symbol_Data_1, Variables.Data_1_TimeInterval, false);
            Variables.Data_2 = await ReadCSV.ReadData(Variables.Symbol_Data_2, Variables.Data_2_TimeInterval, false);

            await AnalizerWorker_2.Worker(Variables.Data_1, Variables.Data_2);
        }
    }
}
