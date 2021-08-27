using System;
using System.IO;
using System.Reflection;
using JacksonVeroneze.NET.Commons.AspNet.Swagger;
using Microsoft.Extensions.DependencyInjection;

namespace JacksonVeroneze.MailService.Api.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            return services.AddSwaggerConfiguration(x =>
            {
                x.Title = "MailService Api";
                x.Version = "v1";
                x.Description = "MailService";
                x.ContactName = "Jackson Veroneze";
                x.ContactEmail = "jackson@jacksonveroneze.com";
                x.IncludeXmlComments = true;
                x.XmlCommentsPath = xmlPath;
            });
        }
    }
}
