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

namespace BlockBase.Cli.Commands.NetworkCommands
{
    [Command(Name = "getpeerconnectionstate", OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    public class GetPeerConnectionStateCommand : BaseCliCommand
    {
        private IBlockBaseNetworkService _service;

        public GetPeerConnectionStateCommand(ILogger<GetPeerConnectionStateCommand> logger, IConsole console, IOptions<CliConfig> config, IBlockBaseNetworkService service) : base(logger, console, config)
        {
            _service = service;
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            var response = await _service.GetPeerConnectionsState(Endpoint);
            dynamic parsedJson = JsonConvert.DeserializeObject(response);
            var result = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            Console.WriteLine(result);
            return 0;
        }
    }
}