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
    [Command(Name = "gettransaction",
             Description = "Gets a transaction of a given sidechain",
             OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    public class GetTransactionCommand : BaseCliCommand
    {
        private IBlockBaseProviderService _service;

        [Option(CommandOptionType.SingleValue, ShortName = "s", LongName = "sidechain", Description = "Sidechain Name", ValueName = "Sidechain", ShowInHelpText = true)]
        public string Sidechain { get; }

        [Option(CommandOptionType.SingleValue, ShortName = "tn", LongName = "transactionnumber", Description = "Transaction Number", ValueName = "Transaction Number", ShowInHelpText = true)]
        public int TransactionNumber { get; }

        public GetTransactionCommand(ILogger<GetTransactionCommand> logger, IConsole console, IBlockBaseProviderService service) : base(logger, console)
        {
            _service = service;
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            var response = await _service.GetTransaction(Endpoint, Sidechain, TransactionNumber);
            dynamic parsedJson = JsonConvert.DeserializeObject(response);
            var result = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            Console.WriteLine(result);
            return 0;
        }
    }
}