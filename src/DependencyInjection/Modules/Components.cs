using Microsoft.Extensions.DependencyInjection;
using Persistence.IRepository.User;
using Persistence.Repository;

namespace DependencyInjection.Modules
{
    public static class Components
    {
        public static void AddComponents(this IServiceCollection services)
        {
            services.AddTransient<IUserRepositoryReader, UserRepositoryReader>();
            services.AddTransient<IUserRepositoryWriter, UserRepositoryWriter>();
        }
    }
}