using Serilog;
using Serilog.Enrichers.Datadog.OpenTelemetry;
using Serilog.Exceptions;
using Serilog.Formatting.Json;

namespace AlmeidaERP.WebApi;

public static class Program
{
    public static void Main(string[] args)
    {
        try
        {
            CreateHostBuilder(args).Build().Run();
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseSerilog((context, services, configuration) => configuration
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext()
                .Enrich.WithDatadogTraceId()
                .Enrich.WithDatadogSpanId()
                .Enrich.WithExceptionDetails()
#if (DEBUG)
                .WriteTo.Console())
#else
                .WriteTo.Console(new JsonFormatter(renderMessage: true)))
#endif
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}