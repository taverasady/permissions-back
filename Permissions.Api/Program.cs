using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Permissions.DAL.Context;
using Permissions.DAL.DataSeeder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Permissions.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<PermissionsContext>();
                    DataSeeder.Initialize(context);
                }
                catch (Exception)
                {
                    Console.WriteLine("An error occurred while seeding the database.");
                }
            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
    }
}
