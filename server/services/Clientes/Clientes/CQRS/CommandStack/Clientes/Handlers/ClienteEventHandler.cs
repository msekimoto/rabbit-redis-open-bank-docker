using System;
using System.Threading;
using System.Threading.Tasks;
using Clientes.CQRS.Commands.Contas;
using Clientes.CQRS.CommandStack.Clientes.Events;
using Core.Interfaces;
using MediatR;

namespace Clientes.CQRS.CommandStack.Clientes.Handlers
{
    public class ClienteEventHandler : INotificationHandler<ClienteCadastradoEvent>,
                                       INotificationHandler<ClienteAprovadoEvent>,
                                       INotificationHandler<ClienteRecusadoEvent>
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ClienteEventHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler ?? throw new ArgumentNullException(nameof(mediatorHandler));
        }

        public Task Handle(ClienteCadastradoEvent notification, CancellationToken cancellationToken)
        {
            // Talvez enviar e-mail de confirmação para o cliente e um para avisar a agência?
            return Task.CompletedTask;
        }

        public Task Handle(ClienteAprovadoEvent notification, CancellationToken cancellationToken)
        {
            _mediatorHandler.SendCommand(new CriarContaCommand(Guid.NewGuid(), notification.Id, DateTime.UtcNow));
            return Task.CompletedTask;
        }

        public Task Handle(ClienteRecusadoEvent notification, CancellationToken cancellationToken)
        {
            // Talvez enviar e-mail para o cliente informando que ele foi recusado?
            return Task.CompletedTask;
        }
    }
}
