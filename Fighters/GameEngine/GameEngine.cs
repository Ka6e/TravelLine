using Fighters.AttackStrategy;
using Fighters.Logger;
using Fighters.Models.Classes;
using Fighters.Models.Fighters;

namespace Fighters.GameEngine
{
    public class GameEngine
    {
        private IFightersLogger _logger;
        private Random _random = new Random();
        private readonly List<IAttackStrategy> _attackStrategy = new List<IAttackStrategy>
        {
            new StandartAttackStrategy(),
            new RageAttackStrategy(),
            new VampirismAttackStrategy(),
            new BerserkAttackStrategy(),
        };

        public GameEngine( IFightersLogger logger )
        {
            _logger = logger;
        }

        public void RunBattle( List<IFighter> fighters )
        {
            var alliveFighters = fighters.Where( f => f.IsAlive ).ToList();
            if ( !IsEnoughFighters( alliveFighters ) )
            {
                _logger.LogError( $"Not enough fighters. You need at least 2 fighters. It's only {alliveFighters.Count} now." );
                return;
            }
            _logger.Log( "Tournament started." );
            int round = 1;
            while ( alliveFighters.Count > 1 )
            {
                _logger.Log( $"Round: {round}" );
                var firstFighter = alliveFighters.ElementAt( _random.Next( 0, alliveFighters.Count ) );
                alliveFighters.Remove( firstFighter );
                var secondFighter = alliveFighters.ElementAt( _random.Next( 0, alliveFighters.Count ) );
                alliveFighters.Remove( secondFighter );
                _logger.Log( $"{firstFighter.Name} VS {secondFighter.Name}" );
                var winnerOfDuel = RunDuel( firstFighter, secondFighter );
                winnerOfDuel.HealFull();
                alliveFighters.Add( winnerOfDuel );
                _logger.Log( $"Winner: {winnerOfDuel.Name}" );
                round++;
            }
            var winner = alliveFighters.First();
            _logger.Log( "Tournament ended." );
            _logger.Log( $"The winner of the tournament is: {winner.Name}." );
        }

        private IFighter RunDuel( IFighter first, IFighter second )
        {
            var order = new[] { first, second }
            .OrderByDescending( x => x.Initiative )
            .ToList();
            var attacker = order[ 0 ];
            var defender = order[ 1 ];
            int round = 1;
            while ( attacker.IsAlive && defender.IsAlive )
            {
                _logger.Log( $"Round of duel: {round}" );
                ExecuteAttack( attacker, defender );
                if ( defender.IsAlive )
                {
                    ExecuteAttack( defender, attacker );
                }
                round++;
            }
            return attacker.IsAlive ? attacker : defender;
        }

        private bool IsLowHP( IFighter fighter )
        {
            double expression = ( ( double )fighter.GetCurrentHealth() / ( double )fighter.GetMaxHealth() ) * 100;
            return expression <= 20;
        }

        private IAttackStrategy GetRandomStrategy()
        {
            int index = _random.Next( 0, _attackStrategy.Count - 1 );
            return _attackStrategy[ index ];
        }

        private void SetRandomStrategy( IFighter fighter )
        {
            if ( fighter.Class is Barbarian && IsLowHP( fighter ) )
            {
                fighter.SetAttackStrategy( new BerserkAttackStrategy() );
            }
            else if ( IsLowHP( fighter ) )
            {
                fighter.SetAttackStrategy( new RageAttackStrategy() );
            }
            else
            {
                fighter.SetAttackStrategy( GetRandomStrategy() );
            }
        }

        private void ExecuteAttack( IFighter attacker, IFighter defender )
        {
            SetRandomStrategy( attacker );
            int damage = attacker.Attack();
            int realDamage = defender.TakeDamage( damage );
            if ( realDamage != 0 )
            {
                _logger.Log( $"{attacker.Name} attacks {defender.Name} for {realDamage} damage \n"
                    + $"{attacker.Name} hp: {attacker.GetCurrentHealth()}/{attacker.GetMaxHealth()} \t"
                    + $"{defender.Name} hp: {defender.GetCurrentHealth()}/{defender.GetMaxHealth()}" );
                return;
            }
            _logger.Log( $"{attacker.Name} attacks {defender.Name}, but couldn't penetrate the armor!" );
        }

        private bool IsEnoughFighters( List<IFighter> fighters )
        {
            return fighters.Count >= 2;
        }

    }
}
