using System.ComponentModel;
using Fighters.Extensions;
using Fighters.Factories.ArmorFactory;
using Fighters.Factories.ClassFactory;
using Fighters.Factories.RaceFactory;
using Fighters.Factories.WeaponFactory;
using Fighters.Manager;

namespace Fighters.UI
{
    public class ConsoleUI
    {
        private readonly GameManager _manager;
        private MenuActions? _menuAction;

        public ConsoleUI( GameManager manager )
        {
            _manager = manager;
        }
        public void Run()
        {

            while ( _menuAction != MenuActions.Exit )
            {
                ShowMenu();
                _menuAction = GetAction();
                HandleAction( _menuAction );
            }
        }

        private void HandleAction( MenuActions? action )
        {
            switch ( action )
            {
                case MenuActions.AddFighter:
                    Console.WriteLine();
                    string name = SetName( "Enter name: " );
                    Race race = ChooseEnum<Race>( "Choose race: " );
                    Class @class = ChooseEnum<Class>( "Choose class: " );
                    Weapon weapon = ChooseEnum<Weapon>( "Choose weapon: " );
                    Armor armor = ChooseEnum<Armor>( "Choose armor: " );

                    var fighterDto = new FighterDTO( name, race, @class, weapon, armor );

                    _manager.AddFighter( fighterDto );
                    Console.WriteLine();
                    break;
                case MenuActions.ShowFighters:
                    Console.WriteLine();
                    _manager.ShowFighters();
                    break;
                case MenuActions.Play:
                    Console.WriteLine();
                    _manager.Fight();
                    break;
                case MenuActions.Exit:
                    break;
                default:
                    throw new Exception( "Unknown action." );
            }
        }

        private MenuActions? GetAction()
        {
            Console.Write( "Choose action: " );
            bool isParsed = Enum.TryParse( Console.ReadLine(), out MenuActions result );
            return isParsed ? result : null;
        }

        private void ShowMenu()
        {
            foreach ( MenuActions action in Enum.GetValues( typeof( MenuActions ) ) )
            {
                Console.WriteLine( $"{( int )action}. {GetEnumDescribtion( action )}" );
            }
        }

        private string GetEnumDescribtion( Enum value )
        {
            var field = value.GetType().GetField( value.ToString() );
            var attr = field?.GetCustomAttributes( typeof( DescriptionAttribute ), false )
                .FirstOrDefault() as DescriptionAttribute;
            return attr?.Description ?? value.ToString();
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

                Console.WriteLine( "Incorrect name." );
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
