using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Products;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProductContext>(settings =>
    settings.UseSqlServer("Data Source=localhost;Initial Catalog=Products;User Id=sa;Password=MlSi1f7eciR0Ga7UffQo;Encrypt=false"));

var otelEndpoint = new Uri("http://localhost:4317");
builder.Services.AddOpenTelemetry()
    .ConfigureResource(resource => resource
        .AddService(builder.Environment.ApplicationName, "BuySomeStock"))
    .WithTracing(t => t
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation()
        .AddEntityFrameworkCoreInstrumentation()
        .AddOtlpExporter(o => o.Endpoint = otelEndpoint))
    .WithMetrics(m => m
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation()
        .AddRuntimeInstrumentation()
        .AddEventCountersInstrumentation(c =>
        {
            c.AddEventSources("Microsoft-AspNetCore-Server-Kestrel");
        })
        .AddOtlpExporter(o => o.Endpoint = otelEndpoint));

builder.Host.ConfigureLogging(l => l
    .AddOpenTelemetry(o =>
    {
        o.IncludeFormattedMessage = true;
        o.IncludeScopes = true;
        o.AddOtlpExporter(o => o.Endpoint = otelEndpoint);
    }));

var app = builder.Build();
app.MapGet("/", (ProductContext context, ILogger<Program> logger) =>
{
    logger.LogInformation("Retrieving products.");
    return context.Products.AsAsyncEnumerable();
});

using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<ProductContext>();
await db.Database.MigrateAsync();

await app.RunAsync();
