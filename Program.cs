using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPWebSolutions.Data;

namespace VPWebSolutions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            RunSeeding(host);
            host.Run();
        }

        private static void RunSeeding(IHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                var pizzaSeeder = scope.ServiceProvider.GetService<PizzaSeeder>();
                pizzaSeeder.Seed();

                var roleSeeder = scope.ServiceProvider.GetService<RoleSeeder>();
                roleSeeder.SeedAsync().Wait();

                var identitySeeder = scope.ServiceProvider.GetService<IdentitySeeder>();
                identitySeeder.SeedAsync().Wait();

                var businessDataSeeder = scope.ServiceProvider.GetService<BusinessDataSeeder>();
                businessDataSeeder.SeedAsync();
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
