using Fighters.Extensions;
using Fighters.Factories.ArmorFactory;
using Fighters.Factories.ClassFactory;
using Fighters.Factories.RaceFactory;
using Fighters.Factories.WeaponFactory;

namespace Fighters.ConsoleUI.ConsoleCommands
{
    public class AddFighterCommand : IConsoleCommand
    {
        private readonly GameManager.GameManager _gameManager;
        public string Name => "Add fighter";
        public string Description => "Add new fighter to the tournament";

        public AddFighterCommand( GameManager.GameManager gameManager )
        {
            _gameManager = gameManager;
        }

        public void Execute()
        {
            string name = SetName( "Enter name: " );
            Console.WriteLine( "Choose numbers." );
            Race race = ChooseEnum<Race>( "Choose race: " );
            Class @class = ChooseEnum<Class>( "Choose class: " );
            Weapon weapon = ChooseEnum<Weapon>( "Choose weapon: " );
            Armor armor = ChooseEnum<Armor>( "Choose armor: " );

            var fighterDto = new FighterEnumConfig( name, race, @class, weapon, armor );
            _gameManager.AddFighter( fighterDto );
            Console.WriteLine();
            Console.Clear();
        }

        private string SetName( string promt )
        {
            Console.Write( promt );
            while ( true )
            {
                string name = Console.ReadLine();
                if ( !String.IsNullOrWhiteSpace( name ) )
                {
                    return name;
                }
                Console.Write( "Incorrect name. Try again: " );
            }

        }

        private T ChooseEnum<T>( string prompt ) where T : Enum
        {
            while ( true )
            {
                Console.WriteLine( $"{typeof( T ).Name}s:" );

                foreach ( var value in Enum.GetValues( typeof( T ) ) )
                {
                    Console.WriteLine( $"{( int )value}. {value}" );
                }

                Console.Write( prompt );
                if ( int.TryParse( Console.ReadLine(), out var choice ) && Enum.IsDefined( typeof( T ), choice ) )
                {
                    return ( T )( object )choice;
                }
                Console.WriteLine( $"Incorrect {typeof( T ).Name}" );
            }
        }
    }
}
