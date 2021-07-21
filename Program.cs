using DotNetCoreWebAPI.Models;
using DotNetCoreWebAPI.Services;
using DotNetCoreWebAPI.Routes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder();
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

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health");
});

Route.Setup(app);
await app.RunAsync();