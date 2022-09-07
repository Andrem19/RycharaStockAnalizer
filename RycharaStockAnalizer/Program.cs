using RycharaStockAnalizer.Core;
using RycharaStockAnalizer.Statistic;

namespace RycharaStockAnalizer
{
    public class Program
    {
        public static async Task Main()
        {
            //await Engine_1.EngineRun();
            //Variables.MonthStatistic.Clear();
            //Variables.StatisticModels.Clear();
            //Variables.Data_1.Clear();
            //Variables.Data_2.Clear();
            //Variables.I = 0;
            //Variables.J = 0;
            for (int i = 0; i < 100; i++)
            {
                await Engine_2.EngineRun();
                Variables.MonthStatistic.Clear();
                Variables.StatisticModels.Clear();
                Variables.Data_1.Clear();
                Variables.Data_2.Clear();
                Variables.I = 0;
                Variables.J = 0;
            }
            

            //int cou = Variables.StatisticModels1.Count > Variables.StatisticModels2.Count ? Variables.StatisticModels1.Count : Variables.StatisticModels2.Count;
            //for (int i = 0; i < cou; i++)
            //{
            //    ShowConsole.Show(Variables.StatisticModels1[i]);
            //    ShowConsole.Show(Variables.StatisticModels2[i+1]);
            //}
        }
    }
}
