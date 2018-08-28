using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace KorDevAus
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                             .SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                             .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                             .AddEnvironmentVariables()
                             .Build();

            return WebHost.CreateDefaultBuilder(args)
                          .UseConfiguration(config)
                          .UseStartup<Startup>();
        }
    }
}
