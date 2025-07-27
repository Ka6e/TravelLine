using Fighters.Logger;
using Fighters.Manager;
using Fighters.UI;

namespace Fighters;

public class Program
{
    static void Main( string[] args )
    {
        try
        {
            var logger = new FightersLogger();
            var manager = new GameManager( logger );
            var ui = new ConsoleUI( manager );

            ui.Run();
        }
        catch ( Exception ex )
        {
            Console.WriteLine( $"Error: {ex.Message}" );
        }
    }
}
