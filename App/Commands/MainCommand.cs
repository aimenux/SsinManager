using Lib.Helpers;
using McMaster.Extensions.CommandLineUtils;

namespace App.Commands
{
    [Command(Name = "Main", FullName = "Manage SSIN", Description = "Manage SSIN.")]
    [Subcommand(typeof(GenerateCommand), typeof(ValidateCommand))]
    [VersionOptionFromMember(MemberName = nameof(GetVersion))]
    public class MainCommand : AbstractCommand
    {
        private readonly IConsoleHelper _consoleHelper;

        public MainCommand(IConsoleHelper consoleHelper)
        {
            _consoleHelper = consoleHelper;
        }

        public void OnExecute(CommandLineApplication app)
        {
            const string title = "SsinManager";
            _consoleHelper.RenderTitle(title);
            app.ShowHelp();
        }

        protected static string GetVersion() => GetVersion(typeof(MainCommand));
    }
}
