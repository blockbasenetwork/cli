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

namespace BlockBase.Cli.Commands.RequesterCommands
{
    [Command(Name = "removefromblacklist",
             Description = "",
             OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    public class RemoveAccountFromBlacklistCommand : BaseCliCommand
    {
        private IBlockBaseRequesterService _service;

        [Option(CommandOptionType.SingleValue, ShortName = "a", LongName = "account", Description = "Account Name", ValueName = "Account", ShowInHelpText = true)]
        public string Account { get; }

        public RemoveAccountFromBlacklistCommand(ILogger<RemoveAccountFromBlacklistCommand> logger, IConsole console, IOptions<CliConfig> config, IBlockBaseRequesterService service) : base(logger, console, config)
        {
            _service = service;
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            var response = await _service.RemoveAccountFromBlacklist(Endpoint, Account);
            dynamic parsedJson = JsonConvert.DeserializeObject(response);
            var result = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            Console.WriteLine(result);
            return 0;
        }
    }
}