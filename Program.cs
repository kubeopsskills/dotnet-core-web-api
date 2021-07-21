using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DotNetCoreWebAPI.Models;
using DotNetCoreWebAPI.Services;
using System;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();
builder.Services.AddHealthChecks();
    
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var configurationBuilder = new ConfigurationBuilder()
.AddJsonFile($"appsettings.{environment}.json", true, true)
.AddEnvironmentVariables()
.Build();

builder.Services.Configure<DatabaseConfig>(configurationBuilder.GetSection(nameof(DatabaseConfig)));
builder.Services.AddSingleton<APIService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseHttpLogging();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/health");
});

app.MapGet("/test", (Func<string>)(() => {
    return "Hello World";
}));

app.Run();