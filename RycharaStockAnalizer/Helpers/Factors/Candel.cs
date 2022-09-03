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
            if (model.open >= model.close)
            {
                return false;
            }
            return true;
        }
    }
}
