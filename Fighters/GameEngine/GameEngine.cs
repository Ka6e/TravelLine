using Fighters.AtackStrategy;
using Fighters.AttackStrategy;
using Fighters.Builder;
using Fighters.Logger;
using Fighters.Models.Fighters;

namespace Fighters.Engine
{
    public class GameEngine
    {
        private int _round = 1;
        private IFightersLogger _logger;
        private Random _random = new Random();

        public GameEngine( IFightersLogger logger )
        {
            _logger = logger;
        }

        public void RunBattle( List<Fighter> fighters )
        {
            var alliveFighters = fighters;
            if ( !IsEnoughFighters( alliveFighters ) )
            {
                _logger.LogError( $"Not enough fighters. You need at least 2 fighters. It's only {alliveFighters.Count} now." );
                return;
            }

            var winners = new List<Fighter>();

            while ( alliveFighters.Count > 1 )
            {

            }
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

        //private void PerformTurn( Fighter first, Fighter second )
        //{
        //    ExecuteAtack( first, second );
        //    CheckAndChangeStrategy()
        //}

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
            _logger.Log( $"{attacker.Name} " );
        }
        private bool IsEnoughFighters( List<Fighter> fighters )
        {
            return fighters.Count > 2;
        }

    }
}
