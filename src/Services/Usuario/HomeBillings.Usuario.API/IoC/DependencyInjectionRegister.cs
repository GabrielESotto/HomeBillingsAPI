using HomeBillings.Core.AutoMapper;
using HomeBillings.Usuario.API.Data.Repositories;
using HomeBillings.Usuario.API.Domain.Commands.Handlers;
using HomeBillings.Usuario.API.Domain.Commands.Interfaces;
using HomeBillings.Usuario.API.Domain.Events;
using HomeBillings.Usuario.API.Services;
using System.Reflection;

namespace HomeBillings.Usuario.API.IoC
{
    public static class DependencyInjectionRegister
    {
        public static void AddDependencyInjectionRegister(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddScoped<INotificationHandler<UserRegisteredEvent>, UserEventHandler>();

            services.AddScoped<IUserAddCommandHandler, UserAddCommandHandler>();
            services.AddScoped<IUserUpdateCommandHandler, UserUpdateCommandHandler>();
            services.AddScoped<IUserDeleteCommandHandler, UserDeleteCommandHandler>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddHostedService<UserRegisterIntegrationHandler>();
        }
    }
}
