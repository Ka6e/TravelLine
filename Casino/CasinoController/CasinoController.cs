using CasinoGame;

namespace CasinoGameController
{
    public class CasinoController
    {
        private readonly Casino _casino = new Casino();
        private static readonly string _gameMenu = @"1. Start Game
2. Check Balance
3. Deposit
4. Exit";
        private Operation? _operation;

        public void Run()
        {
            Deposit();
            while ( _operation != Operation.Exit )
            {
                PrintMenu();
                Console.WriteLine( "Select operation: " );
                _operation = GetOperation();
                HandleOperation( _operation );
                Console.WriteLine();
            }
        }

        private Operation? GetOperation()
        {
            string operationStr = Console.ReadLine();
            bool isParse = Enum.TryParse( operationStr, out Operation operation );
            return isParse ? operation : null;
        }

        private void HandleOperation( Operation? operation )
        {
            switch ( operation )
            {
                case Operation.Play:
                    Play();
                    break;
                case Operation.CheckBalance:
                    Console.WriteLine( $"Your balance: {_casino.GetBalance()}" );
                    break;
                case Operation.Deposit:
                    Deposit();
                    break;
                case Operation.Exit:
                    Console.WriteLine( "Goodbye" );
                    break;
                default:
                    throw new Exception( $"Invalid operation: {operation}" );
            }
        }

        private void Play()
        {
            int bet = ReadNumber( "Please enter your bet: " );
            if ( !_casino.IsValidBet( bet ) )
            {
                Console.WriteLine( "Invalid bet: not enough balance or zero." );
            }

            int winnings = _casino.Play( bet );
            Console.WriteLine( bet == 0 ? $"Congratulations.You win: {winnings}." : "You lose." );
        }

        private int ReadNumber( string promt )
        {
            while ( true )
            {

                Console.Write( promt );
                string betStr = Console.ReadLine();
                if ( int.TryParse( betStr, out int number ) && number > 0 )
                {
                    return number;
                }
                Console.WriteLine( "Invalid number." );
            }
        }

        private void Deposit()
        {
            int amount = ReadNumber( "Please enter your amount: " );
            _casino.ToUpBalance( amount );
            Console.WriteLine( $"The balance was successfully replenished on: {amount}" );
        }

        private void PrintMenu()
        {
            Console.WriteLine( _gameMenu );
        }
    }
}