// See https://aka.ms/new-console-template for more information
using Hangfire;
using HangfirePoc.Shared;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("JobProcessor started");

var connectionString = "Server=sql-db;Database=HangfirePoC;User Id=sa;Password=Password01!;TrustServerCertificate=True;";
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((builder, services) =>
        services
            .AddLogging()
            .AddScoped<BackgroundJob1>()
            .AddScoped<BackgroundJob2>() 
            .AddHangfire(configuration =>
            {
                configuration.UseSqlServerStorage(connectionString);
            })
            .AddHangfireServer(options =>
            {
                options.ServerName = $"JobProcessor - { Guid.NewGuid() }";
            }))
    .Build();

await host.RunAsync();