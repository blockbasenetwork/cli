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
    [Command(Name = "getdecryptednodeipsrequester",
             Description = "",
             OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    public class GetDecryptedNodeIpsRequesterCommand : BaseCliCommand
    {
        private IBlockBaseRequesterService _service;

        public GetDecryptedNodeIpsRequesterCommand(ILogger<GetDecryptedNodeIpsRequesterCommand> logger, IConsole console, IOptions<CliConfig> config, IBlockBaseRequesterService service) : base(logger, console, config)
        {
            _service = service;
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            var response = await _service.GetDecryptedNodeIps(Endpoint);
            dynamic parsedJson = JsonConvert.DeserializeObject(response);
            var result = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            Console.WriteLine(result);
            return 0;
        }
    }
}