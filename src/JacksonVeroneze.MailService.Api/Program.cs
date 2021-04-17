using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using JacksonVeroneze.Dotnet.Common.Logger;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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

                Log.Logger = Logger.FactoryLogger(x =>
                {
                    x.Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                    x.ApplicationName = "Stock Service";
                    x.CurrentDirectory = Directory.GetCurrentDirectory();
                });

                Log.Information($"Application: {0}", "Starting up");
                Log.Information($"Total params: {0}", args.Length);

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
                    webBuilder.UseSerilog()
                        .ConfigureLogging(logging =>
                        {
                            logging.ClearProviders();
                            logging.AddConsole();
                            logging.AddAzureWebAppDiagnostics();
                        });
                });
    }
}
