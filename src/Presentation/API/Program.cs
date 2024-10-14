using ASM.Application;
using ASM.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
IConfiguration configuration = builder.Configuration;

services.AddWebApiCore();
services.AddCookie()
    .AddJwtConfiguration(configuration);
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddEntityFrameworkRepositories();





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

app.Run();
