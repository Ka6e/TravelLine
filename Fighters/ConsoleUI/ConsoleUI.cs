using Fighters.ConsoleUI.ConsoleCommands;

namespace Fighters.ConsoleUI
{
    public class ConsoleUI
    {
        private readonly List<IConsoleCommand> _consoleCommands;

        public ConsoleUI( List<IConsoleCommand> consoleCommands )
        {
            _consoleCommands = consoleCommands;
        }

        public void Run()
        {
            while ( true )
            {
                ShowMenu();
                Console.Write( "Select the command: " );
                ExecuteCommand();
            }
        }

        private void ExecuteCommand()
        {
            if ( int.TryParse( Console.ReadLine(), out int number ) )
            {
                if ( number >= 1 && number <= _consoleCommands.Count )
                {
                    Console.Clear();
                    _consoleCommands[ number - 1 ].Execute();
                }
                else
                {
                    Console.WriteLine( "Unknown command." );
                    Console.WriteLine( "Press any key to try again." );
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine( "Unknown command." );
                Console.WriteLine( "Press any key to try again." );
                Console.ReadKey();
                Console.Clear();
            }

        }

        private void ShowMenu()
        {
            Console.WriteLine( "=== Menu ===" );
            for ( int i = 0; i < _consoleCommands.Count; i++ )
            {
                Console.WriteLine( $"{i + 1}.{_consoleCommands[ i ].Name}: ({_consoleCommands[ i ].Description})" );
            }
            Console.WriteLine();
        }
    }
}
