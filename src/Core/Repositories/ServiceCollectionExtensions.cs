using ASM.Repositories.Interfaces;
using ASM.Repositories.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ASM.Repositories
{
    public static class ServiceCollectionExtensions
    {
        #region Configuration Repository

        public static IServiceCollection AddEntityFrameworkRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        #endregion
    }
}
