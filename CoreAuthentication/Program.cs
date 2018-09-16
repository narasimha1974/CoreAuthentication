using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RepositoryHelperInterfaces;

namespace CoreAuthentication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = BuildWebHost(args);

            using (IServiceScope scope = host.Services.CreateScope())
            {
                IServiceProvider services = scope.ServiceProvider;
                try
                {
                    IServiceProvider serviceProvider = services.GetRequiredService<IServiceProvider>();
                    IConfiguration configuration = services.GetRequiredService<IConfiguration>();
                    ICRUDCountry crudCountry = services.GetRequiredService<ICRUDCountry>();
                    Data.Seed.CreateAspNetRoles(serviceProvider, configuration).Wait();
                    Data.Seed.CreateAspNetRoleClaims(serviceProvider).Wait();

                }
                catch (Exception exception)
                {
                    ILogger logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(exception, "An error occurred while creating roles");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()            
                .Build();
    }
}
