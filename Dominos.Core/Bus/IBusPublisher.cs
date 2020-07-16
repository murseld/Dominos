using System.Threading.Tasks;
using Dominos.Core.Domain.Messages;

namespace Dominos.Core.Bus
{
    public interface IBusPublisher
    {
        Task SendAsync<TCommand>(TCommand command, ICorrelationContext context)
            where TCommand : ICommand;

        Task PublishAsync<TEvent>(TEvent _event, ICorrelationContext context)
            where TEvent : IEvent;
    }
}
