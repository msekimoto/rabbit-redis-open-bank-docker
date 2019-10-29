using System;
using Core.Interfaces;

namespace Clientes.Domain.Contas.Repository
{
    public interface IContaRepository : IRepository<Conta>
    {
        Conta ObterPorCliente(Guid clienteId);
        Conta ObterPorNumero(string numero);
    }
}
