using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Helpers
{
    public static class SetTime19_00
    {
        public static double SetT()
        {
            DateTime res = UnixTimeHelper.UnixTimeStampToDateTime(Variables.OneDay[Variables.OneDay.Count - 1].close_time);
            return UnixTimeHelper.ToUnixTimeMilliSeconds(new DateTime(res.Year, res.Month, res.Day, 19, 30, 0, 0))/1000;
        }
    }
}
