using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Helpers
{
    public static class ResetGlobalVars
    {
        public static void Reset()
        {
            Variables.MonthStatistic.Clear();
            Variables.StatisticModels.Clear();
            Variables.LogModel = new Models.LogModel();
            //Variables.Data_1.Clear();
            //Variables.Data_2.Clear();
            Variables.I = 0;
            Variables.J = 0;
        }
    }
}
