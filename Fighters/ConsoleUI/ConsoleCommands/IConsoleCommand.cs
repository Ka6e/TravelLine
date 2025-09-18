namespace Fighters.ConsoleUI.ConsoleCommands
{
    public interface IConsoleCommand
    {
        string Name { get; }
        string Description { get; }
        void Execute();
    }
}
