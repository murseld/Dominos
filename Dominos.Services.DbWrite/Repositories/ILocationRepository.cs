using System.Threading.Tasks;
using Dominos.Core.Data;
using Dominos.Services.DbWrite.Entities;

namespace Dominos.Services.DbWrite.Repositories
{
    public interface ILocationRepository : IBaseRepository
    {
        Task CreateProductAsync(Location location);
    }
}
