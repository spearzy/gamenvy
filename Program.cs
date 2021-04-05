using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace gamenvy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new HostBuilder()
            .ConfigureAppConfiguration((hostContext, builder) =>
            {
                builder.AddJsonFile("appsettings.json", false);
                builder.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", false);
                if(hostContext.HostingEnvironment.IsDevelopment())
                    builder.AddUserSecrets<Startup>();
                builder.AddEnvironmentVariables();
            }).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .Build();

            host.Run();
           // CreateHostBuilder(args).Build().Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });
    }
}
