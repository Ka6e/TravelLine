namespace Fighters.Logger
{
    public class FightersLogger : IFightersLogger
    {
        public void Log( string message )
        {
            Console.WriteLine( message );
        }

        public void LogError( string message )
        {
            Console.WriteLine( $"Error: {message}" );
        }
    }
}
