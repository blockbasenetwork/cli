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
    [Command(Name = "sidechainconfig", OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    public class GetSidechainConfigurationCommand : BaseCliCommand
    {
        private IBlockBaseNetworkService _service;

        [Option(CommandOptionType.SingleValue, ShortName = "s", LongName = "sidechain", Description = "Sidechain Name", ValueName = "Sidechain", ShowInHelpText = true)]
        public string Sidechain { get; }

        public GetSidechainConfigurationCommand(ILogger<TestCommand> logger, IConsole console, IOptions<CliConfig> config, IBlockBaseNetworkService service) : base(logger, console, config)
        {
            _service = service;
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            var test = await _service.GetSidechainConfiguration(Endpoint, "bbmainacc112");
            dynamic parsedJson = JsonConvert.DeserializeObject(test);
            var result = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            Console.WriteLine(result);
            return 0;
        }
    }
}