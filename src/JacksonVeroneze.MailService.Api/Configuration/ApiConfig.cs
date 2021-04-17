using JacksonVeroneze.Dotnet.Common.Culture;
using JacksonVeroneze.Dotnet.Common.HealthCheck;
using JacksonVeroneze.Dotnet.Common.Routing;
using JacksonVeroneze.Dotnet.Common.Swagger;
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
        private const string CorsPolicyName = "CorsPolicy";

        public static IServiceCollection AddApiConfiguration(this IServiceCollection services,
            IConfiguration configuration,
            IHostEnvironment hostEnvironment)
        {
            services.AddRoutingConfiguration()
                .AddCorsConfiguration(configuration, CorsPolicyName)
                .AddHealthCheckConfiguration()
                .AddDependencyInjectionConfiguration(configuration)
                .AddSwaggerConfiguration()
                .AddApplicationInsightsConfiguration(configuration)
                .AddOpenTelemetryTracingConfiguration(configuration, hostEnvironment)
                .AddVersioningConfigConfiguration()
                .AddControllers()
                .AddJsonOptionsSerializeConfiguration();

            return services;
        }

        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app,
            IApiVersionDescriptionProvider provider, IConfiguration configuration)
        {
            app.UseCultureConfiguration()
                .UseCors(CorsPolicyName)
                .UseHealthCheckConfiguration()
                .UseSerilogRequestLogging()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseSwaggerConfiguration(provider)
                .UseEndpoints(endpoints =>
                    endpoints.MapControllers()
                );

            return app;
        }
    }
}
