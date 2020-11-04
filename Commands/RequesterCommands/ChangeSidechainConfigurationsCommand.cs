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
    [Command(Name = "changeconfigurations",
             Description = "",
             OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    public class ChangeSidechainConfigurationsCommand : BaseCliCommand
    {
        private IBlockBaseRequesterService _service;

        [Option(CommandOptionType.SingleValue, ShortName = "maxpaymentfull", LongName = "maxpaymentfullproducer", Description = "Max payment per block for full producer", ValueName = "Max payment full producer", ShowInHelpText = true)]
        public decimal? MaxPaymentPerBlockFullProducer { get; }

        [Option(CommandOptionType.SingleValue, ShortName = "minpaymentfull", LongName = "minpaymentfullproducer", Description = "Min payment per block for full producer", ValueName = "Min payment full producer", ShowInHelpText = true)]
        public decimal? MinPaymentPerBlockFullProducer { get; }

        [Option(CommandOptionType.SingleValue, ShortName = "maxpaymenthistory", LongName = "maxpaymenthistoryproducer", Description = "Max payment per block for history producer", ValueName = "Max payment history producer", ShowInHelpText = true)]
        public decimal? MaxPaymentPerBlockHistoryProducer { get; }

        [Option(CommandOptionType.SingleValue, ShortName = "minpaymenthistory", LongName = "minpaymenthistoryproducer", Description = "Min payment per block for history producer", ValueName = "Min payment history producer", ShowInHelpText = true)]
        public decimal? MinPaymentPerBlockHistoryProducer { get; }

        [Option(CommandOptionType.SingleValue, ShortName = "maxpaymentvalidator", LongName = "maxpaymentvalidatorproducer", Description = "Max payment per block for validator producer", ValueName = "Max payment validator producer", ShowInHelpText = true)]
        public decimal? MaxPaymentPerBlockValidatorProducer { get; }

        [Option(CommandOptionType.SingleValue, ShortName = "minpaymentvalidator", LongName = "minpaymentvalidatorproducer", Description = "Min payment per block for validator producer", ValueName = "Min payment validator producer", ShowInHelpText = true)]
        public decimal? MinPaymentPerBlockValidatorProducer { get; }

        [Option(CommandOptionType.SingleValue, ShortName = "minstake", LongName = "minstake", Description = "Minimum Candidature Stake", ValueName = "Minimum Stake", ShowInHelpText = true)]
        public decimal? MinStake { get; }

        [Option(CommandOptionType.SingleValue, ShortName = "numfullprod", LongName = "numfullprodudcers", Description = "Number of Required Full Producers", ValueName = "Number Full Producers", ShowInHelpText = true)]
        public int? NumberOfFullProducersRequired { get; }

        [Option(CommandOptionType.SingleValue, ShortName = "numhistoryprod", LongName = "numhistoryprodudcers", Description = "Number of Required History Producers", ValueName = "Number History Producers", ShowInHelpText = true)]
        public int? NumberOfHistoryProducersRequired { get; }

        [Option(CommandOptionType.SingleValue, ShortName = "numvalidatorprod", LongName = "numvalidatorprodudcers", Description = "Number of Required Validator Producers", ValueName = "Number Validator Producers", ShowInHelpText = true)]
        public int? NumberOfValidatorProducersRequired { get; }

        [Option(CommandOptionType.SingleValue, ShortName = "blocktimeinsec", LongName = "blocktimeinsec", Description = "Block Time in Seconds", ValueName = "Block Time", ShowInHelpText = true)]
        public int? BlockTimeInSeconds { get; }

        [Option(CommandOptionType.SingleValue, ShortName = "blocksizeinbyte", LongName = "blocktimeinbyte", Description = "Block Size in Bytes", ValueName = "Block Size", ShowInHelpText = true)]
        public int? BlockSizeInBytes { get; }

        public ChangeSidechainConfigurationsCommand(ILogger<ChangeSidechainConfigurationsCommand> logger, IConsole console, IOptions<CliConfig> config, IBlockBaseRequesterService service) : base(logger, console, config)
        {
            _service = service;
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            var response = await _service.ChangeSidechainConfigurations(Endpoint, MaxPaymentPerBlockFullProducer, MinPaymentPerBlockFullProducer, 
                                                                        MaxPaymentPerBlockHistoryProducer, MinPaymentPerBlockHistoryProducer, 
                                                                        MaxPaymentPerBlockValidatorProducer, MinPaymentPerBlockValidatorProducer, 
                                                                        MinStake, NumberOfFullProducersRequired, NumberOfHistoryProducersRequired, 
                                                                        NumberOfValidatorProducersRequired, BlockTimeInSeconds, BlockSizeInBytes);
            dynamic parsedJson = JsonConvert.DeserializeObject(response);
            var result = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            Console.WriteLine(result);
            return 0;
        }
    }
}