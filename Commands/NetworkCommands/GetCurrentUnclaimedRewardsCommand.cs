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
    [Command(Name = "getcurrentunclaimedrewards", 
             Description = "Gets the current list of unclaimed rewards for a given provider",
             OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    public class GetCurrentUnclaimedRewardsCommand : BaseCliCommand
    {
        private IBlockBaseNetworkService _service;

        [Option(CommandOptionType.SingleValue, ShortName = "a", LongName = "account", Description = "Account Name", ValueName = "Account", ShowInHelpText = true)]
        public string Account { get; }

        public GetCurrentUnclaimedRewardsCommand(ILogger<GetCurrentUnclaimedRewardsCommand> logger, IConsole console, IBlockBaseNetworkService service) : base(logger, console)
        {
            _service = service;
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            var response = await _service.GetCurrentUnclaimedRewards(Endpoint, Account);
            dynamic parsedJson = JsonConvert.DeserializeObject(response);
            var result = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            Console.WriteLine(result);
            return 0;
        }
    }
}