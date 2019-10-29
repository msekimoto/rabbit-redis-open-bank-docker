using System;
using Core.Commands;

namespace Clientes.CQRS.Commands.Clientes
{
    public class AprovarClienteCommand : Command
    {
        public AprovarClienteCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
