using BlockBase.Cli.Commands;
using McMaster.Extensions.Hosting.CommandLine;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BlockBase.Cli
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var hostBuilder = CreateHostBuilder(args);

            try
            {
                return await hostBuilder.RunCommandLineApplicationAsync<BlockBaseCli>(args);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostBuilder = new HostBuilder(args);

            var builder = hostBuilder
                    .ConfigureMainSettings(args)
                    .GetBuilder();

            return builder;
        }
    }
}
