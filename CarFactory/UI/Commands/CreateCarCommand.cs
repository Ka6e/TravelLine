using CarFactory.Extensions;
using CarFactory.Factories.BodyTypeFactory;
using CarFactory.Factories.EngineFactory;
using CarFactory.Factories.TransmissionFactory;
using Spectre.Console;

namespace CarFactory.UI.Commands
{
    public class CreateCarCommand : ICommand
    {
        private readonly CarManager.CarManager _carManager;

        public string Name => "Create a car";

        public CreateCarCommand( CarManager.CarManager carManager )
        {
            _carManager = carManager;
        }

        public void Execute()
        {
            string name = SetNumber( "Enter the number of your car" );
            Models.Colors.Color color = SelectColor();
            BodyType body = SelectBody();
            Engines enige = SelectEngine();
            Transmissions transmission = SelectTransmission();
            var carDto = new CarDTO( name, color, body, enige, transmission );
            _carManager.CreateaCar( carDto );
            AnsiConsole.Clear();
        }

        private string SetNumber( string prompt )
        {
            string example = "A256BC";
            AnsiConsole.Write( $"{prompt} example({example}): " );
            while ( true )
            {
                string number = Console.ReadLine();
                if ( !string.IsNullOrEmpty( number ) && number.Length == 6 )
                {
                    return number;
                }
                AnsiConsole.Markup( "[red]Your number is empty. Try again:[/] " );
            }
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

        private Models.Colors.Color SelectColor()
        {
            var colorMap = new Dictionary<string, Models.Colors.Color>()
            {
                { "[red]Red[/]", Models.Colors.Color.Red },
                { "[green]Green[/]", Models.Colors.Color.Green },
                { "[blue]Blue[/]", Models.Colors.Color.Blue },
                { "[white]Black[/]", Models.Colors.Color.Black },
                { "[white]White[/]", Models.Colors.Color.White },
                { "[grey]Grey[/]", Models.Colors.Color.Grey },
                { "[yellow]Yellow[/]", Models.Colors.Color.Yellow }
            };

            string colorStr = "[red]c[/][orangered1]o[/][yellow]l[/][green]o[/][blue]r[/]";
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
                .Title( "What kind of [yellow]body[/] do you want?" )
                .PageSize( 10 )
                .MoreChoicesText( "[grey](Move up and down to reveal more colors)[/]" )
                .AddChoices( Enum.GetValues<BodyType>() ) );

            return body;
        }
    }
}
