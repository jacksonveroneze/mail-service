using Hangfire;
using JacksonVeroneze.NET.Commons.AspNet.Cors;
using JacksonVeroneze.NET.Commons.AspNet.Culture;
using JacksonVeroneze.NET.Commons.AspNet.HealthCheck;
using JacksonVeroneze.NET.Commons.AspNet.Routing;
using JacksonVeroneze.NET.Commons.AspNet.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace JacksonVeroneze.MailService.Api.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services,
            IConfiguration configuration,
            IHostEnvironment hostEnvironment)
        {
            services.AddRoutingConfiguration()
                .AddCorsConfiguration(configuration)
                .AddHealthCheckConfiguration()
                .AddDependencyInjectionConfiguration(configuration)
                .AddSwaggerConfiguration()
                .AddOpenTelemetryTracingConfiguration(configuration, hostEnvironment)
                .AddVersioningConfigConfiguration()
                .AddHangfireConfiguration(configuration)
                .AddControllers()
                .AddJsonOptionsSerializeConfiguration();

            return services;
        }

        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app,
            IApiVersionDescriptionProvider provider)
        {
            app.UseCultureConfiguration()
                .UseCorsConfiguration()
                .UseHealthCheckConfiguration()
                .UseSerilogRequestLogging()
                .UseRouting()
                .UseSwaggerConfiguration(provider)
                .UseHangfireDashboard("/hangfire",
                    new DashboardOptions()
                    {
                        IgnoreAntiforgeryToken = true,
                        Authorization = new[] { new HangfireDashboardNoAuthorizationFilter() }
                    })
                .UseEndpoints(endpoints => endpoints.MapControllers());

            return app;
        }
    }
}
