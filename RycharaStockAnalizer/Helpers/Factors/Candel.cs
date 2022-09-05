using RycharaStockAnalizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Helpers.Factors
{
    public static class Candel
    {
        public static bool IsItBull(DataModel model)
        {
            if (Variables.Data_1[Variables.I].open >= Variables.Data_1[Variables.I].close)
            {
                return false;
            }
            return true;
        }
    }
}
