using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Extensions.DependencyInjection;

namespace JacksonVeroneze.MailService.Api.Configuration
{
    public static class HangfireConfig
    {
        public static IServiceCollection AddHangfireConfiguration(this IServiceCollection services)
        {
            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute
            {
                Attempts = 3, DelaysInSeconds = new[] { 10, 30, 60 }
            });

            services.AddHangfire(x => x.UseMemoryStorage());
            services.AddHangfireServer();

            return services;
        }
    }
}
