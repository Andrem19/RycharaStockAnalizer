using RycharaStockAnalizer.Analizer;
using RycharaStockAnalizer.DataDownloader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Core
{
    public static class Engine_1
    {
        public async static Task EngineRun()
        {
            Variables.Data_1_TimeInterval = "1d";
            bool trig = Variables.Symbol_Data_1 == "SPX500"? true : false;
            Variables.Data_1 = await ReadCSV.ReadData(Variables.Symbol_Data_1, Variables.Data_1_TimeInterval, trig);
            Variables.Data_2 = await ReadCSV.ReadData(Variables.Symbol_Data_2, Variables.Data_2_TimeInterval, false);

            await AnalizerWorker_1.Worker(Variables.Data_1, Variables.Data_2);

        }
    }
}
