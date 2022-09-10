using RycharaStockAnalizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer
{
    public enum Direction {
        Buy,
        Sell
    }
    public static class Variables
    {
        //Settings 1
        public static string Symbol_Data_1 { get; set; } = "SPX500";
        public static List<DataModel> Data_1 { get; set; } = new List<DataModel>();
        public static string Data_1_TimeInterval = "1h";
        public static string Symbol_Data_2 { get; set; } = "ETHUSDT";
        public static List<DataModel> Data_2 { get; set; } = new List<DataModel>();
        public static string Data_2_TimeInterval = "15m";
        public static string ResultTime1 = "6h";
        public static string ResultTime2 = "10h";
        //Settings 2
        public static bool ShowConsole { get; set; } = true;
        public static bool Logging { get; set; } = true;
        public static double PercentForTriggerP { get; set; } = 4.0;
        public static double PercentForTriggerM { get; set; } = 3.5;
        public static double PercForSecExitP { get; set; } = 0.2;
        public static double PercForSecExitM { get; set; } = 2.0;
        public static double ExchangeFeeTaker { get; set; } = 0.00040;
        public static double ExchangeFeeMaker { get; set; } = 0.00020;

        //Working variables
        public static long TimeLoop { get; set; }
        public static double LastPriceFind { get; set; } = 100;
        public static double LastPercentFind { get; set; } = 40;
        public static bool SingleMod { get; set; } = true;
        public static Direction Direct { get; set; } = Direction.Buy;
        public static double OpenPrice { get; set; }
        public static bool OpenPriceSet { get; set; } = false;
        public static DateTime OpenTime { get; set; }
        public static double ClosePrice { get; set; }
        public static double CloseLimitP { get; set; }
        public static double CloseLimitM { get; set; }
        public static double SecCloseLimitP { get; set; }
        public static double SecCloseLimitM { get; set; }
        public static DateTime CloseTime { get; set; }
        public static int DayOfYears { get; set; }
        public static double ExFee { get; set; }
        public static bool ExitByTrigger { get; set; } = false;
        public static bool ExitByTrigger2 { get; set; } = false;
        public static LogModel LogModel { get; set; } = new LogModel();
        public static List<DataModel> OneDay { get; set; } = new List<DataModel>();
        public static List<StatModel> StatisticModels { get; set; } = new List<StatModel>();
        public static List<MonthStat> MonthStatistic { get; set; } = new List<MonthStat>();
        public static double Body { get; set; }
        public static double High { get; set; }
        public static double Vol { get; set; }
        //=====================================
        public static int FactorCandelStart { get; set; } = 0;
        public static double FactorCandel { get; set; } = 4;
        public static double FactorLong { get; set; } = 0;
        public static double Funds { get; set; } = 100;
        public static double Amount { get; set; }
        public static double BaseAmount { get; set; } = 1;
        public static int Digit { get; set; } = 3;
        public static int I { get; set; }
        public static int J { get; set; } = 0;


        public static bool DataToTest { get; set; } = false;
    }
}
