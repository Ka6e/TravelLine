namespace CasinoGame;
public class Casino
{
    private static readonly int _multiplicator = 10;
    private static readonly List<int> _winPositions = new List<int>() { 18, 19, 20 };
    private readonly Random _rnd = new Random();
    private int _balance;

    public int GetBalance()
    {
        return _balance;
    }

    public void ToUpBalance( int amount )
    {
        if ( amount > 0 )
        {
            _balance += amount;
        }
    }

    public int Play( int bet )
    {
        _balance -= bet;
        int number = GenerateRandomNumber();

        if ( IsWin( number ) )
        {
            int winnings = CalculateWinnings( number );
            _balance += winnings;
            return winnings;
        }
        return 0;
    }

    public bool IsValidBet( int bet ) => bet > 0 ? true : false;

    private int GenerateRandomNumber()
    {
        return _rnd.Next( 1, 21 );
    }

    private bool IsWin( int number )
    {
        return _winPositions.Contains( number );
    }

    private int CalculateWinnings( int bet )
    {
        int result = bet * ( 1 + _multiplicator * GenerateRandomNumber() % 17 );
        return result;
    }
}
