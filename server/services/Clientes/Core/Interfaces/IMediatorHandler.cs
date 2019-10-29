using System.Threading;
using System.Threading.Tasks;
using Core.Commands;
using Core.Events;

namespace Core.Interfaces
{
    public interface IMediatorHandler
    {
        Task RaiseEvent<T>(T evento, CancellationToken cancellation = default, bool enqueue = false) where T : Event;
        Task SendCommand<T>(T comando, CancellationToken cancellation = default, bool enqueue = false) where T : Command;
        Task PublicarFila<T>(T comando, CancellationToken cancellation = default);
    }
}
