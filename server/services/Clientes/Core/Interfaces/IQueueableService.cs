using System;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IQueueableService
    {
        List<Type> Comandos { get; set; }
        void AdicionarComando(Type comando);
    }
}
