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
    [Command(Name = "removerequesterdatabases",
             Description = "Removes encrypted databases and the keys used to encrypt",
             OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    public class RemoveSidechainDatabasesAndKeysCommand : BaseCliCommand
    {
        private IBlockBaseRequesterService _service;

        public RemoveSidechainDatabasesAndKeysCommand(ILogger<RemoveSidechainDatabasesAndKeysCommand> logger, IConsole console, IBlockBaseRequesterService service) : base(logger, console)
        {
            _service = service;
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            var response = await _service.RemoveSidechainDatabasesAndKeys(Endpoint);
            dynamic parsedJson = JsonConvert.DeserializeObject(response);
            var result = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            Console.WriteLine(result);
            return 0;
        }
    }
}