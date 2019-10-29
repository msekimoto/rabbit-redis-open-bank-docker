using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Core.Interfaces
{
    public interface IUsuario
    {
        string Identificacao { get; }
        Guid ObterAutenticadoId();
        bool VerificarSeEstaAutenticado();
        IEnumerable<Claim> ObterPermissoes();
    }
}
