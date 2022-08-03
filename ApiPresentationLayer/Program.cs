using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace ApiPresentationLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args);
        }

        private static void BuildWebHost(string[] args)
        {
            WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((ctx, config) =>
                {
                    config.AddJsonFile("appsettings.json", true, true);
                })
                .Build()
                .Run();

        }
    }
}