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
                ShowName();
                ExecuteCommand();
            }
        }

        public void ExecuteCommand()
        {
            var commandName = _commands.Select( x => x.Name ).ToList();

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title( "Choose the commad." )
                .PageSize( 10 )
                .AddChoices( commandName ) );

            var selectedCommand = _commands.FirstOrDefault( x => x.Name == choice );
            selectedCommand.Execute();
        }

        private void ShowName()
        {
            AnsiConsole.Write(
                new FigletText( "Car-factory" )
                .Centered()
                .Color( Color.Red ) );
        }
    }
}
