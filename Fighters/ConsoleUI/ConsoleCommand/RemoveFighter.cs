using Fighters.ConsoleUI.ConsoleCommands;
using Fighters.Models.Fighters;

namespace Fighters.ConsoleUI.ConsoleCommand
{
    public class RemoveFighter : IConsoleCommand
    {
        private readonly GameManager.GameManager _gameManager;
        public string Name => "Remove fighter";
        public string Description => "Removes the fighters you need";


        public RemoveFighter( GameManager.GameManager gameManager )
        {
            _gameManager = gameManager;
        }

        public void Execute()
        {
            Console.Clear();

            while ( true )
            {
                ShowOptions();
                Console.Write( "Choose option: " );
                int choice = ChooseOption();

                switch ( choice )
                {
                    case 1:
                        RemoveSingleFighter();
                        break;
                    case 2:
                        RemoveDeadFighters();
                        break;
                    case 3:
                        RemoveAll();
                        break;
                    case 4:
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine( "Invalid option." );
                        break;
                }
                Console.WriteLine( "Press any key to continue." );
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void RemoveSingleFighter()
        {
            var figters = _gameManager.GetFighters();
            if ( !ValidateFighterList( figters, out int index ) )
            {
                return;
            }
            var figter = figters[ index ];
            _gameManager.RemoveFighter( figter );
            Console.WriteLine( $"Fighter {figter.Name} removed." );
        }

        private void ShowOptions()
        {
            Console.WriteLine( "=== Remove Fighter ===" );
            Console.WriteLine( "1. Remove one fighter" );
            Console.WriteLine( "2. Remove dead fighters" );
            Console.WriteLine( "3. Remove all fighters" );
            Console.WriteLine( "4. Back" );
        }

        private void RemoveAll()
        {
            if ( !IsEnoughFighters() )
            {
                return;
            }
            Console.WriteLine( "All fighters removed." );
            _gameManager.RemoveAllFighters();
        }

        private void RemoveDeadFighters()
        {
            if ( !IsEnoughFighters() )
            {
                return;
            }
            _gameManager.RemoveDeadFighters();
            Console.WriteLine( "Dead fighters removed." );
        }

        private bool ValidateFighterList( List<Fighter> fighters, out int index )
        {
            index = -1;
            if ( !IsEnoughFighters() )
            {
                return false;
            }
            Console.WriteLine( "Choose a fighter to remove:" );
            ShowFighters();
            Console.Write( "Enter number: " );
            int choice = ChooseOption();
            if ( choice < 1 || choice > fighters.Count )
            {
                Console.WriteLine( "Invalid fighter number." );
                return false;
            }
            index = choice - 1;
            return true;
        }


        private void ShowFighters()
        {
            var figters = _gameManager.GetFighters();
            for ( int i = 0; i < figters.Count; i++ )
            {
                Console.WriteLine( $"{i + 1}. {figters[ i ]}" );
            }
        }

        private bool IsEnoughFighters( string message = "No fighters to remove." )
        {
            if ( _gameManager.GetFighters().Count == 0 )
            {
                Console.WriteLine( message );
                return false;
            }
            return true;
        }

        private int ChooseOption()
        {
            while ( true )
            {
                if ( int.TryParse( Console.ReadLine(), out int value ) )
                {
                    return value;
                }
                Console.WriteLine( "Invalid value." );
            }
        }

    }
}
