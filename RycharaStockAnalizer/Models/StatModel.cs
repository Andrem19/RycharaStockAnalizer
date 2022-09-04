using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Models
{
    public class StatModel
    {
        public int Iter { get; set; }
        public string Pair { get; set; }
        public Direction Direct { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public double Profit { get; set; }
    }
}
