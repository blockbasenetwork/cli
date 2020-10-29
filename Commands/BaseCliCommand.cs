using BlockBase.Cli.Configuration;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Threading.Tasks;

namespace BlockBase.Cli.Commands
{
    public class BaseCliCommand
    {
        protected ILogger _logger;
        protected IConsole _console;
        protected CliConfig _configuration;

        [Option(CommandOptionType.SingleValue, ShortName = "u", LongName = "url", Description = "Endpoint Url", ValueName = "Endpoint", ShowInHelpText = true)]
        public string Endpoint { get; } = "http://127.0.0.1:5000";

        public BaseCliCommand(ILogger<BaseCliCommand> logger, IConsole console, IOptions<CliConfig> config)
        {
            _logger = logger;
            _console = console;
            _configuration = config.Value;
        }       

        virtual protected Task<int> OnExecute(CommandLineApplication app)
        {
            return Task.FromResult(0);
        }
    }
}