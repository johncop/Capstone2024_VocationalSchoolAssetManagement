using ASM.Application;
using ASM.Database.Data;
using ASM.Domain.Entities;
using ASM.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme)
    .AddBearerToken(IdentityConstants.BearerScheme);

services.AddIdentityCore<ApplicationUser>()
    .AddEntityFrameworkStores<AssetManagementDbContext>()
    .AddApiEndpoints();

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
    .UseAuthorization()
    .UseAuthorization();

app.MapControllers();
app.MapIdentityApi<ApplicationUser>();

app.Run();
