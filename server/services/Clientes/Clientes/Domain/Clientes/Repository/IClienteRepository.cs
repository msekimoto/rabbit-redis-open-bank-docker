using System.Collections.Generic;
using Clientes.Domain.Clientes.Enums;
using Core.Interfaces;

namespace Clientes.Domain.Clientes.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente ObterPorEmail(string email);
        Cliente ObterPorCpf(string cpf);
        List<Cliente> ObterPorSituacao(SituacaoCliente situacao); 
    }
}
