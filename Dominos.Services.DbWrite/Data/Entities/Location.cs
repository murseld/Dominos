using Dominos.Core.Entities;

namespace Dominos.Services.DbWrite.Entities
{
    public class Location:IEntity
    {
        public int id { get; set; }
        public double src_long { get; set; }
        public double src_lat { get; set; }
        public double des_long { get; set; }
        public double des_lat { get; set; }

    }
}
