using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BlockBase.Cli.Configuration;
using BlockBase.Cli.Helpers;
using BlockBase.Cli.Services;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BlockBase.Cli.Commands.KeyCommands
{
    [Command(Name = "savekey", 
             Description = "Saves a key associated to a key name to use in executing queries", 
             OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    public class SaveKeyCommand : BaseCliCommand
    {
        [Option(CommandOptionType.SingleValue, ShortName = "keyname", LongName = "keyname", Description = "Key Name", ValueName = "Key Name", ShowInHelpText = true)]
        public string KeyName { get; }

        [Option(CommandOptionType.SingleValue, ShortName = "key", LongName = "key", Description = "Key", ValueName = "Key", ShowInHelpText = true)]
        public string Key { get; }

        public SaveKeyCommand(ILogger<SaveKeyCommand> logger, IConsole console, IOptions<CliConfig> config) : base(logger, console, config)
        {
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            var keyStorage = new KeyStorage();
            var keyBytes = Encoding.UTF8.GetBytes(Key);
            var password = keyStorage.SaveKey(KeyName, keyBytes);
            Console.WriteLine($"Password for saved key: {password}");
            Console.WriteLine($"Please store this password in order to be able to use this key when executing queries through the CLI.");
            return 0;
        }
    }
}