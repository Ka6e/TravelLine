using Spectre.Console;

namespace CarFactory.UI.Commands
{
    public class ShowCars : ICommand
    {
        private readonly CarManager.CarManager _manager;
        public string Name => "Show cars";

        public ShowCars( CarManager.CarManager carManager )
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

            foreach ( var car in cars )
            {
                table.AddRow(
                    car.Number,
                    car.Color.ToString(),
                    car.BodyType.Name,
                    car.Engine.Name,
                    car.Transmission.Name );
            }

            AnsiConsole.Write( table );
        }
    }
}
