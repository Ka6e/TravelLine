namespace CarFactory.UI.Commands
{
    public class Exit : ICommand
    {
        public string Name => "Exit";

        public void Execute()
        {
            Environment.Exit( 0 );
        }
    }
}
