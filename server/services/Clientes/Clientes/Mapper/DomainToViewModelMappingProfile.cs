using AutoMapper;
using Clientes.Domain;
using Clientes.Domain.Clientes;
using Clientes.Domain.Contas;

namespace Clientes.Mapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            MapearContextoClientes();
        }


        private void MapearContextoClientes()
        {
            CreateMap<Cliente, Models.Clientes.Clientes.ClienteViewModel>();
            CreateMap<Conta, Models.Clientes.Contas.ContaViewModel>();
        }
    }
}
