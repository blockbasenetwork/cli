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
    [Command(Name = "checkreservedseats",
             Description = "Gets all the current reserved seats in the sidechain",
             OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    public class CheckSidechainReservedSeatsCommand : BaseCliCommand
    {
        private IBlockBaseRequesterService _service;

        public CheckSidechainReservedSeatsCommand(ILogger<CheckSidechainReservedSeatsCommand> logger, IConsole console, IBlockBaseRequesterService service) : base(logger, console)
        {
            _service = service;
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            var response = await _service.CheckSidechainReservedSeats(Endpoint);
            dynamic parsedJson = JsonConvert.DeserializeObject(response);
            var result = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            Console.WriteLine(result);
            return 0;
        }
    }
}