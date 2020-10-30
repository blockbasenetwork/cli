using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BlockBase.Cli.Configuration;
using BlockBase.Cli.Services;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BlockBase.Cli.Commands.ProviderCommands
{
    [Command(Name = "get block",
             Description = "",
             OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    public class GetBlockCommand : BaseCliCommand
    {
        private IBlockBaseProviderService _service;

        [Option(CommandOptionType.SingleValue, ShortName = "s", LongName = "sidechain", Description = "Sidechain Name", ValueName = "Sidechain", ShowInHelpText = true)]
        public string Sidechain { get; }

        [Option(CommandOptionType.SingleValue, ShortName = "bn", LongName = "blocknumber", Description = "Block Number", ValueName = "Block Number", ShowInHelpText = true)]
        public int BlockNumber { get; }

        public GetBlockCommand(ILogger<GetBlockCommand> logger, IConsole console, IOptions<CliConfig> config, IBlockBaseProviderService service) : base(logger, console, config)
        {
            _service = service;
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            var response = await _service.GetBlock(Endpoint, Sidechain, BlockNumber);
            dynamic parsedJson = JsonConvert.DeserializeObject(response);
            var result = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            Console.WriteLine(result);
            return 0;
        }
    }
}