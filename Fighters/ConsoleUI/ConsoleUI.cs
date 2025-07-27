using System.ComponentModel;
using Fighters.Extensions;
using Fighters.Factories.ArmorFactory;
using Fighters.Factories.ClassFactory;
using Fighters.Factories.RaceFactory;
using Fighters.Factories.WeaponFactory;
using Fighters.Manager;

namespace Fighters.ConsoleUI
{
    public class ConsoleUI
    {
        private GameManager _manager = new();
        private MenuActions? _menuAction;

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
                    Races race = ChooseRace( "Choose race: " );
                    Classes @class = ChooseClass( "Choose class: " );
                    Weapons weapon = ChooseWeapon( "Choose weapon: " );
                    Armors armor = ChooseArmor( "Choose armor: " );

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

        private void ShowAllRaces()
        {
            foreach ( var race in Enum.GetValues( typeof( Races ) ) )
            {
                Console.WriteLine( $"{( int )race} {race.ToString()}" );
            }
        }

        private void ShowAllWeapons()
        {
            foreach ( var weapon in Enum.GetValues( typeof( Weapons ) ) )
            {
                Console.WriteLine( $"{( int )weapon}. {weapon}" );
            }
        }

        private void ShowAllArmors()
        {
            foreach ( var armor in Enum.GetValues( typeof( Armors ) ) )
            {
                Console.WriteLine( $"{( int )armor}. {armor}" );
            }
        }

        private void ShowAllClasses()
        {
            foreach ( var @class in Enum.GetValues( typeof( Classes ) ) )
            {
                Console.WriteLine( $"{( int )@class}. {@class}" );
            }
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

        private Races ChooseRace( string promt )
        {
            while ( true )
            {
                Console.WriteLine( "Races: " );
                ShowAllRaces();
                Console.Write( promt );
                if ( int.TryParse( Console.ReadLine(), out var choice ) )
                {
                    return ( Races )choice;
                }
                Console.WriteLine( "Incorrect race." );
            }
        }

        private Classes ChooseClass( string promt )
        {
            while ( true )
            {
                Console.WriteLine( "Classes: " );
                ShowAllClasses();
                Console.Write( promt );
                if ( int.TryParse( Console.ReadLine(), out var choice ) )
                {
                    return ( Classes )choice;
                }
                Console.WriteLine( "Incorrect class." );
            }
        }

        private Weapons ChooseWeapon( string promt )
        {
            while ( true )
            {
                Console.WriteLine( "Weapons: " );
                ShowAllWeapons();
                Console.Write( promt );
                if ( int.TryParse( Console.ReadLine(), out var choice ) )
                {
                    return ( Weapons )choice;
                }
                Console.WriteLine( "Incorrect weapon." );
            }
        }

        private Armors ChooseArmor( string promt )
        {
            while ( true )
            {
                Console.WriteLine( "Armors: " );
                ShowAllArmors();
                Console.Write( promt );
                if ( int.TryParse( Console.ReadLine(), out var choice ) )
                {
                    return ( Armors )choice;
                }
                Console.WriteLine( "Incorrect armor." );
            }
        }
    }
}
