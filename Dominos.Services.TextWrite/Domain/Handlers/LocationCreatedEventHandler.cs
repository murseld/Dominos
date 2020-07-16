
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Dominos.Core.Bus;
using Dominos.Core.Domain.MessagesHandlers;
using Dominos.Services.TextWrite.Domain.Events;
using Microsoft.Win32.SafeHandles;

namespace Dominos.Services.TextWrite.Domain.Handlers
{
    public class LocationCreatedEventHandler : IEventHandler<LocationCreatedEvent>
    {

        public LocationCreatedEventHandler()
        {
            
        }
        public async Task HandleAsync(LocationCreatedEvent _event, ICorrelationContext context)
        {
            var locationContent = ToTable(_event);
            var filePath = Directory.GetCurrentDirectory()+"/output.txt";
            WriteTextAsync(filePath, locationContent);
        }


        private async Task WriteTextAsync(string filePath, string text)
        {
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLineAsync(text);
            }
            //var encodedText = Encoding.Unicode.GetBytes(text);
            //await using (var sourceStream =
            //    new FileStream(filePath,
            //        FileMode.Append,
            //        FileAccess.Write,
            //        FileShare.None,
            //        bufferSize: 4096,
            //        useAsync: true))
            //{

            //    await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            //}
        }

        private static string ToTable(LocationCreatedEvent location)
        {
            //$"source_latitude \t source_longitude \t destination_latitude  \t destination_longitude \t distance \n"
            return  $"{location.src_long}\t{location.src_lat}\t{location.des_long}\t{location.des_lat}\t{location.distance}\n";
        }
    }
}
