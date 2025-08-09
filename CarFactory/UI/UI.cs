using CarFactory.UI.Commands;
using Spectre.Console;

namespace CarFactory.UI
{
    public class UI
    {
        private readonly List<ICommand> _commands;

        public UI( List<ICommand> commands )
        {
            _commands = commands;
        }

        public void Run()
        {
            while ( true )
            {
                ExecuteCommand();
            }
        }

        public void ExecuteCommand()
        {
            var command = AnsiConsole.Prompt(
                new SelectionPrompt<ICommand>()
                .Title( "Choose the commad." )
                .PageSize( 10 )
                .AddChoices( _commands ) );

            command.Execute();
        }
    }
}
