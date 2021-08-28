using System;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace JacksonVeroneze.MailService.Api.Configuration
{
    public static class HangfireConfig
    {
        public static IServiceCollection AddHangfireConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute
            {
                Attempts = 3, DelaysInSeconds = new[] { 10, 30, 60 }
            });

            if (configuration["Hangfire:Storage"].Equals("Redis", StringComparison.InvariantCultureIgnoreCase))
            {
                services.AddHangfire(x =>
                    x.UseRedisStorage(ConnectionMultiplexer.Connect(configuration["Hangfire:RedisConnectionString"])));
            }
            else
            {
                services.AddHangfire(x => x.UseMemoryStorage());
            }

            services.AddHangfireServer();

            return services;
        }
    }
}
