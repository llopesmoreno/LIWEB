using Serilog;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;

namespace LIWEB.AuthAPI
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
                }).UseSerilog((ctx, log) =>
                   log.ReadFrom.Configuration(ctx.Configuration));
    }
}
