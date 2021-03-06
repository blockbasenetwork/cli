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
    [Command(Name = "requesttoleavesidechain",
             Description = "Sends a transaction to BlockBase Operations Contract stating that the provider wants to leave this sidechain",
             OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    public class RequestToLeaveSidechainProduction : BaseCliCommand
    {
        private IBlockBaseProviderService _service;

        [Option(CommandOptionType.SingleValue, ShortName = "s", LongName = "sidechain", Description = "Sidechain Name", ValueName = "Sidechain", ShowInHelpText = true)]
        public string Sidechain { get; }

        [Option(CommandOptionType.SingleValue, ShortName = "clean", LongName = "cleanlocaldata", Description = "Clean Local Data", ValueName = "Clean Local Data", ShowInHelpText = true)]
        public int CleanLocalData { get; }

        public RequestToLeaveSidechainProduction(ILogger<RequestToLeaveSidechainProduction> logger, IConsole console, IBlockBaseProviderService service) : base(logger, console)
        {
            _service = service;
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            var response = await _service.RequestToProduceSidechain(Endpoint, Sidechain, CleanLocalData);
            dynamic parsedJson = JsonConvert.DeserializeObject(response);
            var result = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            Console.WriteLine(result);
            return 0;
        }
    }
}