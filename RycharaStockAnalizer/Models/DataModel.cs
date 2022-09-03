using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Models
{
    public class DataModel
    {
        public double open_time { get; set; }
        public double open { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double close { get; set; }
        public double volume { get; set; }
        public double close_time { get; set; }
    }
    public class Result
    {
        public List<List<double>> list { get; set; }
    }

    public class Root
    {
        public Result result { get; set; }
    }
}
