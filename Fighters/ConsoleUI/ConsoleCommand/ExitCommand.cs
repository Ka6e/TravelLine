using Fighters.ConsoleUI.ConsoleCommands;

namespace Fighters.ConsoleUI.ConsoleCommand
{
    public class ExitCommand : IConsoleCommand
    {
        public string Name => "Exit";
        public string Description => "Exit the application";

        public void Execute()
        {
            Console.WriteLine( "Exeting." );
            Environment.Exit( 0 );
        }
    }
}
