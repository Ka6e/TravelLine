using Fighters.ConsoleUI.ConsoleCommands;

namespace Fighters.ConsoleUI.ConsoleCommand
{
    public class PlayGameCommand : IConsoleCommand
    {
        private readonly GameManager.GameManager _gameManager;
        public string Name => "Play";
        public string Description => "Starts the tournament between fighters";

        public PlayGameCommand( GameManager.GameManager gameManager )
        {
            _gameManager = gameManager;
        }

        public void Execute()
        {
            Console.Clear();
            _gameManager.Fight();
            Console.WriteLine( "Press any key to return to menu." );
            Console.ReadKey();
            Console.Clear();
        }
    }
}
