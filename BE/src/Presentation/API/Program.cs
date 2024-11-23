using System.Text;
using ASM.Application;
using ASM.Core.Entities;
using ASM.Database.Data;
using ASM.Repositories;
using ASM.Services.Interfaces;
using ASM.Services.Services;
using ASM.WebApi.Helper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
IConfiguration configuration = builder.Configuration;

services.AddWebApiCore();
//services.AddCookie()
//    .AddJwtConfiguration(configuration);

services.AddDbContext<AssetManagementDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("Database"), sqlOptions =>
    {
        sqlOptions.CommandTimeout((int)TimeSpan.FromMinutes(2).TotalSeconds);
        sqlOptions.EnableRetryOnFailure();
    });
});


services.AddEndpointsApiExplorer();
services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                                            {
                                                Name = "Authorization",
                                                Type = SecuritySchemeType.Http,
                                                Scheme = "Bearer",
                                                BearerFormat = "JWT",
                                                In = ParameterLocation.Header,
                                                Description =
                                                    "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'"
                                            });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                                   {
                                       {
                                           new OpenApiSecurityScheme
                                           {
                                               Reference = new OpenApiReference
                                                           {
                                                               Type = ReferenceType.SecurityScheme,
                                                               Id = "Bearer"
                                                           }
                                           },
                                           new string[] { }
                                       }
                                   });
});
services.AddEntityFrameworkRepositories();

// Retrieve the secret key from configuration
var jwtSecretKey = builder.Configuration["Jwt:Key"];

services.AddAuthentication(options =>
         {
             options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
             options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
             options.DefaultScheme = "MultiScheme";
         }) // add default authentication schema
        .AddPolicyScheme("MultiScheme", "JWT or Cookie", options =>
         {
             options.ForwardDefaultSelector = context =>
             {
                 var bearerAuth = context.Request.Headers["Authorization"].FirstOrDefault()?.StartsWith("Bearer ") ??
                                  false;

                 // You could also check for the actual path here if that's your requirement:
                 if (bearerAuth)
                     return JwtBearerDefaults.AuthenticationScheme;
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
                                                     IssuerSigningKey =
                                                         new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey)),
                                                     ClockSkew = TimeSpan
                                                        .Zero // Optional: Removes the default 5 mins tolerance
                                                 };
         })
        .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
         {
             options.LoginPath = builder.Configuration["Authentication:Google:LoginPath"];
             ; // Must be lowercase
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
services.AddSingleton<IBlobService, BlobService>();

services.AddHttpContextAccessor();
services.AddAutoMapper(typeof(ConfigMapper));
services.Configure<DataProtectionTokenProviderOptions>(options =>
{
    options.TokenLifespan = TimeSpan.FromHours(2); // Adjust as needed
});

services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build
       .WithOrigins("*")
       .AllowAnyMethod()
       .AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Asser Management System API V1"); });


app.UseHttpsRedirection()
   .UseResponseCaching()
   .UseRouting()
   .UseAuthorization();

app.MapControllers();
//app.MapIdentityApi<ApplicationUser>();

//Redirect to Swagger by default
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
        context.Response.Redirect("/swagger");
    else
        await next();
});

app.Run();
