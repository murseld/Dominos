using Dominos.Core.Domain.Messages;
using System;

namespace Dominos.Services.TextWrite.Domain.Events
{
    [MessageNamespace("LocationCreatedEvent")]
    public class LocationCreatedEvent : IEvent
    {
        public Guid commandId { get; set; }
        public double src_long { get; set; }
        public double src_lat { get; set; }
        public double des_long { get; set; }
        public double des_lat { get; set; }
        public DateTime CreateDate { get; set; }
        public double distance { get; set; }

        public LocationCreatedEvent(double srcLong, double srcLat, double desLong, double desLat,double dist)
        {
            commandId = Guid.NewGuid();
            src_long = srcLong;
            src_lat = srcLat;
            des_long = desLong;
            des_lat = desLat;
            CreateDate = DateTime.Now;
            distance = dist;
        }
    }
}
