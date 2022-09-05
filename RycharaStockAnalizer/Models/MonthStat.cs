using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Models
{
    public class MonthStat
    {
        public MonthStat(double year)
        {
            Year = year;
        }
        public double Year { get; set; }

        public double January { get; set; } = 0;
        public double Fabruary { get; set; } = 0;
        public double March { get; set; } = 0;
        public double April { get; set; } = 0;
        public double May { get; set; } = 0;
        public double June { get; set; } = 0;
        public double July { get; set; } = 0;
        public double August { get; set; } = 0;
        public double September { get; set; } = 0;
        public double October { get; set; } = 0;
        public double November { get; set; } = 0;
        public double December { get; set; } = 0;
    }
}
