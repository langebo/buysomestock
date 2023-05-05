using MassTransit;
using MassTransit.Logging;
using MassTransit.Monitoring;
using MudBlazor.Services;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Store;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddHttpClient<IProductsClient, ProductsClient>(client => client.BaseAddress = new Uri("http://localhost:8081"));
builder.Services.AddSingleton<IOrderEventService, OrderEventService>();
builder.Services.AddMassTransit(x => x.UsingRabbitMq((context, cfg) =>
{
    cfg.Host("localhost", "/", h =>
    {
        h.Username("guest");
        h.Password("guest");
    });
    cfg.ConfigureEndpoints(context);
}));


var otelEndpoint = new Uri("http://localhost:4317");
builder.Services.AddOpenTelemetry()
    .ConfigureResource(resource => resource
        .AddService(builder.Environment.ApplicationName, "BuySomeStock"))
    .WithTracing(t => t
        .AddSource(DiagnosticHeaders.DefaultListenerName)
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation()
        .AddOtlpExporter(o => o.Endpoint = otelEndpoint))
    .WithMetrics(m => m
        .AddMeter(InstrumentationOptions.MeterName)
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
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

await app.RunAsync();
