using ASM.Application;
using ASM.Application.Helper;
using ASM.Core.Entities;
using ASM.Database.Data;
using ASM.Repositories;
using ASM.Services.Interfaces;
using ASM.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
IConfiguration configuration = builder.Configuration;

services.AddWebApiCore();
//services.AddCookie()
//    .AddJwtConfiguration(configuration);

services.AddDbContext<AssetManagementDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("Database"), sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.CommandTimeout((int)TimeSpan.FromMinutes(2).TotalSeconds);
        sqlOptions.EnableRetryOnFailure();
    });
});


services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddEntityFrameworkRepositories();

// Retrieve the secret key from configuration
var jwtSecretKey = builder.Configuration["Jwt:Key"];

services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            options.DefaultScheme = "MultiScheme";
        }) // add default authenticationschema
        .AddPolicyScheme("MultiScheme", "JWT or Cookie", options =>
        {
            options.ForwardDefaultSelector = context =>
            {
                var bearerAuth = context.Request.Headers["Authorization"].FirstOrDefault()?.StartsWith("Bearer ") ?? false;

                // You could also check for the actual path here if that's your requirement:
                if (bearerAuth)
                    return JwtBearerDefaults.AuthenticationScheme;
                else
                    return CookieAuthenticationDefaults.AuthenticationScheme;
            };
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey)),
                ClockSkew = TimeSpan.Zero // Optional: Removes the default 5 mins tolerance
            };
        })
        .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
        {
            options.LoginPath = builder.Configuration["Authentication:Google:LoginPath"]; ; // Must be lowercase
        })      
        .AddGoogle(options =>
        {
            options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
            options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
            // Configure the callback Url from Google (if not set, the default is /signin-google)
            options.CallbackPath = "/login-with-google";
        })
        .AddBearerToken(IdentityConstants.BearerScheme)
        .AddCookie(IdentityConstants.ApplicationScheme);

services.AddAuthorizationBuilder();

//services.AddScoped<UserManager<ApplicationUser>, CustomUserManager<ApplicationUser>>();
services.AddIdentityCore<ApplicationUser>(opts => opts.SignIn.RequireConfirmedEmail = true)
    .AddEntityFrameworkStores<AssetManagementDbContext>()
    .AddApiEndpoints()
    .AddDefaultTokenProviders(); // Adds token providers for things like email confirmation, password reset;

services.AddScoped<UserManager<ApplicationUser>>();
services.AddScoped<SignInManager<ApplicationUser>>();


//services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

//Config services
services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
services.AddScoped(typeof(IEmailService), typeof(EmailService));
services.AddScoped(typeof(IAuthService), typeof(AuthService));

services.AddHttpContextAccessor();

services.Configure<DataProtectionTokenProviderOptions>(options =>
{
    options.TokenLifespan = TimeSpan.FromHours(2); // Adjust as needed
});

//Config services
services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection()
    .UseResponseCaching()
    .UseRouting()
    .UseAuthorization();

app.MapControllers();
//app.MapIdentityApi<ApplicationUser>();

app.Run();
