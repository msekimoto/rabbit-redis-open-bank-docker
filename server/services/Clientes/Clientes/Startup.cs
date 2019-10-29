using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Clientes.Configurations;
using Clientes.Mapper;
using Clientes.Models;
using Core.CommandHandlers;
using Core.Interfaces;
using Core.Notifications;
using Core.Repository;
using Core.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Clientes
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.ConfigurarAutenticacao();
            services.ConfigurarServicosFila();
            services.AddAutoMapper();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IUsuario, AspNetUser>();
            services.AddMediatR(typeof(Startup));
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IMongoSequenceRepository, MongoSequenceRepository>();
            services.AddHostedService<QueueHostedService>();
            AutoMapperConfiguration.RegisterMappings();
            //BootstrapperAgencia.RegistrarServicos(services);
            //BootstrapperClientes.RegistrarServicos(services);
            //BootstrapperMovimentacoes.RegistrarServicos(services);


            //services.AddScoped<IClienteRepository, ClienteRepository>();
            //services.AddScoped<IContaRepository, ContaRepository>();

            //services.AddScoped<IRequestHandler<CadastrarClienteCommand, bool>, ClienteCommandHandler>();
            //services.AddScoped<IRequestHandler<AprovarClienteCommand, bool>, ClienteCommandHandler>();
            //services.AddScoped<IRequestHandler<RecusarClienteCommand, bool>, ClienteCommandHandler>();
            //services.AddScoped<IRequestHandler<CriarContaCommand, bool>, ContaCommandHandler>();
            //services.AddScoped<IRequestHandler<AdicionarValorSaldoContaCommand, bool>, ContaCommandHandler>();
            //services.AddScoped<IRequestHandler<RemoverValorSaldoContaCommand, bool>, ContaCommandHandler>();

            //services.AddScoped<INotificationHandler<ClienteCadastradoEvent>, ClienteEventHandler>();
            //services.AddScoped<INotificationHandler<ClienteAprovadoEvent>, ClienteEventHandler>();
            //services.AddScoped<INotificationHandler<ClienteRecusadoEvent>, ClienteEventHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
