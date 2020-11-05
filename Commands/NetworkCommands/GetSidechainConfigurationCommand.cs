using BlockBase.Cli.Configuration;
using BlockBase.Cli.Services;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace BlockBase.Cli.Commands.NetworkCommands
{
    [Command(Name = "getsidechainconfig",
             Description = "Gets the contract information of a sidechain that is started and configured",
             OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    public class GetSidechainConfigurationCommand : BaseCliCommand
    {
        private IBlockBaseNetworkService _service;

        [Option(CommandOptionType.SingleValue, ShortName = "s", LongName = "sidechain", Description = "Sidechain Name", ValueName = "Sidechain", ShowInHelpText = true)]
        public string Sidechain { get; }

        public GetSidechainConfigurationCommand(ILogger<GetSidechainConfigurationCommand> logger, IConsole console, IBlockBaseNetworkService service) : base(logger, console)
        {
            _service = service;
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            var response = await _service.GetSidechainConfiguration(Endpoint, Sidechain);
            dynamic parsedJson = JsonConvert.DeserializeObject(response);
            var result = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            Console.WriteLine(result);
            return 0;
        }
    }
}