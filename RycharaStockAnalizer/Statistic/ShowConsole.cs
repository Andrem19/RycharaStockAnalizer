using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Statistic
{
    public static class ShowConsole
    {
        public static string Show(double profit)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Variables.Symbol_Data_1}-{Variables.Symbol_Data_2}");
            sb.Append($"{Variables.OpenTime}--{Variables.CloseTime}");
            sb.Append($"Profit: {profit}");
            sb.Append($"{Variables.Direct.ToString()}");

            if (profit > 0) Console.ForegroundColor = ConsoleColor.Magenta;
            else Console.ForegroundColor = ConsoleColor.Red;
            if (Variables.ShowConsole)
            {
                Console.WriteLine(sb.ToString());
            }
            Console.ResetColor();

            return sb.ToString();
        }
    }
}
