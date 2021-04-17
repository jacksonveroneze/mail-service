using JacksonVeroneze.MailService.Api.Services;
using JacksonVeroneze.MailService.Api.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JacksonVeroneze.MailService.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<SmtpSettings>(configuration.GetSection(nameof(SmtpSettings)));

            services.AddScoped<IEmailService, EmailService>();

            return services;
        }
    }
}
