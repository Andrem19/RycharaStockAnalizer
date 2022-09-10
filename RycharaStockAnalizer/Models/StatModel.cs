using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Models
{
    public class StatModel
    {
        public int I { get; set; }
        public string Pair { get; set; }
        public string Direct { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public double OpenPrice { get; set; }
        public double ClosePrice { get; set; }
        public bool Trig { get; set; }
        public bool Trig2 { get; set; }
        public double Data_1_Vol { get; set; }
        public double Data_1_high { get; set; }
        public double Body { get; set; }
        public string DayOfWeek { get; set; }
        public double Profit { get; set; }
    }
}
