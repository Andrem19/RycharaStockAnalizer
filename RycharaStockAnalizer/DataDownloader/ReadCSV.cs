using RycharaStockAnalizer.Helpers;
using RycharaStockAnalizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.DataDownloader
{
    public static class ReadCSV
    {
        public async static Task<List<DataModel>> ReadData(string symbol, string timeframe, bool spx)
        {
            string old = Variables.DataToTest == true ? "old" : "";
            List<DataModel> values = File.ReadAllLines($"C:\\Users\\72555\\Desktop\\MarketData2\\{symbol}\\{old}{timeframe}{symbol}.csv")
                                          .Select(v => FromCsv(v, spx))
                                          .ToList();
            return values;
        }
        public static DataModel FromCsv(string csvLine, bool spx)
        {
            DataModel dailyValues = new DataModel();
            string[] values = csvLine.Split(',');
            if (spx)
            {
                dailyValues.open_time = UnixTimeHelper.ToUnixTimeMilliSeconds(UnixTimeHelper.StringToDate(values[0], false)) / 1000;
                dailyValues.open = Convert.ToDouble(values[1]);
                dailyValues.high = Convert.ToDouble(values[2]);
                dailyValues.low = Convert.ToDouble(values[3]);
                dailyValues.close = Convert.ToDouble(values[4]);
                dailyValues.volume = Convert.ToDouble(values[5]);
                dailyValues.close_time = UnixTimeHelper.ToUnixTimeMilliSeconds(UnixTimeHelper.StringToDate(values[0], true)) / 1000;
            }
            else
            {
                dailyValues.open_time = Convert.ToInt64(values[0]) / 1000;
                dailyValues.open = Convert.ToDouble(values[1]);
                dailyValues.high = Convert.ToDouble(values[2]);
                dailyValues.low = Convert.ToDouble(values[3]);
                dailyValues.close = Convert.ToDouble(values[4]);
                dailyValues.volume = Convert.ToDouble(values[5]);
                dailyValues.close_time = Convert.ToInt64(values[6]) / 1000;
            }
            return dailyValues;
        }
    }
}
