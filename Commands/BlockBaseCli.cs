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
        typeof(TestCommand),
        typeof(GetSidechainConfigurationCommand))]
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