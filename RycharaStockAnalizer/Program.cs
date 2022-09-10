using RycharaStockAnalizer.Core;
using RycharaStockAnalizer.Helpers;
using RycharaStockAnalizer.Statistic;

namespace RycharaStockAnalizer
{
    public class Program
    {
        public static async Task Main()
        {
            //await Engine_1.EngineRun();
            //ResetGlobalVars.Reset();
            if (Variables.SingleMod)
            {
                await Engine_2Single.EngineRun();
            }
            else
            {
                await Engine_2Multi.EngineRun();
            }
            
        }
    }
}
