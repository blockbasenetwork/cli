using BlockBase.Cli.Commands.NetworkCommands;
using BlockBase.Cli.Commands.ProviderCommands;
using BlockBase.Cli.Commands.RequesterCommands;
using BlockBase.Cli.Configuration;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Threading.Tasks;

namespace BlockBase.Cli.Commands
{
    [Command(Name = "blockbasecli", OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    [Subcommand(
        //Network
        typeof(GetAccountStakeRecordsCommand),
        typeof(GetPeerConnectionStateCommand),
        typeof(GetSidechainConfigurationCommand),
        typeof(GetCurrentUnclaimedRewardsCommand),
        typeof(GetProviderCandidatureStateCommand),
        typeof(GetSidechainStateCommand),
        //Provider
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
        typeof(RequestToProduceSidechainCommand),
        //Requester
        typeof(AddStakeRequesterCommand),
        typeof(ChangeSidechainConfigurationsCommand),
        typeof(CheckCurrentStakeInSidechainCommand),
        typeof(CheckRequesterConfigCommand),
        typeof(CheckSidechainReservedSeatsCommand),
        typeof(ClaimStakeRequesterCommand),
        typeof(EndSidechainCommand),
        typeof(ExecuteQueryCommand),
        typeof(GenerateMasterKeyCommand),
        typeof(GetDecryptedNodeIpsRequesterCommand),
        typeof(GetStructureCommand),
        typeof(PauseSidechainCommand),
        typeof(RemoveAccountFromBlacklistCommand),
        typeof(RemoveSidechainDatabasesAndKeysCommand),
        typeof(RequestNewSidechainCommand),
        typeof(RunSidechainMaintenanceCommand),
        typeof(SetSecretCommand))]
    public class BlockBaseCli : BaseCliCommand
    {
        public BlockBaseCli(ILogger<BlockBaseCli> logger, IConsole console, IOptions<CliConfig> config) : base(logger, console, config)
        {
        }

        protected override Task<int> OnExecute(CommandLineApplication app)
        {
            app.ShowHelp();
            return Task.FromResult(0);
        }
    }
}