using Fighters.ConsoleUI.ConsoleCommands;

namespace Fighters.ConsoleUI.ConsoleCommand
{
    public class ShowFightersCommand : IConsoleCommand
    {
        private readonly GameManager.GameManager _gameManager;
        public string Name => "Show fighters";
        public string Description => "Show all fighters in the tournament";

        public ShowFightersCommand( GameManager.GameManager gameManager )
        {
            _gameManager = gameManager;
        }

        public void Execute()
        {
            Console.WriteLine( "Fighters: \n" );
            _gameManager.ShowFighters();
            Console.WriteLine( "Press any key to return to menu." );
            Console.ReadKey();
            Console.Clear();
        }
    }
}
