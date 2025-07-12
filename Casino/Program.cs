using CasinoGame;

try
{
    Casino casino = new Casino();
    casino.Run();
}
catch ( Exception ex )
{
    Console.WriteLine( $"Error: {ex.Message}" );
}
