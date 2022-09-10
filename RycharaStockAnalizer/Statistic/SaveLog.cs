using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RycharaStockAnalizer.Statistic
{
    public static class SaveLog
    {
        public async static Task Logging(string? filename, object model)
        {
            string output = JsonConvert.SerializeObject(model);
            if (Variables.Logging)
            {
                string folderName = $"{DateTimeOffset.UtcNow.Year}--{Variables.Symbol_Data_1}-{Variables.Symbol_Data_2}";
                if (!Directory.Exists(folderName))
                {
                    Directory.CreateDirectory(folderName);
                }
                string path = Path.Combine(folderName, $"{filename}-{DateTimeOffset.UtcNow.Month}-{DateTimeOffset.UtcNow.Year}--{Variables.Symbol_Data_1}-{Variables.Symbol_Data_2}.txt");
                using (FileStream file = new FileStream(path, FileMode.Append))
                using (StreamWriter stream = new StreamWriter(file))
                    stream.WriteLine(output);
            }
        }
    }
}
