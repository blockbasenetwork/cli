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
    [Command(Name = "claimallrewards", 
             Description = "Claims all the rewards that the account of the provider is entitled to", 
             OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    public class ClaimAllRewardsCommand : BaseCliCommand
    {
        private IBlockBaseProviderService _service;

        public ClaimAllRewardsCommand(ILogger<ClaimAllRewardsCommand> logger, IConsole console, IBlockBaseProviderService service) : base(logger, console)
        {
            _service = service;
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            var response = await _service.ClaimAllRewards(Endpoint);
            dynamic parsedJson = JsonConvert.DeserializeObject(response);
            var result = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            Console.WriteLine(result);
            return 0;
        }
    }
}