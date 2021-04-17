using JacksonVeroneze.MailService.Api.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JacksonVeroneze.MailService.Api
{
    public sealed class Startup
    {
        private readonly IConfiguration _configuration;

        private readonly IHostEnvironment _hostEnvironment;

        public Startup(IHostEnvironment hostEnvironment)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath);

            if (!hostEnvironment.IsProduction())
                builder.AddJsonFile("appsettings.json", true, true)
                    .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true);

            builder.AddEnvironmentVariables("APP_CONFIG_");

            _configuration = builder.Build();

            _hostEnvironment = hostEnvironment;
        }

        public void ConfigureServices(IServiceCollection services)
            => services.AddApiConfiguration(_configuration, _hostEnvironment);

        public void Configure(IApplicationBuilder app, IApiVersionDescriptionProvider provider)
            => app.UseApiConfiguration(provider, _configuration);
    }
}
