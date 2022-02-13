using Application.Commands.User;
using DependencyInjection.Modules;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddComponents();
            services.AddSingleton(new Logger());
            services.AddMediatR(typeof(CreateUserCommand));
            return services;
        }
    }
}