using System.Threading.Tasks;
using Dominos.Core.Bus;
using Dominos.Core.Domain.Messages;

namespace Dominos.Core.Domain.MessagesHandlers
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent _event, ICorrelationContext context);
    }
}
