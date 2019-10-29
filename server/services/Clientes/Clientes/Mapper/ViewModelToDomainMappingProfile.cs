using System;
using AutoMapper;
using Clientes.CQRS.Commands;
using Clientes.CQRS.Commands.Clientes;
using Clientes.Models.Clientes.Clientes;

namespace Clientes.Mapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            MapearContextoClientes();
        }

        private void MapearContextoClientes()
        {
            CreateMap<CadastrarClienteViewModel, CadastrarClienteCommand>()
                .ConstructUsing(c => new CadastrarClienteCommand(c.Id, c.NomeCompleto, c.Cpf, c.DataNascimento, c.Email, c.Telefone, c.SenhaCriptografada, c.DataHoraCriacao));

            CreateMap<Guid, AprovarClienteCommand>()
                .ConstructUsing(id => new AprovarClienteCommand(id));

            CreateMap<Guid, RecusarClienteCommand>()
                .ConstructUsing(id => new RecusarClienteCommand(id));
        }
    }
}
