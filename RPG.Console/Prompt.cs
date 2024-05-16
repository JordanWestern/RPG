using RPG.App.Menus;
using Spectre.Console;

namespace RPG.Console;

// https://spectreconsole.net/
internal static class Prompt
{
    public static string Menu(IMenu menu) =>
        AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(menu.Title)
                .AddChoices(menu.Options.ToArray()));

    public static string Single(string prompt) => AnsiConsole.Prompt(
        new TextPrompt<string>(prompt)
            .ValidationErrorMessage("[red]Cannot be empty![/]")
            .Validate(result => !string.IsNullOrWhiteSpace(result)));
}