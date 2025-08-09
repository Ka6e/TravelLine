using CarFactory.Extensions;
using CarFactory.Factories.EngineFactory;
using CarFactory.Factories.TransmissionFactory;
using CarFactory.Models.BodyType;
using Spectre.Console;

namespace CarFactory.UI.Commands
{
    public class CreateCar : ICommand
    {
        private readonly CarManager.CarManager _carManager;

        public CreateCar( CarManager.CarManager carManager )
        {
            _carManager = carManager;
        }

        public void Execute()
        {
            string name = SetNumber( "Enter the number of your car: " );
            var color = SelectColor();
            var body = SelectBody();
            var enige = SelectEngine();
            var transmission = SelectTransmission();

            var CarDto = new CarDTO( name, color, body, enige, transmission );

            _carManager.CreateaCar( CarDto );
        }

        private string SetNumber( string prompt )
        {
            Console.Write( prompt );
            return prompt;
        }

        private Engines SelectEngine()
        {
            var engine = AnsiConsole.Prompt(
                new SelectionPrompt<Engines>()
                .Title( "What kind of [red]engine[/] do you want?" )
                .PageSize( 10 )
                .MoreChoicesText( "[grey](Move up and down to reveal more engines)[/]" )
                .AddChoices( Enum.GetValues<Engines>() ) );
            return engine;
        }

        private Transmissions SelectTransmission()
        {
            var transmissions = AnsiConsole.Prompt(
                new SelectionPrompt<Transmissions>()
                .Title( "What kind of [blue]transmission[/] do you want?" )
                .PageSize( 10 )
                .MoreChoicesText( "[grey](Move up and down to reveal more transmissions)[/]" )
                .AddChoices( Enum.GetValues<Transmissions>() ) );
            return transmissions;
        }

        private CarFactory.Models.Colors.Color SelectColor()
        {
            var colorMap = new Dictionary<string, Models.Colors.Color>()
            {
                { "[red]Red[/]", Models.Colors.Color.Red },
                { "[green]Green[/]", Models.Colors.Color.Green },
                { "[blue]Blue[/]", Models.Colors.Color.Blue },
                { "[black]Black[/]", Models.Colors.Color.Black },
                { "[white]White[/]", Models.Colors.Color.White },
                { "[grey]Grey[/]", Models.Colors.Color.Grey },
                { "[yellow]Yellow[/]", Models.Colors.Color.Yellow }
            };

            string colorStr = "[red]c[/][orange]o[/][yellow]l[/][green]o[/][blue]r[/]";
            var selectedColor = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title( $"What kind of {colorStr} do you want?" )
                .PageSize( 10 )
                .MoreChoicesText( "[grey](Move up and down to reveal more colors)[/]" )
                .AddChoices( colorMap.Keys ) );

            return colorMap[ selectedColor ];
        }

        private BodyType SelectBody()
        {
            var body = AnsiConsole.Prompt(
                new SelectionPrompt<BodyType>()
                .Title( "What kind of body do you want?" )
                .PageSize( 10 )
                .MoreChoicesText( "[grey](Move up and down to reveal more colors)[/]" )
                .AddChoices( Enum.GetValues<BodyType>() ) );
            return body;
        }
    }
}
