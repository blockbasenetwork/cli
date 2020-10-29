using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using System;
using System.IO;
using System.Net;
using Serilog.Events;
using System.Linq;
using System.Reflection;
using BlockBase.Services;

namespace BlockBase.Cli
{
    public class HostBuilder
    {
        private readonly IHostBuilder _hostBuider;

        public HostBuilder(string[] args)
        {
            _hostBuider = Host.CreateDefaultBuilder(args);
        }

        public HostBuilder ConfigureMainSettings(string[] args)
        {
            _hostBuider.UseSerilog();

            _hostBuider.ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddEnvironmentVariables();

                if (args != null)
                {
                    config.AddCommandLine(args);
                }
            });

            _hostBuider.ConfigureServices((hostContext, services) =>
            {
                var env = hostContext.HostingEnvironment;

                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", false)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();
            });

            _hostBuider.ConfigureLogging((logging) =>
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", false)
                    .AddEnvironmentVariables()
                    .Build();

                var logConfig = new LoggerConfiguration()
                   .ReadFrom.Configuration(configuration.GetSection("Logging"))
                   .Enrich.FromLogContext();

                logConfig = logConfig.WriteTo.Console(theme: AnsiConsoleTheme.Code);
                Log.Logger = logConfig.CreateLogger();

                logging.AddSerilog();
            });

            _hostBuider.ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<IBlockBaseNetworkService, BlockBaseNetworkService>();
            });

            return this;
        }

        public IHostBuilder GetBuilder() => _hostBuider;
    }
}