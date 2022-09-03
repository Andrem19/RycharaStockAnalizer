using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Statistic
{
    public static class ExchangeFee
    {
        public static double ExFee(double amount, double price)
        {
            double sum = amount * price;
            double exfeeT = sum * Variables.ExchangeFeeTaker;
            double exfeeM = sum * Variables.ExchangeFeeMaker;
            double exfeeSum = exfeeT + exfeeM;
            Variables.ExFee += exfeeSum;
            return exfeeSum;
        }
    }
}
