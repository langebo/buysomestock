using Microsoft.Extensions.Hosting;
using MassTransit;
using Ordering;
using Microsoft.Extensions.DependencyInjection;
using System;
using OpenTelemetry.Resources;
using MassTransit.Logging;
using OpenTelemetry.Trace;
using MassTransit.Monitoring;
using OpenTelemetry.Metrics;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;

var otelEndpoint = new Uri("http://localhost:4317");

var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureServices((context, services) =>
{
    services.AddSingleton<IMailingService, MailingService>();
    services.AddMassTransit(options =>
    {
        options.AddConsumer<OrderCreatedHandler>();
        options.UsingRabbitMq((ctx, cfg) =>
        {
            cfg.Host("localhost", "/", host =>
            {
                host.Username("guest");
                host.Password("guest");
            });

            cfg.ConfigureEndpoints(ctx);
        });
    });

    services.AddOpenTelemetry()
    .ConfigureResource(resource => resource
        .AddService(context.HostingEnvironment.ApplicationName, "BuySomeStock"))
    .WithTracing(t => t
        .AddSource(DiagnosticHeaders.DefaultListenerName)
        .AddOtlpExporter(o => o.Endpoint = otelEndpoint))
    .WithMetrics(m => m
        .AddMeter(InstrumentationOptions.MeterName)
        .AddRuntimeInstrumentation()
        .AddEventCountersInstrumentation()
        .AddOtlpExporter(o => o.Endpoint = otelEndpoint));
})
.ConfigureLogging((hostContext, loggingBuilder) => loggingBuilder
    .AddOpenTelemetry(o =>
        {
            o.IncludeFormattedMessage = true;
            o.IncludeScopes = true;
            o.AddOtlpExporter(o => o.Endpoint = otelEndpoint);
        }));


var app = builder.Build();
await app.RunAsync();