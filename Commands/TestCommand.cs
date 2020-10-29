using BlockBase.Cli.Configuration;
using BlockBase.Services;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace BlockBase.Cli.Commands
{
    [Command(Name = "test", OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    public class TestCommand : BaseCliCommand
    {
        private IBlockBaseNetworkService _service;

        public TestCommand(ILogger<TestCommand> logger, IConsole console, IOptions<CliConfig> config, IBlockBaseNetworkService service) : base(logger, console, config)
        {
            _service = service;
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            _logger.LogInformation($"Test {Endpoint}");
            var test = await _service.GetSidechainConfiguration(Endpoint, "bbmainacc112");
            dynamic parsedJson = JsonConvert.DeserializeObject(test);
            var result = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            Console.WriteLine(result);
            return 0;
        }
    }
}