using System;
using Dominos.Core.Domain.Messages;

namespace Dominos.ApiGateway.Domain.Commands
{
    [MessageNamespace("location")]
    public class CreateLocationCommand : ICommand
    {
        public Guid commandId { get; set; }
        public double src_long { get; set; }
        public double src_lat { get; set; }
        public double des_long { get; set; }
        public double des_lat { get; set; }
        public DateTime CreateDate { get; set; }

        public CreateLocationCommand(double srcLong, double srcLat, double desLong, double desLat)
        {
            commandId = Guid.NewGuid();
            src_long = srcLong;
            src_lat = srcLat;
            des_long = desLong;
            des_lat = desLat;
            CreateDate = DateTime.Now;
        }
    }
}
