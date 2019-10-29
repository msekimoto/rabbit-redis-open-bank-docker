using System;
using Core.Events;

namespace Clientes.CQRS.CommandStack.Clientes.Events
{
    public class ClienteCadastradoEvent : Event
    {
        public ClienteCadastradoEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
