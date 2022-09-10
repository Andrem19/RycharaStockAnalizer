using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Models
{
    public class LogModel
    {
        public double Profit { get; set; }
        public int Count { get; set; }
        public string MonthSCFL { get; set; }
        public string AvProfSCFL { get; set; }
        public double PercSC { get; set; }
        public double PercentForTriggerP { get; set; }
        public double PercentForTriggerM { get; set; }
        public double PercSecExitP { get; set; }
        public double PercSecExitM { get; set; }
        public string ResultTime1 { get; set; }
        public string ResultTime2 { get; set; }
        //public double FactorLong { get; set; }
        public double FactorCandel { get; set; }
        public double FactorCandelStart { get; set; }
    }
}
