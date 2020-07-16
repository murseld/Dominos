using System.Threading.Tasks;
using Dominos.Core.Bus;
using Dominos.Core.Domain.Messages;

namespace Dominos.Core.Domain.MessagesHandlers
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, ICorrelationContext context);
    }
}
