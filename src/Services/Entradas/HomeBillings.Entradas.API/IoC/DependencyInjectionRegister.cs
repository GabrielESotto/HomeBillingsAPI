using HomeBillings.Entradas.API.Data.Repositories;
using HomeBillings.Entradas.API.Domain.Commands.Handlers;
using HomeBillings.Entradas.API.Domain.Commands.Interfaces;
using HomeBillings.Entradas.API.Domain.Events;
using System.Reflection;

namespace HomeBillings.Entradas.API.IoC
{
    public static class DependencyInjectionRegister
    {
        public static void AddDependencyInjectionRegister(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddScoped<INotificationHandler<EntryNotificationEvent>, EntryEventHandler>();

            services.AddScoped<IEntradaAddCommandHandler, EntradaAddCommandHandler>();
            services.AddScoped<IEntradaUpdateCommandHandler, EntradaUpdateCommandHandler>();
            services.AddScoped<IEntradaDeleteCommandHandler, EntradaDeleteCommandHandler>();
            services.AddScoped<IEntradaRepository, EntradaRepository>();
        }
    }
}
