using BlockBase.Cli.Commands.KeyCommands;
using BlockBase.Cli.Commands.NetworkCommands;
using BlockBase.Cli.Commands.ProviderCommands;
using BlockBase.Cli.Commands.RequesterCommands;
using BlockBase.Cli.Configuration;
using BlockBase.Cli.Helpers;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlockBase.Cli.Commands
{
    [Command(Name = "provider", OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    [Subcommand(
        typeof(AddStakeProviderCommand),
        typeof(CheckProducerConfigCommand),
        typeof(ClaimAllRewardsCommand),
        typeof(ClaimStakeCommand),
        typeof(DeleteSidechainFromDatabaseCommand),
        typeof(GetBlockCommand),
        typeof(GetDecryptedNodeIpsCommand),
        typeof(GetPastSidechainsCommand),
        typeof(GetProducingSidechainsCommand),
        typeof(GetSidechainNodeSoftwareVersionCommand),
        typeof(GetTransactionCommand),
        typeof(GetTransactionsInMempoolCommand),
        typeof(RemoveCandidatureCommand),
        typeof(RequestToLeaveSidechainProduction),
        typeof(RequestToProduceSidechainCommand))]
    public class ProviderCommand : BaseCliCommand
    {
        public ProviderCommand(ILogger<ProviderCommand> logger, IConsole console) : base(logger, console)
        {
        }

        protected override Task<int> OnExecute(CommandLineApplication app)
        {
            app.ShowHelp();
            return Task.FromResult(0);
        }
    }
}