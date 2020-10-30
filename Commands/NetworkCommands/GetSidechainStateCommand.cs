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
    [Command(Name = "getsidechainstate", OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    public class GetSidechainStateCommand : BaseCliCommand
    {
        private IBlockBaseNetworkService _service;

        [Option(CommandOptionType.SingleValue, ShortName = "s", LongName = "sidechain", Description = "Sidechain Name", ValueName = "Sidechain", ShowInHelpText = true)]
        public string Sidechain { get; }

        public GetSidechainStateCommand(ILogger<GetSidechainStateCommand> logger, IConsole console, IOptions<CliConfig> config, IBlockBaseNetworkService service) : base(logger, console, config)
        {
            _service = service;
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            var response = await _service.GetSidechainState(Endpoint, Sidechain);
            dynamic parsedJson = JsonConvert.DeserializeObject(response);
            var result = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            Console.WriteLine(result);
            return 0;
        }
    }
}