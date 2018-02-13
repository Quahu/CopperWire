using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CopperWire.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Setting up services");

            var cfg = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("config.json")
                .Build();

            var srv = new ServiceCollection()
                .AddOptions()
                .Configure<ClientSettings>(cfg.GetSection("CopperWire"))
                .AddSingleton<IConfiguration>(cfg)
                .AddSingleton(new LoggerFactory()
                    .AddConsole(cfg.GetSection("Logging"))
                    .AddDebug(LogLevel.Debug))
                .AddLogging()
                .BuildServiceProvider();

            var client0 = new Client(srv, 0, 2);
            var client1 = new Client(srv, 1, 2);
            Console.ReadKey();
        }
    }
}
