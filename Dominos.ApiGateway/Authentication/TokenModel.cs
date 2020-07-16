using System;

namespace Dominos.ApiGateway.Authentication
{
    public class TokenModel
    {
        public Guid CustomerId { get; set; }
        public string Email { get; set; }
    }
}
