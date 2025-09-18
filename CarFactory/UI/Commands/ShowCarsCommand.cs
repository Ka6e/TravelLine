using Spectre.Console;

namespace CarFactory.UI.Commands
{
    public class ShowCarsCommand : ICommand
    {
        private readonly CarManager.CarManager _manager;
        public string Name => "Show cars";

        public ShowCarsCommand( CarManager.CarManager carManager )
        {
            _manager = carManager;
        }

        public void Execute()
        {
            ShowCar();
            AnsiConsole.MarkupLine( "[grey]Press any key to continue...[/]" );
            Console.ReadKey();
            AnsiConsole.Clear();
        }

        public void ShowCar()
        {
            var cars = _manager.GetCars();
            var table = new Table();
            table.AddColumn( "Number" );
            table.AddColumn( "Color" );
            table.AddColumn( "BodyType" );
            table.AddColumn( "Engine" );
            table.AddColumn( "Transmission" );
            table.AddColumn( "Max Speed" );
            foreach ( var car in cars )
            {
                table.AddRow(
                    car.Number,
                    car.Color.ToString(),
                    car.BodyType.Name,
                    car.Engine.Name,
                    car.Transmission.Name,
                    car.MaxSpeed().ToString() );
            }
            AnsiConsole.Write( table );
        }
    }
}
