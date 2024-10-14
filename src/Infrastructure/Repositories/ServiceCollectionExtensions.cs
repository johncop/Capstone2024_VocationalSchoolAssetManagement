using ASM.Database.Data;
using ASM.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ASM.Database
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddContextPool(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(Assembly.GetExecutingAssembly().GetName().Name!);
            services.AddDbContext<DbContext, AssetManagementDbContext>(options =>
                        options.UseSqlServer(connectionString,
                        sqlServerOptionsAction: sqlOptions =>
                        {
                            sqlOptions.CommandTimeout((int)TimeSpan.FromMinutes(2).TotalSeconds);
                            sqlOptions.EnableRetryOnFailure();
                        }));
            services
            .AddIdentityCore<ApplicationUser, IdentityRole<int>>(config =>
            {
                config.SignIn.RequireConfirmedEmail = false;
                config.Password.RequiredLength = 8;
            })
            .AddEntityFrameworkStores<AssetManagementDbContext>()
            .AddDefaultTokenProviders();
            return services;
        }
    }
}
