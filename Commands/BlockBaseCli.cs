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
    [Command(Name = "blockbasecli", OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    [Subcommand(
        typeof(NetworkCommand),
        typeof(ProviderCommand),
        typeof(RequesterCommand),
        typeof(SaveKeyCommand))]
    public class BlockBaseCli : BaseCliCommand
    {
        public BlockBaseCli(ILogger<BlockBaseCli> logger, IConsole console) : base(logger, console)
        {
        }

        protected override Task<int> OnExecute(CommandLineApplication app)
        {
            app.ShowHelp();
            return Task.FromResult(0);
        }
    }
}