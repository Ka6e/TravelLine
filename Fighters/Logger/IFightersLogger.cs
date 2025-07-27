namespace Fighters.Logger
{
    public interface IFightersLogger
    {
        void Log( string message );
        void LogError( string message );
    }
}
