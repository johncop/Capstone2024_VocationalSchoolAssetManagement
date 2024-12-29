using System.Reflection;
using AMS.Data.AutoMapper;
using AutoMapper;
using AMS.Data.Models;
using Microsoft.EntityFrameworkCore;
using AMS.Data;
using AMS.Core.CustomAttribute;
using System.Linq;
using System;

namespace AMS.Api.Configurations
{
    public static class DependencyInjecttions
    {
        public static void AutoMapperDI(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IMapper>(sp =>
            {
                return new Mapper(AutoMapperConfig.RegisterMappings());
            });
            services.AddSingleton(AutoMapperConfig.RegisterMappings());
        }
        
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services, Type targetProject)
        {
            var implementedTypes = GetTypesWith<DependencyInjectionAttribute>(true);

            foreach (var implementedType in implementedTypes)
            {
                //var types = targetProject.Assembly.GetTypes().Where(t => t.GetInterfaces().Contains(implementedType));
                var types = from a in AppDomain.CurrentDomain.GetAssemblies()
                            from t in a.GetTypes().Where(t => t.GetInterfaces().Contains(implementedType))
                            select t;

                foreach (var type in types)
                {
                    var attribute = implementedType.GetCustomAttribute<DependencyInjectionAttribute>();
                    if (attribute != null)
                        services.Add(new ServiceDescriptor(implementedType, type, attribute.ServiceLifetime));
                }
            }

            return services;
        }

        private static IEnumerable<Type> GetTypesWith<TAttribute>(bool inherit) where TAttribute : Attribute
        {
            return from a in AppDomain.CurrentDomain.GetAssemblies()
                   from t in a.GetTypes()
                   where t.IsDefined(typeof(TAttribute), inherit)
                   select t;
        }


        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var area = configuration.GetSection("AppSettings:Area").Value;
            services.AddDbContext<DBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString($"DefaultConnection_{area}"));
                options.EnableSensitiveDataLogging(true);
            }
            );
        }
    }

}