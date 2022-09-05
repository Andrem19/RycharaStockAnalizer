using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Helpers
{
    public static class ResetVars
    {
        public static void ResetVariables()
        {
            Variables.OpenPrice = 0;
            Variables.ClosePrice = 0;
            Variables.OpenPriceSet = false;
            Variables.ExitByTrigger = false;
        }
    }
}
