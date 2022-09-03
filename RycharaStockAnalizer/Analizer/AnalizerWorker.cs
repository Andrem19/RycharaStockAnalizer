using RycharaStockAnalizer.Helpers;
using RycharaStockAnalizer.Helpers.Factors;
using RycharaStockAnalizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Analizer
{
    public static class AnalizerWorker
    {
        public static async Task Worker(List<DataModel> Data_1, List<DataModel> Data_2)
        {
            for (int i = 0; i < Data_1.Count; i++)
            {
                Variables.I = i;
                Variables.Direct = Candel.IsItBull(Data_1[i]) ? Direction.Buy : Direction.Sell;

                double timeCheck = Data_1[i].close_time + ConverterIntToSec.Converting(Variables.ResultTime);
                //for (int i = 0; i < length; i++)
                //{

                //}
                //var openCandel = Data_2.FirstOrDefault(x => x.open_time >= Data_1[i].close_time && x.open_time < Data_1[i + 1].close_time);
                //var closeCandel = Data_2.FirstOrDefault(x => x.close_time >= timeCheck && x.close_time < timeCheck + ConverterIntToSec.Converting(Variables.Data_2_TimeInterval));
                


            }
        }
    }
}
