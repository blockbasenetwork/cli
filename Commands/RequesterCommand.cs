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
    [Command(Name = "requester", OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    [Subcommand(
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
    public class RequesterCommand : BaseCliCommand
    {
        public RequesterCommand(ILogger<RequesterCommand> logger, IConsole console) : base(logger, console)
        {
        }

        protected override Task<int> OnExecute(CommandLineApplication app)
        {
            app.ShowHelp();
            return Task.FromResult(0);
        }
    }
}