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
using BlockBase.Cli.Services;

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

            _hostBuider.ConfigureLogging((logging) =>
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

                var logConfig = new LoggerConfiguration()
                   .ReadFrom.Configuration(configuration.GetSection("Logging"))
                   .Enrich.FromLogContext();

                logConfig = logConfig.WriteTo.File($"cli_log_.log", rollingInterval: RollingInterval.Day);
                Log.Logger = logConfig.CreateLogger();

                logging.AddSerilog();
            });

            _hostBuider.ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<IBlockBaseNetworkService, BlockBaseNetworkService>();
                services.AddSingleton<IBlockBaseProviderService, BlockBaseProviderService>();
            });

            return this;
        }

        public IHostBuilder GetBuilder() => _hostBuider;
    }
}