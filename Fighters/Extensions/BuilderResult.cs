namespace Fighters.Extensions
{
    public record BuilderResult<T>( bool isSuccess, T? value, string? errorMassage )
    {
        public static BuilderResult<T> Success( T value ) => new( true, value, null );
        public static BuilderResult<T> Failure( string errorMassage ) => new( false, default, errorMassage );
    }
}
