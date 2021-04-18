using JacksonVeroneze.NET.Commons.Swagger;
using Microsoft.Extensions.DependencyInjection;

namespace JacksonVeroneze.MailService.Api.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
            => services.AddSwaggerConfiguration(x =>
            {
                x.Title = "MailService Api";
                x.Version = "v1";
                x.Description = "MailService";
                x.ContactName = "Jackson Veroneze";
                x.ContactEmail = "jackson@jacksonveroneze.com";
            });
    }
}
