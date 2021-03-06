using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using JacksonVeroneze.NET.Commons.Logger;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace JacksonVeroneze.MailService.Api
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                Activity.DefaultIdFormat = ActivityIdFormat.W3C;
                Activity.ForceDefaultIdFormat = true;

                string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                Log.Logger = FactoryLogger(environment);

                Log.Information("Application: {0}", "Starting up");

                IHost host = CreateHostBuilder(args).Build();

                await host.RunAsync();
            }
            catch (Exception e)
            {
                Log.Fatal(e, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseSerilog();
                });

        private static ILogger FactoryLogger(string environment)
        {
            return Logger.FactoryLogger(x =>
            {
                x.Environment = environment;
                x.ApplicationName = "Stock Service";
                x.CurrentDirectory = Directory.GetCurrentDirectory();
            });
        }
    }
}
