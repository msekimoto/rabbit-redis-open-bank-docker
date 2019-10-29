using System;
using Core.Commands;

namespace Clientes.CQRS.Commands.Clientes
{
    public class RecusarClienteCommand : Command
    {
        public RecusarClienteCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
