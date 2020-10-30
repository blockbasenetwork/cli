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
    [Command(Name = "checkproducerconfig", 
             Description = "", 
             OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    public class CheckProducerConfigCommand : BaseCliCommand
    {
        private IBlockBaseProviderService _service;

        public CheckProducerConfigCommand(ILogger<CheckProducerConfigCommand> logger, IConsole console, IOptions<CliConfig> config, IBlockBaseProviderService service) : base(logger, console, config)
        {
            _service = service;
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            var response = await _service.CheckProducerConfig(Endpoint);
            dynamic parsedJson = JsonConvert.DeserializeObject(response);
            var result = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            Console.WriteLine(result);
            return 0;
        }
    }
}