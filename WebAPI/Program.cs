using Account.Persistence.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
            CreateHostBuilder(args).Build().Run();
        }

        public static async Task MainAsync(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<AccountRepo>();
                    var res = await Seed.Start(context);
                }
                catch (Exception _)
                {
                    /*Handle Error*/
                }
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
