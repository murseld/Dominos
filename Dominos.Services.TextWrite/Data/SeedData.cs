using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominos.Services.TextWrite.Data
{
    public class SeedData
    {
        public static async void CreateTextFile()
        {
            var fileName = Directory.GetCurrentDirectory() + "/output.txt";
            if (!File.Exists(fileName))
            {
                var encodedText = 
                    Encoding.Unicode.GetBytes($"source_latitude \t source_longitude \t destination_latitude  \t destination_longitude \t distance \n");
                using (FileStream fs = File.Create(fileName))
                {
                    await fs.WriteAsync(encodedText, 0, encodedText.Length);
                }
            }
        }
    }
}
