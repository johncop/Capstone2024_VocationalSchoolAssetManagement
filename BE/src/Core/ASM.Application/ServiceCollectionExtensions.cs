using ASM.Application.Helper;
using ASM.Core.Entities.Enum;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;

namespace ASM.Application
{
    public static class ServiceCollectionExtensions
    {
        #region Configuration API
        public static IMvcBuilder AddWebApiCore(this IServiceCollection services)
        {
            IMvcBuilder mvcBuilder = services.AddRouting(x => x.LowercaseUrls = true)
                                             .AddControllers(ex =>
                                             {
                                                 var notJsonOutputFormatters = ex.OutputFormatters.Where(formatter => !(formatter is SystemTextJsonOutputFormatter)).ToArray();
                                                 foreach (var formatter in notJsonOutputFormatters)
                                                 {
                                                     ex.OutputFormatters.Remove(formatter);
                                                 }
                                             })
                                             .AddJsonOptions(x =>
                                             {
                                                 x.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                                                 x.JsonSerializerOptions.AllowTrailingCommas = false;
                                                 x.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Disallow;
                                             });
            services.AddResponseCaching()
                    .AddHttpContextAccessor();

            return mvcBuilder;
        }

        public static IServiceCollection AddCORS(this IServiceCollection services)
        {
            services.AddCors(p => p.AddPolicy("corspolicy", build =>
            {
                build
                .WithOrigins("*")
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));
            return services;
        }
        #endregion

        #region Configuration Authentication And Authorization
        public static IServiceCollection AddCookie(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(o =>
            {
                o.ExpireTimeSpan = TimeSpan.FromDays(5);
                o.SlidingExpiration = true;
            });

            services.Configure<DataProtectionTokenProviderOptions>(o =>
            {
                o.TokenLifespan = TimeSpan.FromHours(3);
            });
            return services;
        }

        public static IServiceCollection AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            IConfigurationSection appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            AppSettings appSettings = appSettingsSection.Get<AppSettings>()!;
            byte[] key = Encoding.ASCII.GetBytes(appSettings!.Secret);

            services
                .AddAuthentication(opt =>
                {
                    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(nameof(RoleCollection.Admin), policy => policy.RequireRole(nameof(RoleCollection.Admin)));
                options.AddPolicy(nameof(RoleCollection.User), policy => policy.RequireRole(nameof(RoleCollection.User)));
            });
            return services;
        }
        #endregion
    }
}
