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
        public static string Symbol_Data_1 { get; set; } = "SPX500";
        public static List<DataModel> Data_1 { get; set; } = new List<DataModel>();
        public static string Data_1_TimeInterval = "1d";
        public static string Symbol_Data_2 { get; set; } = "ETHUSDT";
        public static List<DataModel> Data_2 { get; set; } = new List<DataModel>();
        public static string Data_2_TimeInterval = "5m";
        public static string ResultTime = "5h";

        //Working variables
        public static Direction Direct { get; set; } = Direction.Buy;
        public static double OpenPrice { get; set; }
        public static double ClosePrice { get; set; }


        public static double Funds { get; set; } = 20;
        public static double Amount { get; set; }
        public static double BaseAmount { get; set; } = 1;
        public static int Digit { get; set; } = 3;
        public static int I { get; set; }



        public static bool DataToTest { get; set; } = false;
    }
}
