using System.ComponentModel.DataAnnotations;
using System.Linq;
using Lib.Constants;
using Lib.Helpers;
using Lib.Ssins;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

namespace App.Commands
{
    [Command(Name = "Generate", FullName = "Generate SSIN", Description = "Generate SSIN.")]
    [VersionOptionFromMember(MemberName = nameof(GetVersion))]
    [HelpOption]
    public class GenerateCommand : AbstractCommand
    {
        private readonly ISsinSelector _ssinSelector;
        private readonly IConsoleHelper _consoleHelper;
        private readonly ILogger _logger;

        public GenerateCommand(ISsinSelector ssinSelector, IConsoleHelper consoleHelper, ILogger logger)
        {
            _ssinSelector = ssinSelector;
            _consoleHelper = consoleHelper;
            _logger = logger;
        }

        [Option("-c|--country", "Country for ssin(s).", CommandOptionType.SingleValue)]
        public string Country { get; set; } = nameof(Countries.Belgium);

        [Range(1, 100)]
        [Option("-n|--number", "Number of ssin(s).", CommandOptionType.SingleValue)]
        public int? Number { get; set; } = 10;

        public void OnExecute(CommandLineApplication _)
        {
            var ssinGenerator = _ssinSelector.Resolve<ISsinGenerator>(Country);
            if (ssinGenerator == null)
            {
                _logger.LogError("This feature is not yet supported for country {country}", Country);
                return;
            }

            var ssins = ssinGenerator.GenerateSsin(Number!.Value).ToArray();
            _consoleHelper.RenderSsins(ssins);
        }

        private static string GetVersion() => GetVersion(typeof(GenerateCommand));
    }
}