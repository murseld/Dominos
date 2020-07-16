using System;
using Dominos.Core.Entities;

namespace Dominos.Services.DbWrite.Data.Dtos
{
    public class LocationDto:IEntity
    {
        public int id { get; set; }
        public double src_long { get; set; }
        public double src_lat { get; set; }
        public double des_long { get; set; }
        public double des_lat { get; set; }
        public DateTime createDate { get; set; }
    }
}
