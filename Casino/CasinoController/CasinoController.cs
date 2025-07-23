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
            Casino.PrintGameName();
            Deposit();
            while ( _operation != Operation.Exit )
            {
                PrintMenu();
                Console.WriteLine( "Select operation: " );
                _operation = GetOperation();
                HandlerOperation( _operation );
                Console.WriteLine();
            }
        }

        private Operation? GetOperation()
        {
            string operationStr = Console.ReadLine();
            bool isParse = Enum.TryParse( operationStr, out Operation operation );
            return isParse ? operation : null;
        }

        private void HandlerOperation( Operation? operation )
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
            Console.Write( "Please enter your bet: " );
            string betStr = Console.ReadLine();
            if ( !int.TryParse( betStr, out int bet ) )
            {
                Console.WriteLine( "Invalid bet." );
                return;
            }

            if ( !_casino.IsValidBet( bet ) )
            {
                Console.WriteLine( "Invalid bet: not enough balance or zero." );
            }

            int winnings = _casino.Play( bet );
            Console.WriteLine( bet == 0 ? $"Congratulations.You win: {winnings}." : "You lose." );
        }

        private void Deposit()
        {
            bool isValid = false;
            while ( !isValid )
            {
                Console.Write( "Please enter the deposit amount: " );
                if ( int.TryParse( Console.ReadLine(), out int amount ) && amount > 0 )
                {
                    _casino.ToUpBalance( amount );
                    Console.WriteLine( $"The balance was successfully replenished on: {amount}" );
                    isValid = true;
                }
                else
                {
                    Console.WriteLine( $"Invalid amount value entered." );
                }
            }
        }

        private void PrintMenu()
        {
            Console.WriteLine( _gameMenu );
        }
    }
}