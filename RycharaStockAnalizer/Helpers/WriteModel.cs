using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Helpers
{
    public static class WriteModel<T>
    {
        public static void WriteList(List<T> Model)
        {
            for (int i = 0; i < Model.Count; i++)
            {
                string output = JsonConvert.SerializeObject(Model[i]);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(output);
                Console.ResetColor();
            }

        }
        public static void WriteOne(T Model)
        {
            string output = JsonConvert.SerializeObject(Model);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(output);
            Console.ResetColor();

        }
    }
}
