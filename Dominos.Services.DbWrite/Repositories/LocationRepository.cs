using System.Threading.Tasks;
using AutoMapper;
using Dominos.Services.DbWrite.Data;
using Dominos.Services.DbWrite.Entities;

namespace Dominos.Services.DbWrite.Repositories
{
    public class LocationRepository:ILocationRepository
    {
        private readonly LocationDbContext _dbContext;
        private readonly IMapper _mapper;

        public LocationRepository(LocationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateProductAsync(Location location)
        {
            await _dbContext.Locations.AddAsync(location);
        }
    }
}
