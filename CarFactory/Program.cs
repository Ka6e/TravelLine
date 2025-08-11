using CarFactory.UI;
using CarFactory.UI.Commands;
using Spectre.Console;

namespace CarFactory;

public class Program
{
    static void Main( string[] args )
    {
        try
        {
            var carManager = new CarManager.CarManager();
            var commands = new List<ICommand>
            {
                new CreateCarCommand( carManager ),
                new ShowCarsCommand( carManager ),
                new ExitCommand(),
            };

            ConsoleUserInterface ui = new ConsoleUserInterface( commands );
            ui.Run();
        }
        catch ( Exception ex )
        {
            AnsiConsole.WriteLine( ex.Message );
        }
    }
}
