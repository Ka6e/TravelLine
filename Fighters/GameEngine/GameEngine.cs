using Fighters.AtackStrategy;
using Fighters.AttackStrategy;
using Fighters.Logger;
using Fighters.Models.Fighters;

namespace Fighters.Engine
{
    public class GameEngine
    {
        private IFightersLogger _logger;
        private Random _random = new Random();

        public GameEngine( IFightersLogger logger )
        {
            _logger = logger;
        }

        public void RunBattle( List<Fighter> fighters )
        {
            var alliveFighters = fighters.Where( f => f.IsAlive ).ToList();
            if ( !IsEnoughFighters( alliveFighters ) )
            {
                _logger.LogError( $"Not enough fighters. You need at least 2 fighters. It's only {alliveFighters.Count} now." );
                return;
            }

            _logger.Log( "Battle started." );
            int round = 1;

            while ( alliveFighters.Count > 1 )
            {
                _logger.Log( $"Round: {round}" );

                for ( int i = 0; i < alliveFighters.Count - 1; i += 2 )
                {
                    var firstFighter = alliveFighters[ i ];
                    var secondFigter = alliveFighters[ i + 1 ];

                    alliveFighters.Remove( firstFighter );
                    alliveFighters.Remove( secondFigter );

                    _logger.Log( $"{firstFighter.Name} VS {secondFigter.Name}" );
                    var winnerOfDuel = RunDuel( firstFighter, secondFigter );
                    winnerOfDuel.HealFull();
                    alliveFighters.Add( winnerOfDuel );
                    _logger.Log( $"Winner: {winnerOfDuel.Name}" );
                }
                round++;
                _logger.Log( "\n" );
            }

            var winner = alliveFighters.First();
            _logger.Log( "Battle ended." );
            _logger.Log( $"Winner is: {winner.Name}." );
        }

        private Fighter RunDuel( Fighter first, Fighter second )
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
                ExecuteAtack( attacker, defender );
                if ( IsLowHP( defender ) )
                {
                    ChangeStrategy( defender, new RageAttackStrategy() );
                }
                if ( second.IsAlive )
                {
                    ExecuteAtack( defender, attacker );
                    if ( IsLowHP( attacker ) )
                    {
                        ChangeStrategy( attacker, new RageAttackStrategy() );
                    }
                }
                round++;
            }
            return attacker.IsAlive ? attacker : defender;
        }

        private bool IsLowHP( Fighter fighter )
        {
            int expression = ( fighter.GetCurrentHealth() / fighter.GetMaxHealth() ) * 100;
            return expression <= 20 ? true : false;
        }

        private void ChangeStrategy( Fighter fighter, IAttackStrategy attackStrategy )
        {
            if ( IsLowHP( fighter ) )
            {
                fighter.SetAttackStrategy( attackStrategy );
            }
        }

        private void ExecuteAtack( Fighter attacker, Fighter defender )
        {
            int damage = attacker.Atack();
            int realDamage = defender.TakeDamage( damage );
            _logger.Log( $"{attacker.Name} attacks {defender.Name} for {realDamage} damage "
                + $"{defender.Name} health: {defender.GetCurrentHealth()}/{defender.GetMaxHealth()}" );
        }

        private bool IsEnoughFighters( List<Fighter> fighters )
        {
            return fighters.Count >= 2;
        }

    }
}
