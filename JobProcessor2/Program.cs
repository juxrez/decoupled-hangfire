using Hangfire;
using HangfirePoc.Shared;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("JobProcessor2 started");

var connectionString = "Server=ACFSFS;";

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
                options.ServerName = $"JobProcessor2 - {Guid.NewGuid()}";
            }))
    .Build();

await host.RunAsync();