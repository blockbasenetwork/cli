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

namespace BlockBase.Cli.Commands.ProviderCommands
{
    [Command(Name = "getmempooltransactions",
             Description = "Gets all transactions that haven't been added to a block",
             OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    public class GetTransactionsInMempoolCommand : BaseCliCommand
    {
        private IBlockBaseProviderService _service;

        [Option(CommandOptionType.SingleValue, ShortName = "s", LongName = "sidechain", Description = "Sidechain Name", ValueName = "Sidechain", ShowInHelpText = true)]
        public string Sidechain { get; }
        
        public GetTransactionsInMempoolCommand(ILogger<GetTransactionsInMempoolCommand> logger, IConsole console, IBlockBaseProviderService service) : base(logger, console)
        {
            _service = service;
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            var response = await _service.GetTransactionsInMempool(Endpoint, Sidechain);
            dynamic parsedJson = JsonConvert.DeserializeObject(response);
            var result = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            Console.WriteLine(result);
            return 0;
        }
    }
}