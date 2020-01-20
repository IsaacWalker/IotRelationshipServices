/***************************************************
    Program.cs

    Isaac Walker
****************************************************/

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Web.Iot.DeviceService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureLogging((hostingContext, logging) =>
                {
                    logging.ClearProviders();
                    logging.AddEventLog((settings =>
                    {
                        settings.LogName = "Application";
                        settings.SourceName = "DeviceService";
                    }));
                });
    }
}
