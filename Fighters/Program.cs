using Fighters.ConsoleUI.ConsoleCommand;
using Fighters.ConsoleUI.ConsoleCommands;
using Fighters.Logger;

namespace Fighters;

public class Program
{
    static void Main( string[] args )
    {
        try
        {
            var logger = new FightersLogger();
            var manager = new GameManager.GameManager( logger );
            List<IConsoleCommand> commands = new List<IConsoleCommand>
            {
                new AddFighterCommand( manager ),
                new ShowFightersCommand( manager ),
                new RemoveFighter( manager ),
                new PlayGameCommand( manager ),
                new ExitCommand()
            };

            var ui = new ConsoleUI.ConsoleUI( commands );
            ui.Run();
        }
        catch ( Exception ex )
        {
            Console.WriteLine( $"Error: {ex.Message}" );
        }
    }
}
