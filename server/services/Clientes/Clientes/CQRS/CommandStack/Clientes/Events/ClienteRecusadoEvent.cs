using System;
using Core.Events;

namespace Clientes.CQRS.CommandStack.Clientes.Events
{
    public class ClienteRecusadoEvent : Event
    {
        public ClienteRecusadoEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
