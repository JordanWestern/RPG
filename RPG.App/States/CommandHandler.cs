namespace RPG.App.States;

public class CommandHandler : ICommandHandler
{
    private readonly Func<string> _getPlayerName;

    public CommandHandler(Func<string> getPlayerName)
    {
        _getPlayerName = getPlayerName;
    }

    public string GetPlayerName() => _getPlayerName();
}