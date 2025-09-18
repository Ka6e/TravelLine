using CasinoGameController;

string gameName = @"
#       #   ##   #   #  ###   ###  
#       #  #  #  ##  #   #   #   # 
#   #   #  #  #  # # #   #   #   # 
#  # #  #  #  #  #  ##   #   #   # 
 ##   ##    ##   #   #  ###   ###  ";

try
{
    PrintGameName( gameName );
    CasinoController casinoController = new CasinoController();
    casinoController.Run();
}
catch ( Exception ex )
{
    Console.WriteLine( $"Error: {ex.Message}" );
}

static void PrintGameName( string gameName )
{
    Console.WriteLine( gameName );
    Console.WriteLine();
}