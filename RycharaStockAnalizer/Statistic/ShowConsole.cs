using Newtonsoft.Json;
using RycharaStockAnalizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Statistic
{
    public static class ShowConsole
    {
        public static string Show(StatModel model)
        {
            string output = JsonConvert.SerializeObject(model);
            //StringBuilder sb = new StringBuilder();
            //sb.Append($"{Variables.I} ");
            //sb.Append($"{model.Pair}");
            //sb.Append($"{model.OpenTime}--{model.CloseTime}");
            //sb.Append($" Profit: {model.Profit}");
            //sb.Append($" {model.Direct.ToString()}");

            if (model.Profit > 0) Console.ForegroundColor = ConsoleColor.Green;
            else Console.ForegroundColor = ConsoleColor.Red;
            if (Variables.ShowConsole)
            {
                Console.WriteLine(output);
            }
            Console.ResetColor();

            return output;
        }
    }
}
