using System.ComponentModel.DataAnnotations;
using Lib.Constants;
using Lib.Helpers;
using Lib.Ssins;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

namespace App.Commands
{
    [Command(Name = "Validate", FullName = "Validate SSIN", Description = "Validate SSIN.")]
    [VersionOptionFromMember(MemberName = nameof(GetVersion))]
    [HelpOption]
    public class ValidateCommand : AbstractCommand
    {
        private readonly ISsinSelector _ssinSelector;
        private readonly IConsoleHelper _consoleHelper;
        private readonly ILogger _logger;

        public ValidateCommand(ISsinSelector ssinSelector, IConsoleHelper consoleHelper, ILogger logger)
        {
            _ssinSelector = ssinSelector;
            _consoleHelper = consoleHelper;
            _logger = logger;
        }

        [Option("-c|--country", "Country for ssin(s).", CommandOptionType.SingleValue)]
        public string Country { get; set; } = nameof(Countries.Belgium);

        [Required]
        [Argument(0)]
        public string Ssin { get; set; }

        public void OnExecute(CommandLineApplication _)
        {
            var ssinValidator = _ssinSelector.Resolve<ISsinValidator>(Country);
            if (ssinValidator == null)
            {
                _logger.LogError("This feature is not yet supported for country {country}", Country);
                return;
            }

            var isValid = ssinValidator.IsValid(Ssin);
            _consoleHelper.RenderSsin(Ssin, isValid);
        }

        private static string GetVersion() => GetVersion(typeof(GenerateCommand));
    }
}