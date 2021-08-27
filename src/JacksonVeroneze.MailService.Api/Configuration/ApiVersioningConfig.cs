using JacksonVeroneze.NET.Commons.AspNet.ApiVersioning;
using Microsoft.Extensions.DependencyInjection;

namespace JacksonVeroneze.MailService.Api.Configuration
{
    public static class ApiVersioningConfig
    {
        public static IServiceCollection AddVersioningConfigConfiguration(this IServiceCollection services)
            => services.AddApiVersioningConfiguration(x =>
            {
                x.MajorVersion = 1;
                x.MinorVersion = 0;
            });
    }
}
