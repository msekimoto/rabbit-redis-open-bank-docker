using System;
using Core.Commands;

namespace Clientes.CQRS.Commands.Contas
{
    public class RemoverValorSaldoContaCommand : Command
    {
        public RemoverValorSaldoContaCommand(Guid contaId, long valor)
        {
            ContaId = contaId;
            Valor = valor;
        }

        public Guid ContaId { get; }
        public long Valor { get; }
    }
}
