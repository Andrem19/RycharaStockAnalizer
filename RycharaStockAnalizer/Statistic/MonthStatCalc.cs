using RycharaStockAnalizer.Helpers;
using RycharaStockAnalizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Statistic
{
    public static class MonthStatCalc
    {
        public static void Calc()
        {

            for (int i = 0; i < Variables.StatisticModels.Count; i++)
            {
                int Year = Variables.StatisticModels[i].OpenTime.Year;
                int Month = Variables.StatisticModels[i].OpenTime.Month;
                int index = Variables.MonthStatistic.FindIndex(x => x.Year == Year);
                if (index == -1)
                {
                    MonthStat model = new MonthStat(Year);
                    switch (Month)
                    {
                        case 1:
                            model.January += Variables.StatisticModels[i].Profit;
                            break;
                        case 2:
                            model.Fabruary += Variables.StatisticModels[i].Profit;
                            break;
                        case 3:
                            model.March += Variables.StatisticModels[i].Profit;
                            break;
                        case 4:
                            model.April += Variables.StatisticModels[i].Profit;
                            break;
                        case 5:
                            model.May += Variables.StatisticModels[i].Profit;
                            break;
                        case 6:
                            model.June += Variables.StatisticModels[i].Profit;
                            break;
                        case 7:
                            model.July += Variables.StatisticModels[i].Profit;
                            break;
                        case 8:
                            model.August += Variables.StatisticModels[i].Profit;
                            break;
                        case 9:
                            model.September += Variables.StatisticModels[i].Profit;
                            break;
                        case 10:
                            model.October += Variables.StatisticModels[i].Profit;
                            break;
                        case 11:
                            model.November += Variables.StatisticModels[i].Profit;
                            break;
                        case 12:
                            model.December += Variables.StatisticModels[i].Profit;
                            break;
                    }
                    Variables.MonthStatistic.Add(model);
                }
                else
                {
                    MonthStat YearModel = Variables.MonthStatistic[index];
                    switch (Month)
                    {
                        case 1:
                            YearModel.January += Variables.StatisticModels[i].Profit;
                            break;
                        case 2:
                            YearModel.Fabruary += Variables.StatisticModels[i].Profit;
                            break;
                        case 3:
                            YearModel.March += Variables.StatisticModels[i].Profit;
                            break;
                        case 4:
                            YearModel.April += Variables.StatisticModels[i].Profit;
                            break;
                        case 5:
                            YearModel.May += Variables.StatisticModels[i].Profit;
                            break;
                        case 6:
                            YearModel.June += Variables.StatisticModels[i].Profit;
                            break;
                        case 7:
                            YearModel.July += Variables.StatisticModels[i].Profit;
                            break;
                        case 8:
                            YearModel.August += Variables.StatisticModels[i].Profit;
                            break;
                        case 9:
                            YearModel.September += Variables.StatisticModels[i].Profit;
                            break;
                        case 10:
                            YearModel.October += Variables.StatisticModels[i].Profit;
                            break;
                        case 11:
                            YearModel.November += Variables.StatisticModels[i].Profit;
                            break;
                        case 12:
                            YearModel.December += Variables.StatisticModels[i].Profit;
                            break;
                    }
                }
            }
            for (int i = 0; i < Variables.MonthStatistic.Count; i++)
            {
                Variables.MonthStatistic[i].FullYear 
                    = Variables.MonthStatistic[i].January
                    + Variables.MonthStatistic[i].Fabruary
                    + Variables.MonthStatistic[i].March
                    + Variables.MonthStatistic[i].April
                    + Variables.MonthStatistic[i].May
                    + Variables.MonthStatistic[i].June
                    + Variables.MonthStatistic[i].July
                    + Variables.MonthStatistic[i].August
                    + Variables.MonthStatistic[i].September
                    + Variables.MonthStatistic[i].October
                    + Variables.MonthStatistic[i].November
                    + Variables.MonthStatistic[i].December;
            }
        }
    }
}
