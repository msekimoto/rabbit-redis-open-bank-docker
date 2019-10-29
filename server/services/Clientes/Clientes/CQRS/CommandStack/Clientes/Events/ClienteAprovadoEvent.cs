using System;
using Core.Events;

namespace Clientes.CQRS.CommandStack.Clientes.Events
{
    public class ClienteAprovadoEvent : Event
    {
        public ClienteAprovadoEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
