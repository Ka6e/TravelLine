using Operations;
namespace CasinoGame;
public class Casino
{
    private static readonly string GameName = @"
#       #   ##   #   #  ###   ###  
#       #  #  #  ##  #   #   #   # 
#   #   #  #  #  # # #   #   #   # 
#  # #  #  #  #  #  ##   #   #   # 
 ##   ##    ##   #   #  ###   ###  ";
    private static readonly int multiplicator = 10;
    private static readonly List<int> winPositions = new List<int>() { 18, 19, 20 };
    private readonly Random rnd = new Random();
    private int balance;
    private Operation? operation;

    public int GetBalance()
    {
        return balance;
    }

    private int GenerateRandomNumber()
    {
        return rnd.Next( 1, 21 );
    }

    private bool IsWin( int number )
    {
        return ( winPositions.Contains( number ) );
    }

    private int CalculateWinnings( int bet )
    {
        int result = bet * ( 1 + ( multiplicator * GenerateRandomNumber() % 17 ) );
        return result;
    }

    public static void PrintGameName()
    {
        Console.WriteLine( GameName );
        Console.WriteLine();
    }

    private Operation? GetOperation()
    {
        string operationStr = Console.ReadLine();
        bool isParse = Enum.TryParse( operationStr, out Operation operation );
        return isParse ? operation : null;
    }

    public static void PrintMenu()
    {
        Console.WriteLine( "1. Start the game" );
        Console.WriteLine( "2. Check balance" );
        Console.WriteLine( "3. Top up your balance" );
        Console.WriteLine( "4. Exit" );
    }

    private void ToUpBalance()
    {
        bool isValid = false;
        while ( !isValid )
        {
            Console.Write( "Please enter the deposit amount: " );
            if ( int.TryParse( Console.ReadLine(), out int amount ) && amount > 0 )
            {
                balance += amount;
                Console.WriteLine( $"The balance was successfully replenished on: {amount}" );
                isValid = true;
            }
            else
            {
                Console.WriteLine( $"Invalid amount value entered." );
            }
        }
    }

    private bool IsValidBet( int bet )
    {
        if ( bet <= 0 )
        {
            Console.WriteLine( "Your bet must be more than zero." );
            return false;
        }
        if ( bet > GetBalance() )
        {
            Console.WriteLine( "Your bet is more than your balance." );
            return false;
        }
        return true;
    }

    private void PlayGame()
    {
        Console.Write( "Please enter your bet: " );
        string betStr = Console.ReadLine();
        if ( !int.TryParse( betStr, out int bet ) )
        {
            Console.WriteLine( "Invalid bet." );
            return;
        }

        if ( !IsValidBet( bet ) )
        {
            return;
        }

        balance -= bet;
        int number = GenerateRandomNumber();
        if ( IsWin( number ) )
        {
            int winnings = CalculateWinnings( bet );
            balance += winnings;
            Console.WriteLine( $"Congratulations. You win: {winnings}." );
        }
        else
        {
            Console.WriteLine( "You lose." );
        }
    }

    private void HandlerOperation( Operation? operation )
    {
        switch ( operation )
        {
            case Operation.Play:
                PlayGame();
                break;
            case Operation.CheckBalance:
                Console.WriteLine( $"Your balance: {GetBalance()}" );
                break;
            case Operation.Deposit:
                ToUpBalance();
                break;
            case Operation.Exit:
                Console.WriteLine( "Goodbye" );
                break;
            default:
                throw new Exception( $"Invalid operation: {operation}" );
        }
    }

    public void Run()
    {
        PrintGameName();
        ToUpBalance();
        while ( operation != Operation.Exit )
        {
            PrintMenu();
            Console.Write( "Select operation: " );
            operation = GetOperation();
            HandlerOperation( operation );
            Console.WriteLine();
        }
    }
}
