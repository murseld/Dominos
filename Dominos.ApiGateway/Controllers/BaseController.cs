using System;
using Dominos.ApiGateway.Authentication;
using Dominos.Core.Bus;
using Microsoft.AspNetCore.Mvc;

namespace Dominos.ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IBusPublisher BusPublisher;

        public BaseController(IBusPublisher busPublisher)
        {
            BusPublisher = busPublisher;
        }

        protected TokenModel CurrentUser => HttpContext.Items["CurrentCustomer"] as TokenModel;

        protected ICorrelationContext GetContext()
        {
            return GetContext(CurrentUser.CustomerId);
        }

        //This method is only for AllowAnonymus CustomerController
        protected ICorrelationContext GetContext(Guid customerId)
        {
            return CorrelationContext.Create(Guid.NewGuid(), customerId);
        }
    }
}