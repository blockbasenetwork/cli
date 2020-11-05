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
    [Command(Name = "requestnewsidechain",
             Description = "Requests a new sidechain for storing databases",
             OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    public class RequestNewSidechainCommand : BaseCliCommand
    {
        private IBlockBaseRequesterService _service;

        [Option(CommandOptionType.SingleValue, ShortName = "stake", LongName = "stake", Description = "Stake", ValueName = "Stake", ShowInHelpText = true)]
        public decimal Stake { get; }

        public RequestNewSidechainCommand(ILogger<RequestNewSidechainCommand> logger, IConsole console, IBlockBaseRequesterService service) : base(logger, console)
        {
            _service = service;
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            var response = await _service.RequestNewSidechain(Endpoint, Stake);
            dynamic parsedJson = JsonConvert.DeserializeObject(response);
            var result = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            Console.WriteLine(result);
            return 0;
        }
    }
}