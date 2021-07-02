using Spectre.Console;

namespace Lib.Helpers
{
    public class ConsoleHelper : IConsoleHelper
    {
        public void RenderTitle(string text)
        {
            AnsiConsole.WriteLine();
            AnsiConsole.Render(new FigletText(text).LeftAligned());
            AnsiConsole.WriteLine();
        }

        public void RenderSsins(params string[] ssins)
        {
            var table = new Table()
                .BorderColor(Color.White)
                .Border(TableBorder.Square)
                .Title($"[yellow]{ssins.Length} Ssin(s)[/]")
                .AddColumn(new TableColumn("[u]Ssin[/]").Centered());

            foreach (var ssin in ssins)
            {
                table.AddRow(ssin);
            }

            AnsiConsole.WriteLine();
            AnsiConsole.Render(table);
            AnsiConsole.WriteLine();
        }

        public void RenderSsin(string ssin, string cipherSsin)
        {
            var table = new Table()
                .BorderColor(Color.White)
                .Border(TableBorder.Square)
                .Title("[yellow]Encryption/Decryption[/]")
                .AddColumn(new TableColumn("[u]Ssin[/]").Centered())
                .AddColumn(new TableColumn("[u]Cipher Ssin[/]").Centered())
                .AddRow(ssin, cipherSsin);

            AnsiConsole.WriteLine();
            AnsiConsole.Render(table);
            AnsiConsole.WriteLine();
        }

        public void RenderSsin(string ssin, bool isValid)
        {
            var text = isValid 
                ? $"[green]Ssin {ssin} is valid[/]" 
                : $"[red]Ssin {ssin} is not valid[/]";

            AnsiConsole.Markup(text);
        }
    }
}