
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Dominos.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Başlasın mı ? (y/n)");
            var result=Console.ReadLine();
            if (result=="y")
            {
                for (int i = 0; i < 10000; i++)
                {
                    var location = new Location()
                    {
                        src_long = GenerateCoordinate(),
                        src_lat = GenerateCoordinate(),
                        des_long = GenerateCoordinate(),
                        des_lat = GenerateCoordinate(),
                    };
                    Task task1 = Task.Factory.StartNew(() => SendRequest(location));
                }
            }
            
            Console.ReadKey();
        }


        private static async Task SendRequest(Location location)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(location);
                    Console.WriteLine(json);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var content = client.PostAsync("http://localhost:5000/api/location", data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static float GenerateCoordinate()
        {
            Random random = new Random();
            var result = (random.NextDouble()
                          * (41 - (double)21))
                         + 21;
            return (float)result;
        }
    }
}
