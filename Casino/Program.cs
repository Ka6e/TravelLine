using CasinoGameController;

try
{
    CasinoController casinoController = new CasinoController();
    casinoController.Run();
}
catch ( Exception ex )
{
    Console.WriteLine( $"Error: {ex.Message}" );
}
