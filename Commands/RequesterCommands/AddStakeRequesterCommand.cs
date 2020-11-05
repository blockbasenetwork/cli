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
    [Command(Name = "addstake",
             Description = "Sends a transaction to BlockBase Token Contract to add sidechain stake",
             OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    public class AddStakeRequesterCommand : BaseCliCommand
    {
        private IBlockBaseRequesterService _service;

        [Option(CommandOptionType.SingleValue, ShortName = "stake", LongName = "stake", Description = "Stake", ValueName = "Stake", ShowInHelpText = true)]
        public double Stake { get; }

        public AddStakeRequesterCommand(ILogger<AddStakeRequesterCommand> logger, IConsole console, IBlockBaseRequesterService service) : base(logger, console)
        {
            _service = service;
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            var response = await _service.AddStake(Endpoint, Stake);
            dynamic parsedJson = JsonConvert.DeserializeObject(response);
            var result = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            Console.WriteLine(result);
            return 0;
        }
    }
}