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
    [Command(Name = "executequery",
             Description = "Sends query to be executed",
             OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    public class ExecuteQueryCommand : BaseCliCommand
    {
        private IBlockBaseRequesterService _service;

        [Option(CommandOptionType.SingleValue, ShortName = "query", LongName = "querystring", Description = "Query String", ValueName = "Query String", ShowInHelpText = true)]
        public string Query { get; }

        [Option(CommandOptionType.SingleValue, ShortName = "key", LongName = "keyname", Description = "Key Name", ValueName = "Key Name", ShowInHelpText = true)]
        public string KeyToUse { get; }

        [Option(CommandOptionType.SingleValue, ShortName = "keypassword", LongName = "keypassword", Description = "Key Password", ValueName = "Key Password", ShowInHelpText = true)]
        public string KeyPassword { get; }

        public ExecuteQueryCommand(ILogger<ExecuteQueryCommand> logger, IConsole console, IBlockBaseRequesterService service) : base(logger, console)
        {
            _service = service;
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            var response = await _service.ExecuteQuery(Endpoint, Query, KeyToUse, KeyPassword);
            dynamic parsedJson = JsonConvert.DeserializeObject(response);
            var result = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            Console.WriteLine(result);
            return 0;
        }
    }
}