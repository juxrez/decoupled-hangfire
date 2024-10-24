using Hangfire;
using HangfirePoc.Shared;
using SampleWebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = "Server=sql-db;Database=HangfirePoC;User Id=sa;Password=Password02!;TrustServerCertificate=True;";
builder.Services.AddHangfire(config =>
{
    config.UseSqlServerStorage(connectionString);
});

var app = builder.Build();

app.UseHangfireDashboard("/hangfire", new DashboardOptions()
{
    Authorization = new[] { new AllowAllAuthorizationFilter() }
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

RecurringJob.AddOrUpdate<BackgroundJob1>(nameof(BackgroundJob1), job => job.Execute(), Cron.Minutely);
RecurringJob.AddOrUpdate<BackgroundJob2>(nameof(BackgroundJob2), job => job.Execute(), Cron.Minutely);

app.Run();
