using System;
using System.Collections.Generic;
using Core.Interfaces;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Clientes.Configurations
{
    public static class ConfiguracaoServicosFila
    {
        public static void ConfigurarServicosFila(this IServiceCollection services)
        {
            var comandoFilas = new List<Type>();
            services.AddSingleton<IQueueableService, QueueableService>(q => new QueueableService(comandoFilas));
        }
    }
}
