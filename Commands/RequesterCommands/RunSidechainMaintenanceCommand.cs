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
    [Command(Name = "runsidechainmaintenance",
             Description = "The requester uses this service to start the process for producers to participate and build the sidechain",
             OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    public class RunSidechainMaintenanceCommand : BaseCliCommand
    {
        private IBlockBaseRequesterService _service;

        public RunSidechainMaintenanceCommand(ILogger<RunSidechainMaintenanceCommand> logger, IConsole console, IBlockBaseRequesterService service) : base(logger, console)
        {
            _service = service;
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            var response = await _service.RunSidechainMaintenance(Endpoint);
            dynamic parsedJson = JsonConvert.DeserializeObject(response);
            var result = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            Console.WriteLine(result);
            return 0;
        }
    }
}