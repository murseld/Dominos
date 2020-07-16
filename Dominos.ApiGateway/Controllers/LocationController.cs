using System.Threading.Tasks;
using Dominos.ApiGateway.Domain.Commands;
using Dominos.Core.Bus;
using Microsoft.AspNetCore.Mvc;

namespace Dominos.ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : BaseController
    {
        public LocationController(IBusPublisher busPublisher) : base(busPublisher)
        {
        }



        // POST: api/Location
        [HttpPost]
        public async Task<IActionResult> Post(CreateLocationCommand locationCommand)
        {
            var context = GetContext(locationCommand.commandId);
            await BusPublisher.SendAsync(locationCommand, context);
            return Accepted();
        }



    }
}
