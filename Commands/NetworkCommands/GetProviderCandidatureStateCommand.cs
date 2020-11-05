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
    [Command(Name = "getprovidercandidaturestate", 
             Description = "Gets information about the participation state of the producer on a sidechain",
             OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    public class GetProviderCandidatureStateCommand : BaseCliCommand
    {
        private IBlockBaseNetworkService _service;

        [Option(CommandOptionType.SingleValue, ShortName = "s", LongName = "sidechain", Description = "Sidechain Name", ValueName = "Sidechain", ShowInHelpText = true)]
        public string Sidechain { get; }

        [Option(CommandOptionType.SingleValue, ShortName = "a", LongName = "account", Description = "Account Name", ValueName = "Account", ShowInHelpText = true)]
        public string Account { get; }

        public GetProviderCandidatureStateCommand(ILogger<GetProviderCandidatureStateCommand> logger, IConsole console, IBlockBaseNetworkService service) : base(logger, console)
        {
            _service = service;
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            var response = await _service.GetProducerCandidatureState(Endpoint, Account, Sidechain);
            dynamic parsedJson = JsonConvert.DeserializeObject(response);
            var result = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            Console.WriteLine(result);
            return 0;
        }
    }
}