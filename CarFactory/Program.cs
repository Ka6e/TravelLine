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
                new CreateCar( carManager ),
                new ShowCars( carManager ),
                new Exit(),
            };
            UI.UI ui = new UI.UI( commands );
            ui.Run();
        }
        catch ( Exception ex )
        {
            AnsiConsole.WriteLine( ex.Message );
        }
    }
}
